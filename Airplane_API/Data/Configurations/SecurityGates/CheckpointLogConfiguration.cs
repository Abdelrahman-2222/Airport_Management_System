using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configuration.SecurityServices;


/// <summary>
/// Configuration for the CheckpointLog entity in the Airport system.
/// </summary>
public class CheckpointLogConfiguration : IEntityTypeConfiguration<CheckpointLog>
{
/// <summary>
/// Implements the Configure method for CheckpointLog entity.
/// </summary>
/// <param name="builder">The entity type builder for CheckpointLog.</param>
public void Configure(EntityTypeBuilder<CheckpointLog> builder)
{
    /// <summary>
    /// Configures the primary key for the CheckpointLog entity.
    /// </summary>
    builder.HasKey(cl => cl.Id);

    /// <summary>
    /// Configures the Timestamp property as required.
    /// </summary>
    builder.Property(cl => cl.Timestamp)
        .IsRequired();

    /// <summary>
    /// Configures the ReportedWaitTime property as required.
    /// </summary>
    builder.Property(cl => cl.ReportedWaitTime)
        .IsRequired();

    /// <summary>
    /// Defines the relationship between CheckpointLog and SecurityCheckpoint.
    /// </summary>
    builder.HasOne(cl => cl.SecurityCheckpoint)
        .WithMany(sc => sc.CheckpointLogs)
        .HasForeignKey(cl => cl.CheckpointID)
        .OnDelete(DeleteBehavior.Cascade);
}
}