using Dapper;
using OrmBenchmark.Models;
using OrmBenchmark.Repository.Interface;
using System.Data;

namespace OrmBenchmark.REpository
{
    public class DapperRepository : IDapperRepository
    {
         private IDbConnection connection;
        public DapperRepository(IDbConnection db)
        {
            connection = db;
        }
        public IEnumerable<Product> readall()
        {
            return connection.Query<Product>("select * from products");
        }
        public void crate(Product p )
        {
             connection.Query<Product>("select * from products (name) VALUES (@name)",p);
        }
    }
}
