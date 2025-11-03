using Airplane_API.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.LuggageMaintnance;
/// <summary>
/// Configures the entity mapping and relationships for the CateringFacilities entity.
/// </summary>
public class CateringFacilitiesConfiguration : IEntityTypeConfiguration<CateringFacilities>
{
    /// <summary>
    /// Configures the CateringFacilities entity properties, keys, and relationships.
    /// </summary>
    public void Configure(EntityTypeBuilder<CateringFacilities> builder)
    {
        /// <summary>
        /// Sets the primary key for the CateringFacilities entity.
        /// </summary>
        builder.HasKey(cs => cs.Id);
        /// <summary>
        /// Configures the ProviderName property as required with a maximum length of 100 characters.
        /// </summary>
        builder.Property(cs => cs.ProviderName).IsRequired().HasMaxLength(100);
        /// <summary>
        /// Configures the one-to-many relationship between CateringFacilities and CateringOrders
        /// with restricted delete behavior.
        /// </summary>
        builder.HasMany(cs => cs.CateringOrders)
            .WithOne(co => co.CateringFacilities)
            .HasForeignKey(co => co.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
