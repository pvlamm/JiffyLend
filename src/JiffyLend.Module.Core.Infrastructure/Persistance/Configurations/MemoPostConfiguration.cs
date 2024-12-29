namespace JiffyLend.Module.Core.Infrastructure.Persistance.Configurations;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MemoPostConfiguration : IEntityTypeConfiguration<MemoPost>
{
    public void Configure(EntityTypeBuilder<MemoPost> builder)
    {
        builder.ToTable("MemoPosts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AccountId);
        builder.Property(x => x.CreateDate);
        builder.Property(x => x.ExpiresAt);
        builder.Property(x => x.CompleteDate);
        builder.Property(x => x.CancelDate);
        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(x => x.Amount);
    }
}