using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SewingMachineManagement.Domain.Entities;
using static SewingMachineManagement.Domain.DomainConstants.GarmentSewingMachineGuideEntity;

namespace SewingMachineManagement.Infrastructure.Persistence.EntityConfigs;

public class GarmentSewingMachineGuideConfig : IEntityTypeConfiguration<GarmentSewingMachineGuide>
{
    public void Configure(EntityTypeBuilder<GarmentSewingMachineGuide> builder)
    {
        builder.ToTable(DbTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("GMT_SW_MCN_GUIDE_ID");

        builder.Property(e => e.GarmentSewingMachineSpecificationId)
            .HasColumnName("GMT_SW_MCN_SPEC_ID");

        builder.Property(e => e.Description)
            .HasColumnName("MCN_GUIDE_DESC")
            .IsUnicode(false)
            .HasMaxLength(DescriptionMaxLength);

        builder.Property(e => e.GarmentSewingMachineGuideTypeId)
            .HasColumnName("GMT_SM_GUIDE_TYP_ID");

        builder
            .HasOne<GarmentSewingMachineGuideType>()
            .WithMany()
            .HasForeignKey(x => x.GarmentSewingMachineGuideTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}