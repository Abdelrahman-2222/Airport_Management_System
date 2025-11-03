using Airplane_UI.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the Airport entity using the Entity Framework Fluent API.
    /// </summary>
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        /// <summary>
        /// Configures the database mapping for the Airline entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            /// <summary>
            /// Sets the primary key for the Airport entity.
            /// </summary>
            builder.HasKey(a => a.Id);

            /// <summary>
            /// Configures the Airport property as required with a maximum length of 100 characters.
            /// </summary>
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            /// <summary>
            /// Configures the IATA_Code property as required,fixed length of 3 characters, and ensures uniqueness across records.
            /// </summary>
            builder.Property(a => a.IATA_Code)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            ///<summary
            /// uniqueness of the IATA code across all airports.
            ///</summary>
            builder.HasIndex(a => a.IATA_Code).IsUnique();


            /// <summary>
            /// Configures the one-to-many relationship between Airport and Flight (as OriginAirport). 
            /// Deleting an airport will not delete related flights — deletion is restricted to preserve data integrity.
            /// </summary>
            builder.HasMany<Flight>()
                .WithOne(f => f.OriginAirport)
                .HasForeignKey(f => f.OriginAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the one-to-many relationship between Airport and Flight (as DestinationAirport).
            /// Deleting an airport will not delete related flights — deletion is restricted to maintain referential integrity.
            /// </summary>
            builder.HasMany<Flight>()
                .WithOne(f => f.DestinationAirport)
                .HasForeignKey(f => f.DestinationAirportId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
