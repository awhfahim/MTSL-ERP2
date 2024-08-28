using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineGuideTypeEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineGuideTypeConfig : IEntityTypeConfiguration<GarmentSewingMachineGuideType>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineGuideType> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("GMT_SM_GUIDE_TYP_ID");

        builder.Property(e => e.Code)
            .HasColumnName("SM_GUIDE_TYP_CODE")
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false);

        builder.Property(e => e.EnglishName)
            .HasColumnName("SM_GUIDE_TYP_NAME_EN")
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false);

        builder.Property(e => e.BengaliName)
            .HasColumnName("SM_GUIDE_TYP_NAME_BN")
            .HasMaxLength(BengaliNameMaxLength)
            .IsUnicode();

        builder.Property(e => e.ShortName)
            .HasColumnName("SM_GUIDE_TYP_SNAME")
            .HasMaxLength(ShortNameMaxLength)
            .IsUnicode(false);

        builder.Property(e => e.DisplayOrder)
            .HasColumnName("DISPLAY_ORDER");
    }
}