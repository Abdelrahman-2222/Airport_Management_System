using Airplane_UI.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the Airline entity using the Entity Framework Fluent API.
    /// </summary>
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        /// <summary>
        /// Configures the database mapping for the Airline entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            /// <summary>
            /// Sets the primary key for the Airline entity.
            /// </summary>
            builder.HasKey(a => a.Id);

            /// <summary>
            /// Configures the Airline property as required with a maximum length of 100 characters.
            /// </summary>
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            /// <summary>
            /// Configures the IATA_Code property as required, 
            /// fixed length of 3 characters, and ensures uniqueness across records.
            /// </summary>
            builder.Property(a => a.IATA_Code)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            builder.HasIndex(a => a.IATA_Code).IsUnique();

            /// <summary>
            /// Configures the one-to-many relationship between Airline and Flight.
            /// Each airline can have multiple flights, and deleting an airline will not delete related flights.
            /// </summary>
            builder.HasMany<Flight>()
                .WithOne(f => f.Airline)
                .HasForeignKey(f => f.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Configures the one-to-many relationship between Airline and Aircraft.
            /// Each airline can have multiple aircraft, and deleting an airline will not delete related aircraft.
            /// </summary>
            builder.HasMany<Aircraft>()
                .WithOne(ac => ac.Airline)
                .HasForeignKey(ac => ac.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
