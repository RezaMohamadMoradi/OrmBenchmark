using OrmBenchmark.Models;

namespace OrmBenchmark.Repository.Interface
{
    public interface IEfcoreRepository
    {
        List<Product> GetAll();
        void create(Product p);
    }
}
