using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configuration;

/// <summary>
/// Configuration for the CustomsDesk entity in the Airport system.
/// </summary>
public class CustomsDeskConfiguration : IEntityTypeConfiguration<CustomsDesk>
{
    /// <summary>
    /// Implements the Configure method for CustomsDesk entity.
    /// </summary>
    public void Configure(EntityTypeBuilder<CustomsDesk> builder)
    {
        /// <summary>
        /// Configures the primary key.
        /// </summary>
        builder.HasKey(cd => cd.Id);

        /// <summary>
        /// Configures DeskNumber as required with max length 10.
        /// </summary>
        builder.Property(cd => cd.DeskNumber)
            .IsRequired()
            .HasMaxLength(10);

        /// <summary>
        /// Configures Status as required with max length 50.
        /// </summary>
        builder.Property(cd => cd.Status)
            .IsRequired()
            .HasMaxLength(50);

        /// <summary>
        /// Defines the relationship between CustomsDesk and Terminal.
        /// </summary>
        builder.HasOne(cd => cd.Terminal)
            .WithMany(t => t.CustomsDesks)
            .HasForeignKey(cd => cd.TerminalID)
            .OnDelete(DeleteBehavior.Restrict);

        /// <summary>
        /// Defines the relationship between CustomsDesk and AssignedShifts.
        /// </summary>
        builder.HasMany(cd => cd.AssignedShifts)
            .WithOne(ss => ss.AssignedDesk)
            .HasForeignKey(ss => ss.AssignedDeskID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
