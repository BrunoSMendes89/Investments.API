using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mapping;

namespace Persistence.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(new ProductsMap().Configure);
            modelBuilder.Entity<Users>(new UsersMap().Configure);
            modelBuilder.Entity<Customers>(new CustomersMap().Configure);
            base.OnModelCreating(modelBuilder);
        }

    }
}
