using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineThreadConsumptionEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineThreadConsumptionConfig :
    IEntityTypeConfiguration<GarmentSewingMachineThreadConsumption>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineThreadConsumption> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GMT_SM_THRD_CONS_ID")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.GarmentSewingMachineSpecificationId)
            .HasColumnName("GMT_SW_MCN_SPEC_ID");

        builder.Property(x => x.LookupThreadTypeId)
            .HasColumnName("LK_THRD_TYPE_ID");

        builder.Property(x => x.ThreadCount)
            .HasColumnName("THRD_COUNT");

        builder.Property(x => x.Consumption)
            .HasColumnName("THRD_CONS")
            .HasPrecision(9, 4);

        builder.Property(x => x.ConsumptionMeasurementOfUnitId)
            .HasColumnName("CONS_MOU_ID");

        builder.Property(x => x.PercentageConsumption)
            .HasColumnName("PCT_CONS")
            .HasPrecision(6, 2);

        builder
            .HasOne<ReferenceMeasurementOfUnit>()
            .WithMany()
            .HasForeignKey(x => x.ConsumptionMeasurementOfUnitId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<GarmentSewingMachineSpecification>()
            .WithMany()
            .HasForeignKey(x => x.GarmentSewingMachineSpecificationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}