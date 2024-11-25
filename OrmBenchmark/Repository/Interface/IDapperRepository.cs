using OrmBenchmark.Models;

namespace OrmBenchmark.Repository.Interface
{
    public interface IDapperRepository
    {
        IEnumerable<Product> readall();
        void crate(Product p);
    }
}
