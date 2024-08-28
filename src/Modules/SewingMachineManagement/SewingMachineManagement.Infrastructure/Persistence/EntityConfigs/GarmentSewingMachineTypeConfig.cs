using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineTypeEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineTypeConfig : IEntityTypeConfiguration<GarmentSewingMachineType>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineType> builder)
    {
        builder.ToTable(DbTableName);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("GMT_SW_MCN_TYP_ID");

        builder.Property(e => e.Code)
            .HasMaxLength(SewingMachineTypeCodeMaxLength)
            .HasColumnName("SW_MCN_TYP_CODE")
            .IsUnicode(false);

        builder.Property(e => e.EnglishName)
            .HasMaxLength(SewingMachineTypeNameEnglishMaxLength)
            .HasColumnName("SW_MCN_TYP_NAME_EN")
            .IsUnicode(false);

        builder.Property(e => e.BengaliName)
            .HasMaxLength(SewingMachineTypeNameBengaliMaxLength)
            .HasColumnName("SW_MCN_TYP_NAME_BN")
            .IsUnicode();

        builder.Property(e => e.ShortName)
            .HasMaxLength(SewingMachineTypeNameSNameMaxLength)
            .HasColumnName("SW_MCN_TYP_SNAME")
            .IsUnicode(false);

        builder.Property(e => e.DisplayOrder)
            .HasColumnName("DISPLAY_ORDER");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");
    }
}