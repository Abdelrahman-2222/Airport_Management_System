using Airplane_API.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.LuggageMaintnance;

/// <summary>
/// Configures the entity mapping for the LostAndFound model.
/// </summary>
public class LostAndFoundConfiguration : IEntityTypeConfiguration<LostAndFound>
{
    /// <summary>
    /// Configures the LostAndFound entity properties and relationships.
    /// </summary>
    public void Configure(EntityTypeBuilder<LostAndFound> builder)
    {
        /// <summary>
        /// Configures the LostAndFound entity with key.
        /// </summary>
        builder.HasKey(lf => lf.Id);
        /// <summary>
        /// Configures the ItemDescription property as required.
        /// </summary>
        builder.Property(lf => lf.ItemDescription).IsRequired();
        /// <summary>
        /// Configures the DateFound property as required.
        /// </summary>
        builder.Property(lf => lf.DateFound).IsRequired();
        /// <summary>
        /// Configures the Status property as required and converts its value to a string for storage.
        /// </summary>
        builder.Property(lf => lf.Status).IsRequired().HasConversion<string>();
    }
}
