using Airplane_API.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.LuggageMaintnance;
/// <summary>
/// Configures the entity mapping and relationships for the MaintenanceLog entity.
/// </summary>
public class MaintenanceLogConfiguration : IEntityTypeConfiguration<MaintenanceLog>
{
    /// <summary>
    /// Configures the MaintenanceLog entity properties, keys, and relationships.
    /// </summary>
    public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
    {
        /// <summary>
        /// Sets the primary key for the MaintenanceLog entity.
        /// </summary>
        builder.HasKey(ml => ml.Id);
        /// <summary>
        /// Configures the Status property as required and converts it to a string for storage.
        /// </summary>
        builder.Property(ml => ml.Status).IsRequired().HasConversion<string>();

        /// <summary>
        /// Configures the relationship between MaintenanceLog and MaintenanceTask with a restricted delete behavior.
        /// </summary>
        builder.HasOne(ml => ml.MaintenanceTask)
            .WithMany(mt => mt.MaintenanceLogs)
            .HasForeignKey(ml => ml.MaintenanceTaskId)
            .OnDelete(DeleteBehavior.Restrict);

        /// <summary>
        /// Configures the relationship between MaintenanceLog and Aircraft with a restricted delete behavior.
        /// </summary>
        builder.HasOne(ml => ml.Aircraft)
            .WithMany(a => a.MaintenanceLogs)
            .HasForeignKey(ml => ml.AircraftId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
