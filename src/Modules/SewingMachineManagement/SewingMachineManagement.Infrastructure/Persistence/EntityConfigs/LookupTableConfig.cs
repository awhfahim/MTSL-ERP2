using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.LookupTableEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class LookupTableConfig : IEntityTypeConfiguration<LookupTable>
{
    public void Configure(EntityTypeBuilder<LookupTable> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("LOOKUP_TABLE_ID");

        builder.Property(e => e.Code)
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_TABLE_CODE");

        builder.Property(e => e.EnglishName)
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_TABLE_NAME_EN");

        builder.Property(e => e.BengaliName)
            .HasMaxLength(BengaliNameMaxLength)
            .IsUnicode()
            .HasColumnName("LK_TABLE_NAME_BN");

        builder.Property(e => e.Description)
            .HasMaxLength(DescriptionMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_TABLE_DESC");
    }
}