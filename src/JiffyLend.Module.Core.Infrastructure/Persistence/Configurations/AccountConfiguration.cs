namespace JiffyLend.Module.Core.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.HasIndex(x => x.AccountNumber)
            .IsUnique();

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.AccountNumber)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(x => x.CreateDate);
        builder
            .Property(x => x.UpdateDate);

        builder.HasMany(x => x.Customers)
            .WithOne(x => x.Parent)
            .HasForeignKey(x => x.ParentId);
    }
}