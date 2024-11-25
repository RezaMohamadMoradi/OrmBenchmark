using OrmBenchmark.Models;
using OrmBenchmark.Repository.Interface;

namespace OrmBenchmark.REpository
{
    public class EfcoreRepository : IEfcoreRepository
    {
        private readonly Dbefcore dbefcore;
        public EfcoreRepository(Dbefcore db)
        {
            dbefcore = db;
        }
        public void create(Product p)
        {
            dbefcore.products.Add(p);
            dbefcore.SaveChanges();
        }

        public List<Product> GetAll()
        {
           return dbefcore.products.Select(x=>x).ToList();
        }
    }
}
