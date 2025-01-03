namespace JiffyLend.Module.Card.Infrastructure.Persistence.Configurations;
using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.IsActive)
            .HasDefaultValue(false)
            .IsRequired();
        builder.Property(x => x.UpdateDate)
            .IsRequired();
    }
}
