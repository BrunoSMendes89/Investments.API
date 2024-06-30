using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class BankStatementMap : IEntityTypeConfiguration<BankStatement>
    {
        public void Configure(EntityTypeBuilder<BankStatement> builder)
        {
            builder.ToTable("bankstatements");
            builder.HasKey(a => a.BankStatementId);
            builder.HasMany(t => t.Transactions).WithOne(t => t.BankStatement).HasForeignKey(t => t.BankStatementId);
        }
    }
}
