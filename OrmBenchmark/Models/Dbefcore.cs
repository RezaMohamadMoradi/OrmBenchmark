using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OrmBenchmark.Models
{
    public class Dbefcore : DbContext
    {

        public Dbefcore(DbContextOptions<Dbefcore> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> products { get; set; }
    }
        
}
