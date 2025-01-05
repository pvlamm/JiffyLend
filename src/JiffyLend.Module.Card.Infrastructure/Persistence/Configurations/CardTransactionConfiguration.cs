namespace JiffyLend.Module.Card.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardTransactionConfiguration : IEntityTypeConfiguration<CardTransaction>
{
    public void Configure(EntityTypeBuilder<CardTransaction> builder)
    {
        builder.ToTable(nameof(CardTransaction));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CardId);
        builder.Property(x => x.AccountId);
        builder.Property(x => x.CardholderId);
        builder.Property(x => x.MemoPostId)
            .IsRequired(false);

        builder.Property(x => x.IsPending);
        builder.Property(x => x.Description)
            .HasMaxLength(512);
        builder.Property(x => x.Amount);
    }
}
