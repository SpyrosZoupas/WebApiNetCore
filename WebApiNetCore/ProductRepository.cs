using DataAccessLayer.Context;
using WebApiNetCore.Models;
using Dapper;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace WebApiNetCore
{
    public class ProductRepository : IProductRepository
    {
        public readonly DapperContext dapperContext;

        public ProductRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        // Method that writes and reads some data on a database
        public TimeSpan DatabaseIO()
        {
            // Create and populate a list of 2000 Products 
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 2000; i++)
            {
                products.Add(new Product { Name = $"Product{i}", Description = $"Description for Product{i}", Price = i * 10 });
            }

            // Connect to the database
            using (var connection = dapperContext.CreateConnection())
            {
                // Delete any existing data in the Products table
                connection.Execute("DELETE FROM PRODUCT");

                //Start timer
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Insert the list of products into the database using Dapper
                connection.Execute("INSERT INTO PRODUCT (Name, Description, Price) VALUES (@Name, @Description, @Price)", products);

                // Select all PRODUCT rows from the database and convert them to a list
                var query = "SELECT * FROM PRODUCT";
                var result = connection.Query<Product>(query).ToList();

                // Stop timer
                stopwatch.Stop();
                return stopwatch.Elapsed;
            }            
        }
    }
}
