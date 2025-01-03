namespace JiffyLend.Module.Card.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable(nameof(Card));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AccountId);
        builder.Property(x => x.CardholderId);
        builder.Property(x => x.CreditCardNumber)
            .HasMaxLength(16)
            .IsRequired();
    }
}
