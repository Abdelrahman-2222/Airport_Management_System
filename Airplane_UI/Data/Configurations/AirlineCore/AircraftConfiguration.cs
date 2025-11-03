using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.AirlineCore
{
    /// <summary>
    /// Configures the entity mapping for the Aircraft entity using the Entity Framework Fluent API.
    /// </summary>
    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        /// <summary>
        /// Configures the database mapping for the Aircraft entity.
        /// </summary>
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            /// <summary>
            /// Sets the primary key for the Aircraft entity.
            /// </summary>
            builder.HasKey(a => a.Id);

            /// <summary>
            /// Configures the TailNumber property as required with a maximum length of 10 characters
            /// and ensures uniqueness across all aircraft records.
            /// </summary>
            builder.Property(a => a.TailNumber)
                .IsRequired()
                .HasMaxLength(10);

            ///<summary
            /// uniqueness of the TailNumber across all aircrafts.
            ///</summary>
            builder.HasIndex(a => a.TailNumber)
                .IsUnique();

            /// <summary>
            /// Configures the one-to-many relationship between Aircraft and MaintenanceLog.
            /// Deleting an aircraft will not delete related maintenance logs — deletion is restricted to preserve history and traceability.
            /// </summary>
            builder.HasMany<MaintenanceLog>()
                .WithOne(ml => ml.Aircraft)
                .HasForeignKey(ml => ml.AircraftId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
