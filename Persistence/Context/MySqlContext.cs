using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mapping;

namespace Persistence.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<BankStatement> BankStatements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(new ProductsMap().Configure);
            modelBuilder.Entity<User>(new UsersMap().Configure);
            modelBuilder.Entity<Customer>(new CustomersMap().Configure);
            modelBuilder.Entity<BankStatement>(new BankStatementMap().Configure);
            modelBuilder.Entity<Transaction>(new TransactionMap().Configure);
            base.OnModelCreating(modelBuilder);
        }

    }
}
