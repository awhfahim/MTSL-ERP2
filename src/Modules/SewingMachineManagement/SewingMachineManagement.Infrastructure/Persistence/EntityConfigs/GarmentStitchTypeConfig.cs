using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentStitchTypeEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentStitchTypeConfig : IEntityTypeConfiguration<GarmentStitchType>
{
    public void Configure(EntityTypeBuilder<GarmentStitchType> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("GMT_STCH_TYP_ID");

        builder.Property(e => e.Code)
            .HasColumnName("STCH_TYP_CODE")
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false);

        builder.Property(e => e.EnglishName)
            .HasColumnName("STCH_TYP_NAME_EN")
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false);

        builder.Property(e => e.BengaliName)
            .HasColumnName("STCH_TYP_NAME_BN")
            .HasMaxLength(BengaliNameMaxLength);

        builder.Property(e => e.ShortName)
            .HasColumnName("STCH_TYP_SNAME")
            .IsUnicode(false)
            .HasMaxLength(ShortNameMaxLength);

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");
        
    }
}