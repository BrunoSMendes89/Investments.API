using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class CustomersProductsMap : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.ToTable("customersproducts");
            builder.HasKey(cp => new { cp.CustomerId, cp.ProductId});
            builder.HasOne(cp => cp.Customer).WithMany(c => c.CustomerProducts).HasForeignKey(cp => cp.CustomerId);
            builder.HasOne(cp => cp.Product).WithMany(c => c.CustomerProducts).HasForeignKey(cp => cp.ProductId);
        }
    }
}
