using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configuration;

/// <summary>
/// Configuration for the StaffShift entity in the Airport system.
/// </summary>
public class StaffShiftConfiguration : IEntityTypeConfiguration<StaffShift>
{
    /// <summary>
    /// Implements the Configure method for StaffShift entity.
    /// </summary>
    public void Configure(EntityTypeBuilder<StaffShift> builder)
    {
        /// <summary>
        /// Configures the primary key.
        /// </summary>
        builder.HasKey(ss => ss.Id);

        /// <summary>
        /// Configures StartTime and EndTime as required.
        /// </summary>
        builder.Property(ss => ss.StartTime).IsRequired();
        builder.Property(ss => ss.EndTime).IsRequired();

        /// <summary>
        /// Defines the relationship with AirportStaff.
        /// </summary>
        builder.HasOne(ss => ss.AirportStaff)
            .WithMany(s => s.StaffShifts)
            .HasForeignKey(ss => ss.StaffID)
            .OnDelete(DeleteBehavior.Cascade);

        /// <summary>
        /// Defines optional relationship with SecurityCheckpoint.
        /// </summary>
        builder.HasOne(ss => ss.AssignedCheckpoint)
            .WithMany(sc => sc.AssignedShifts)
            .HasForeignKey(ss => ss.AssignedCheckpointID)
            .OnDelete(DeleteBehavior.Restrict);

        /// <summary>
        /// Defines optional relationship with CustomsDesk.
        /// </summary>
        builder.HasOne(ss => ss.AssignedDesk)
            .WithMany(cd => cd.AssignedShifts)
            .HasForeignKey(ss => ss.AssignedDeskID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
