using WebApiNetCore.Models;

namespace WebApiNetCore
{
    public interface IProductRepository
    {
        public TimeSpan DatabaseIO();
    }
}
