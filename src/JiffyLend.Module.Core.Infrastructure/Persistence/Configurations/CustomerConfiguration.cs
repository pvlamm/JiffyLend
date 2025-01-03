namespace JiffyLend.Module.Core.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.EmailAddress)
            .IsUnique();

        builder.Property(x => x.FirstName)
            .HasMaxLength(30)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasMaxLength(30)
            .IsRequired();
        builder.Property(x => x.CreateDate);
        builder.Property(x => x.UpdateDate);
        builder.Property(x => x.EmailAddress)
            .HasMaxLength(120)
            .IsRequired();

        builder.HasMany(x => x.Accounts)
            .WithMany(x => x.Customers)
            .UsingEntity<Account>(x => x.HasOne<Account>()
                .WithMany()
                .HasForeignKey(x => x.Id),
                x => x.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.Id)
            );
    }
}