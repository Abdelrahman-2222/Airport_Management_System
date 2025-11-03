using Airplane_API.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the Passenger entity using the Entity Framework Fluent API.
    /// </summary>
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        /// <summary>
        /// Configures the database mapping for the Passenger entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            /// <summary>
            /// Sets the primary key for the Passenger entity.
            /// </summary>
            builder.HasKey(p => p.Id);

            /// <summary>
            /// Configures the FirstName property as required with a maximum length of 100 characters.
            /// </summary>
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            /// <summary>
            /// Configures the LastName property as required 
            /// with a maximum length of 100 characters.
            /// </summary>
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            /// <summary>
            /// Configures the PassportNumber property with a maximum length of 20 characters.
            /// </summary>
            builder.Property(p => p.PassportNumber)
                .HasMaxLength(20);

            /// <summary>
            /// Relationship: Passenger → FlightManifest
            /// Configures the one-to-many relationship between Passenger and FlightManifest.
            /// Deleting a passenger who appears on a manifest is restricted.
            /// </summary>
            builder.HasMany<FlightManifest>()
                .WithOne(fm => fm.Passenger)
                .HasForeignKey(fm => fm.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}