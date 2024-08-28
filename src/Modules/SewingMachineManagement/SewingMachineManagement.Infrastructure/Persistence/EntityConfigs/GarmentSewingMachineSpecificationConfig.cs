using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineSpecificationEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineSpecificationConfig : IEntityTypeConfiguration<GarmentSewingMachineSpecification>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineSpecification> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GMT_SW_MCN_SPEC_ID")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.GarmentSewingMachineTypeId)
            .HasColumnName("GMT_SW_MCN_TYP_ID");

        builder.Property(x => x.GarmentSewingMachineBedTypeId)
            .HasColumnName("GMT_SM_BED_TYP_ID");

        builder.Property(x => x.GarmentStitchTypeId)
            .HasColumnName("GMT_STCH_TYP_ID");

        builder.Property(x => x.GarmentSewingMachineApplicationTypeId)
            .HasColumnName("GMT_SW_APP_TYP_ID");

        builder.Property(x => x.Description)
            .IsUnicode(false)
            .HasMaxLength(DescriptionMaxLength)
            .HasColumnName("SW_MCN_SPEC_DESC");

        builder.Property(x => x.NeedleCount)
            .HasColumnName("NDL_COUNT");

        builder.Property(x => x.StandardRotationPerMinute)
            .HasColumnName("STD_RPM");

        builder.Property(x => x.StandardStitchPerInch)
            .HasColumnName("STD_SPI");

        builder.Property(x => x.ThreadCount)
            .HasColumnName("THRD_COUNT");

        builder.Property(x => x.LookupThreadTrimTypeId)
            .HasColumnName("LK_THRD_TRIM_TYP_ID");

        builder
            .HasOne<GarmentSewingMachineType>()
            .WithMany()
            .HasForeignKey(x => x.GarmentSewingMachineTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<GarmentSewingMachineApplicationType>()
            .WithMany()
            .HasForeignKey(x => x.GarmentSewingMachineApplicationTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<GarmentStitchType>()
            .WithMany()
            .HasForeignKey(x => x.GarmentStitchTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne<GarmentSewingMachineBedType>()
            .WithMany()
            .HasForeignKey(x => x.GarmentSewingMachineBedTypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne<LookupTable>()
            .WithMany()
            .HasForeignKey(x => x.LookupThreadTrimTypeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}