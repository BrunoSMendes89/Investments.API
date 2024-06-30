using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class CustomersMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(a => a.CustomerId);
            builder.HasMany(c => c.Transactions).WithOne(bs => bs.Customer).HasForeignKey(bs => bs.CustomerId);
        }
    }
}
