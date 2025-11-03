using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configuration;

/// <summary>
/// Configuration for the SecurityCheckpoint entity in the Airport system.
/// </summary>
public class SecurityCheckpointConfiguration : IEntityTypeConfiguration<SecurityCheckpoint>
{
    /// <summary>
    /// Implements the Configure method to define entity relationships and property settings.
    /// </summary>
    /// <param name="builder">The entity type builder for SecurityCheckpoint.</param>
    public void Configure(EntityTypeBuilder<SecurityCheckpoint> builder)
    {
        /// <summary>
        /// Configures the primary key for the SecurityCheckpoint entity.
        /// </summary>
        builder.HasKey(sc => sc.Id);

        /// <summary>
        /// Configures the Name property as required with a maximum length of 100.
        /// </summary>
        builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(100);

        /// <summary>
        /// Configures the Status property as required with a maximum length of 50.
        /// </summary>
        builder.Property(sc => sc.Status)
            .IsRequired()
            .HasMaxLength(50);

        /// <summary>
        /// Defines the relationship between SecurityCheckpoint and Terminal.
        /// </summary>
        builder.HasOne(sc => sc.Terminal)
            .WithMany(t => t.SecurityCheckpoints)
            .HasForeignKey(sc => sc.TerminalID)
            .OnDelete(DeleteBehavior.Cascade);

        /// <summary>
        /// Defines the relationship between SecurityCheckpoint and CheckpointLogs.
        /// </summary>
        builder.HasMany(sc => sc.CheckpointLogs)
            .WithOne(cl => cl.SecurityCheckpoint)
            .HasForeignKey(cl => cl.CheckpointID)
            .OnDelete(DeleteBehavior.Cascade);

        /// <summary>
        /// Defines the relationship between SecurityCheckpoint and AssignedShifts.
        /// </summary>
        builder.HasMany(sc => sc.AssignedShifts)
            .WithOne(ss => ss.AssignedCheckpoint)
            .HasForeignKey(ss => ss.AssignedCheckpointID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
