using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingApplicationTypeEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineApplicationTypeConfig : IEntityTypeConfiguration<GarmentSewingMachineApplicationType>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineApplicationType> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("GMT_SM_APP_TYP_ID");

        builder.Property(e => e.Code)
            .HasMaxLength(CodeMaxLength)
            .HasColumnName("SM_APP_TYP_CODE")
            .IsUnicode(false);

        builder.Property(e => e.EnglishName)
            .HasMaxLength(EnglishNameMaxLength)
            .HasColumnName("SM_APP_TYP_NAME_EN")
            .IsUnicode(false);

        builder.Property(e => e.BengaliName)
            .HasMaxLength(BengaliNameMaxLength)
            .HasColumnName("SM_APP_TYP_NAME_BN");

        builder.Property(e => e.ShortName)
            .HasMaxLength(ShortNameMaxLength)
            .HasColumnName("SM_APP_TYP_SNAME")
            .IsUnicode(false);

        builder.Property(e => e.DisplayOrder)
            .HasColumnName("DISPLAY_ORDER");
        
         
        
    }
}