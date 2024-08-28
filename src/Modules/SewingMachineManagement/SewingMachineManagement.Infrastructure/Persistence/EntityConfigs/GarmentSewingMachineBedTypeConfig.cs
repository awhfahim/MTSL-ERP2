using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineBedTypeEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineBedTypeConfig : IEntityTypeConfiguration<GarmentSewingMachineBedType>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineBedType> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("GMT_SM_BED_TYP_ID")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Code)
            .HasColumnName("SM_BED_TYP_CODE")
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false);

        builder.Property(p => p.EnglishName)
            .HasColumnName("SM_BED_TYP_NAME_EN")
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false);

        builder.Property(p => p.BengaliName)
            .HasColumnName("SM_BED_TYP_NAME_BN")
            .HasMaxLength(BengaliNameMaxLength);

        builder.Property(p => p.ShortName)
            .HasColumnName("SM_BED_TYP_SNAME")
            .HasMaxLength(ShortNameMaxLength)
            .IsUnicode(false);

        builder.Property(p => p.DisplayOrder)
            .HasColumnName("DISPLAY_ORDER");

        builder.Property(p => p.IsActive)
            .HasColumnName("IS_ACTIVE");
    }
}