using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configuration;

/// <summary>
/// Configuration for the AirportStaff entity in the Airport system.
/// </summary>
public class AirportStaffConfiguration : IEntityTypeConfiguration<AirportStaff>
{
    /// <summary>
    /// Implements the Configure method for AirportStaff entity.
    /// </summary>
    public void Configure(EntityTypeBuilder<AirportStaff> builder)
    {
        /// <summary>
        /// Configures the primary key.
        /// </summary>
        builder.HasKey(s => s.Id);

        /// <summary>
        /// Configures Name property as required with a maximum length of 100.
        /// </summary>
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        /// <summary>
        /// Configures Role property as required with a maximum length of 50.
        /// </summary>
        builder.Property(s => s.Role)
            .IsRequired()
            .HasMaxLength(50);

        /// <summary>
        /// Defines one-to-many relationship with StaffShifts.
        /// </summary>
        builder.HasMany(s => s.StaffShifts)
            .WithOne(ss => ss.AirportStaff)
            .HasForeignKey(ss => ss.StaffID)
            .OnDelete(DeleteBehavior.Restrict);

        /// <summary>
        /// Defines one-to-many relationship with SecurityIncidentsHandled.
        /// </summary>
        builder.HasMany(s => s.SecurityIncidentsHandled)
            .WithOne(si => si.AssignedStaff)
            .HasForeignKey(si => si.AssignedStaffID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
