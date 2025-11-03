using Airplane_UI.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.LuggageMaintnance;
/// <summary>
/// Configures the entity mapping for the CateringOrder entity.
/// </summary>
public class CateringOrderConfiguration : IEntityTypeConfiguration<CateringOrder>
{
    /// <summary>
    /// Configures the CateringOrder entity properties and primary key.
    /// </summary>
    public void Configure(EntityTypeBuilder<CateringOrder> builder)
    {
        /// <summary>
        /// Sets the primary key for the CateringOrder entity.
        /// </summary>
        builder.HasKey(co => co.Id);
        /// <summary>
        /// Configures the MealCount property as required.
        /// </summary>
        builder.Property(co => co.MealCount).IsRequired();
        /// <summary>
        /// Configures the Status property as required and converts it to a string for storage.
        /// </summary>
        builder.Property(co => co.Status).IsRequired().HasConversion<string>();
    }
}
