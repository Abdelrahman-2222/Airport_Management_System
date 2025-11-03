using Airplane_UI.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.LuggageMaintnance;
/// <summary>
/// Configuration for the Baggage Claim entity in the Airplane.
/// </summary>
public class BaggageClaimConfiguration : IEntityTypeConfiguration<BaggageClaim>
{
    /// <summary>
    /// implement the Configure Method to add Configure.
    /// </summary>
    public void Configure(EntityTypeBuilder<BaggageClaim> builder)
    {
        /// <summary>
        /// Configures the primary key for the Baggage Claim entity.
        /// </summary>
        builder.HasKey(bc => bc.Id);

        /// <summary>
        /// Configures the CarouselNumber property as required with a maximum length of 5.
        /// </summary>
        builder.Property(bc => bc.CarouselNumber).IsRequired().HasMaxLength(5);

        /// <summary>
        /// Configures the Status property as required and converts its value to a string for storage.
        /// </summary>
        builder.Property(bc => bc.Status).IsRequired().HasConversion<string>();


    }
    
}
