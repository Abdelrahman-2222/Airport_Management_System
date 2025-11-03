using Airplane_API.Entities.AirlineCore;
using Airplane_API.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the Flight entity using the Entity Framework Fluent API.
    /// </summary>
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        /// <summary>
        /// Configures the database mapping for the Flight entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            /// <summary>
            /// Sets the primary key for the Flight entity.
            /// </summary>
            builder.HasKey(f => f.Id);

            /// <summary>
            /// Configures the FlightNumber property as required with a maximum length of 10 characters.
            /// </summary>
            builder.Property(f => f.FlightNumber)
                .IsRequired()
                .HasMaxLength(10);

            /// <summary>
            /// Configures the Status property as required and stores its value as a string in the database.
            /// </summary>
            builder.Property(f => f.Status)
                .IsRequired()
                .HasConversion<string>();

            /// <summary>
            /// Configures the many-to-one relationship between Flight and Airline.
            /// Deleting an airline will not delete related flights — deletion is restricted to maintain referential integrity.
            /// </summary>
            builder.HasOne(f => f.Airline)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the many-to-one relationship between Flight and OriginAirport.
            /// Deleting an airport will not delete related flights — deletion is restricted.
            /// </summary>
            builder.HasOne(f => f.OriginAirport)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the many-to-one relationship between Flight and DestinationAirport.
            /// Deleting an airport will not delete related flights — deletion is restricted.
            /// </summary>
            builder.HasOne(f => f.DestinationAirport)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the many-to-one relationship between Flight and Aircraft.
            /// Deleting an aircraft will not delete related flights — deletion is restricted to preserve flight history.
            /// </summary>
            builder.HasOne(f => f.Aircraft)
                   .WithMany(a => a.Flights) 
                   .HasForeignKey(f => f.AircraftId)
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the one-to-many relationship between Flight and FlightManifest.
            /// Deleting a flight will cascade delete its related manifests.
            /// </summary>
            builder.HasMany(f => f.FlightManifests)
                .WithOne(fm => fm.Flight)
                .HasForeignKey(fm => fm.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Configures the one-to-many relationship between Flight and GateAssignment.
            /// Deleting a flight will cascade delete its related gate assignments.
            /// </summary>
            builder.HasMany(f => f.GateAssignments)
                .WithOne(ga => ga.Flight)
                .HasForeignKey(ga => ga.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Configures the one-to-many relationship between Flight and RunwaySchedule.
            /// Deleting a flight will cascade delete its related runway schedules.
            /// </summary>
            builder.HasMany(f => f.RunwaySchedules)
                .WithOne(rs => rs.Flight)
                .HasForeignKey(rs => rs.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Configures the one-to-one relationship between Flight and CateringOrder.
            /// Deleting a flight will cascade delete its related catering order.
            /// </summary>
            builder.HasOne(f => f.CateringOrder)
                .WithOne(co => co.Flight)
                .HasForeignKey<CateringOrder>(co => co.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
