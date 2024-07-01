using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class ProductsMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(a => a.ProductId);
            builder.HasMany(c => c.Transactions).WithOne(bs => bs.Product).HasForeignKey(bs => bs.ProductId);
        }
    }
}
