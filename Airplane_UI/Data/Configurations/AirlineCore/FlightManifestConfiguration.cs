using Airplane_UI.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the FlightManifest entity 
    /// using the Entity Framework Fluent API.
    /// </summary>
    public class FlightManifestConfiguration : IEntityTypeConfiguration<FlightManifest>
    {
        /// <summary>
        /// Configures the database mapping, property constraints, 
        /// and relationships for the FlightManifest entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<FlightManifest> builder)
        {
            /// <summary>
            /// Sets the primary key for the FlightManifest entity.
            /// </summary>
            builder.HasKey(fm => fm.Id);

            /// <summary>
            /// Configures the SeatNumber property with a maximum length of 4 characters.
            /// </summary>
            builder.Property(fm => fm.SeatNumber)
                .HasMaxLength(4);



            /// <summary>
            /// Configures the one-to-many relationship between Flight and FlightManifest.
            /// Deleting a flight will automatically delete related manifests (cascade delete).
            /// </summary>
            builder.HasOne(fm => fm.Flight)
                .WithMany(f => f.FlightManifests)
                .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Configures the one-to-many relationship between Passenger and FlightManifest.
            /// Deleting a passenger who appears on a manifest is restricted.
            /// </summary>
            builder.HasOne(fm => fm.Passenger)
                   .WithMany(p => p.FlightManifests)
                   .HasForeignKey(fm => fm.PassengerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}