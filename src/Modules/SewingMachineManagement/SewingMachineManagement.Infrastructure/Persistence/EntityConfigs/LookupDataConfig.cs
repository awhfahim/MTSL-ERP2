using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.LookupDataEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class LookupDataConfig : IEntityTypeConfiguration<LookupData>
{
    public void Configure(EntityTypeBuilder<LookupData> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("LOOKUP_DATA_ID");

        builder.Property(e => e.LookupTableId)
            .HasColumnName("LOOKUP_TABLE_ID");

        builder.Property(e => e.Code)
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_DATA_CODE");

        builder.Property(e => e.EnglishName)
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_DATA_NAME_EN");

        builder.Property(e => e.BengaliName)
            .HasMaxLength(BengaliNameMaxLength)
            .IsUnicode()
            .HasColumnName("LK_DATA_NAME_BN");

        builder.Property(e => e.Description)
            .HasMaxLength(DescriptionMaxLength)
            .IsUnicode(false)
            .HasColumnName("LK_DATA_DESC");

        builder.Property(e => e.ColorCode)
            .HasMaxLength(ColorCodeMaxLength)
            .IsUnicode(false)
            .HasColumnName("COLOR_CODE");

        builder.Property(e => e.DataPrefix)
            .HasMaxLength(DataPrefixMaxLength)
            .IsUnicode(false)
            .HasColumnName("DATA_PREFIX");

        builder.Property(e => e.DisplayOrder)
            .HasColumnName("DISPLAY_ORDER");

        builder.Property(e => e.ParameterValue)
            .HasPrecision(9, 2)
            .HasColumnName("LK_DATA_PARAM_VALUE");
        
        builder
            .HasOne<LookupTable>()
            .WithMany()
            .HasForeignKey(x => x.LookupTableId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}