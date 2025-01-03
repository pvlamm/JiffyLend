namespace JiffyLend.Module.Card.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardholderConfiguration : IEntityTypeConfiguration<Cardholder>
{
    public void Configure(EntityTypeBuilder<Cardholder> builder)
    {
        builder.ToTable(nameof(Cardholder));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DisplayName)
            .HasMaxLength(60)
            .IsRequired();
        builder.Property(x => x.UpdateDate)
            .IsRequired();
    }
}
