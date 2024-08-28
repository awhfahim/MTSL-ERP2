using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.ReferenceMeasurementOfUnitEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class ReferenceMeasurementOfUnitConfig : IEntityTypeConfiguration<ReferenceMeasurementOfUnit>
{
    public void Configure(EntityTypeBuilder<ReferenceMeasurementOfUnit> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("RF_MOU_ID");

        builder.Property(e => e.Code)
            .HasMaxLength(CodeMaxLength)
            .IsUnicode(false)
            .HasColumnName("MOU_CODE");

        builder.Property(e => e.EnglishName)
            .HasMaxLength(EnglishNameMaxLength)
            .IsUnicode(false)
            .HasColumnName("MOU_NAME_EN");

        builder.Property(e => e.BengaliName)
            .HasMaxLength(BengaliNameMaxLength)
            .IsUnicode()
            .HasColumnName("MOU_NAME_BN");

        builder.Property(e => e.DecimalValue)
            .HasColumnName("DECIMAL_VAL");

        builder.Property(e => e.ParameterValue)
            .HasColumnName("PARAM_VAL_1");
    }
}