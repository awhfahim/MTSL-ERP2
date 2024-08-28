using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SewingMachineManagement.Domain;
using SewingMachineManagement.Domain.Entities;
using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Infrastructure.Persistence;

public class SewingMachineManagementDbContext(DbContextOptions<SewingMachineManagementDbContext> options)
    : DbContext(options)
{
    public DbSet<GarmentSewingMachineBedType> GarmentSewingMachineTypes
        => Set<GarmentSewingMachineBedType>();

    public DbSet<GarmentSewingMachineSpecification> GarmentSewingMachineSpecifications
        => Set<GarmentSewingMachineSpecification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(InfrastructureConstants.DbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SewingMachineManagementDbContext).Assembly);

        if (!Database.IsOracle())
        {
            return;
        }

        modelBuilder.Entity<LookupData>()
            .Property(x => x.ParameterValue)
            .HasColumnType("NUMBER(9,2)");

        modelBuilder.Entity<GarmentSewingMachineThreadConsumption>()
            .Property(x => x.PercentageConsumption)
            .HasColumnType("NUMBER(6,2)");

        modelBuilder.Entity<GarmentSewingMachineThreadConsumption>()
            .Property(x => x.Consumption)
            .HasColumnType("NUMBER(9,4)");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IVersioning).IsAssignableFrom(entityType.ClrType))
            {
                var versionNoProperty = entityType.FindProperty(nameof(IVersioning.VersionNumber));
                versionNoProperty?.SetColumnName("VERSION_NO");
            }

            if (typeof(IUpdateAudit).IsAssignableFrom(entityType.ClrType))
            {
                var lastUpdateDateProperty = entityType.FindProperty(nameof(IUpdateAudit.LastUpdateDate));
                var lastUpdatedByProperty = entityType.FindProperty(nameof(IUpdateAudit.LastUpdatedBy));

                lastUpdateDateProperty?.SetColumnName("LAST_UPDATE_DATE");
                lastUpdatedByProperty?.SetColumnName("LAST_UPDATED_BY");

                if (lastUpdatedByProperty?.ClrType == typeof(Guid) ||
                    lastUpdatedByProperty?.ClrType == typeof(Guid?))
                {
                    lastUpdatedByProperty.SetColumnType("VARCHAR2(36)");
                    lastUpdatedByProperty.SetValueConverter(new GuidToStringConverter());
                }
            }

            if (typeof(ICreateAudit).IsAssignableFrom(entityType.ClrType))
            {
                var createdByProperty = entityType.FindProperty(nameof(ICreateAudit.CreatedBy));
                var creationDateProperty = entityType.FindProperty(nameof(ICreateAudit.CreationDate));

                if (createdByProperty?.ClrType == typeof(Guid) ||
                    createdByProperty?.ClrType == typeof(Guid?))
                {
                    createdByProperty.SetColumnType("VARCHAR2(36)");
                    createdByProperty.SetValueConverter(new GuidToStringConverter());
                }

                createdByProperty?.SetColumnName("CREATED_BY");
                creationDateProperty?.SetColumnName("CREATION_DATE");
            }

            if (typeof(IStatusAudit).IsAssignableFrom(entityType.ClrType))
            {
                var isActiveProperty = entityType.FindProperty(nameof(IStatusAudit.IsActive));
                isActiveProperty?.SetColumnName("IS_ACTIVE");
            }
        }
    }
}
