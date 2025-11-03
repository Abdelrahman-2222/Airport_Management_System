using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configuration;

/// <summary>
/// Configuration for the SecurityIncident entity in the Airport system.
/// </summary>
public class SecurityIncidentConfiguration : IEntityTypeConfiguration<SecurityIncident>
{
    /// <summary>
    /// Implements the Configure method for SecurityIncident entity.
    /// </summary>
    public void Configure(EntityTypeBuilder<SecurityIncident> builder)
    {
        /// <summary>
        /// Configures the primary key.
        /// </summary>
        builder.HasKey(si => si.Id);

        /// <summary>
        /// Configures Location property as required with max length 100.
        /// </summary>
        builder.Property(si => si.Location)
            .IsRequired()
            .HasMaxLength(100);

        /// <summary>
        /// Configures Severity property as required with max length 20.
        /// </summary>
        builder.Property(si => si.Severity)
            .IsRequired()
            .HasMaxLength(20);

        /// <summary>
        /// Configures ReportDetails property as required.
        /// </summary>
        builder.Property(si => si.ReportDetails)
            .IsRequired();

        /// <summary>
        /// Defines optional relationship with AirportStaff.
        /// </summary>
        builder.HasOne(si => si.AssignedStaff)
            .WithMany(s => s.SecurityIncidentsHandled)
            .HasForeignKey(si => si.AssignedStaffID)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
