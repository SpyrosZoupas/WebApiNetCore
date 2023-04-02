using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiNetCore.Models;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //Databse Input Output performance test
        [HttpGet("DatabaseIO")]
        public TimeSpan DatabaseIO()
        {
            return productRepository.DatabaseIO();
        }

        //Disc Input Output performance test
        [HttpGet("DiscIO")]
        public TimeSpan DiscIOPerformanceTest()
        {
            //Deletes "integers.csv" file if it already exists
            if (System.IO.File.Exists("integers.csv"))
            {
                System.IO.File.Delete("integers.csv");
            }

            //start timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //size of integers array
            int size = 10000;

            Random random = new Random();
            int[] integers = new int[size];

            //integersList that will hold the result of reading the "integers.csv" file
            List<int> integersList = new List<int>();

            //populate integers array of size 10000 with random numbers ranging from 0 to 1000
            for (int i = 0; i < size; i++)
            {
                integers[i] = random.Next(0, 1000);
            }       

            //use StreamWriter WriteLine() method to write the integers array into the "integers.csv" file
            using (StreamWriter writer = new StreamWriter("integers.csv"))
            {
                for (int i = 0; i < size; i++)
                {
                    writer.WriteLine(integers[i]);
                }
            }

            //use StreamReader ReadLine() method to parse the "integers.csv" file and add it to the integersList line by line
            using (StreamReader reader = new StreamReader("integers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    int integer = int.Parse(reader.ReadLine());
                    integersList.Add(integer);
                }
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;

        }

        //Garbage Colleciton Performance Test
        [HttpGet("GarbageCollection")]
        public TimeSpan GarbageCollectionPerformanceTest()
        {
            const int ObjectSizeInMB = 100;
            const int NumIterations = 10;

            // Allocate a large object in memory
            byte[] largeObject = new byte[ObjectSizeInMB * 1024 * 1024];

            // Peforms an operation on the object
            // Populates the object with integers
            for (int i = 0; i < largeObject.Length; i++)
            {
                largeObject[i] = 1;
            }

            // Starts timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Force garbage collection and measure the time it takes
            for (int i = 0; i < NumIterations; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        // Thread Performance Testing
        [HttpGet("ThreadPerformance")]
        public TimeSpan ThreadTest()
        {
            int numThreads = 4;
            int numIterations = 10000000;

            // Create an array of 4 threads
            Thread[] threads = new Thread[numThreads];

            // Start the timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Start the threads
            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < numIterations; j++)
                    {
                        // Perform some CPU-bound work
                        double result = Math.Sqrt(j * 1000);
                    }
                });
                threads[i].Start();
            }

            // Wait for all threads to complete
            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
