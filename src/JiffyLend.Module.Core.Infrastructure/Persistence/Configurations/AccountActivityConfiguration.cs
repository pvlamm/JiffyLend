namespace JiffyLend.Module.Core.Infrastructure.Persistence.Configurations;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountActivityConfiguration : IEntityTypeConfiguration<AccountActivity>
{
    public void Configure(EntityTypeBuilder<AccountActivity> builder)
    {
        builder.ToTable("AccountActivity");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ParentId);
        builder.Property(x => x.MemoPostId)
            .IsRequired(false);
        builder.Property(x => x.CreateDate);
        builder.Property(x => x.UpdateDate);
        builder.Property(x => x.DepositType);
        builder.Property(x => x.ReferenceNumber)
            .HasMaxLength(16)
            .IsRequired();
        builder.Property(x => x.Amount);

    }
}
