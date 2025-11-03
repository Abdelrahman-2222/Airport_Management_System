using Airplane_UI.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.LuggageMaintnance;
/// <summary>
/// Configures the entity mapping for the MaintenanceTask entity.
/// </summary>
public class MaintenanceTaskConfiguration : IEntityTypeConfiguration<MaintenanceTask>
{
    /// <summary>
    /// Configures the MaintenanceTask entity properties, keys, and relationships.
    /// </summary>
    public void Configure(EntityTypeBuilder<MaintenanceTask> builder)
    {
        /// <summary>
        /// Sets the primary key for the MaintenanceTask entity.
        /// </summary>
        builder.HasKey(mt => mt.Id);
        /// <summary>
        /// Configures the TaskName property as required with a maximum length of 150 characters.
        /// </summary>
        builder.Property(mt => mt.Name).IsRequired().HasMaxLength(150).HasColumnName("TaskName");
    }
}
