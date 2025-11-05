using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
/// <summary>
/// Data transfer object for retrieving baggage claim information,
/// </summary>
public class CreateAndUpdateBaggageClaimDto
{
    /// <summary>
    /// Gets or sets the Carousel Number of the Baggage Claim.
    /// </summary>
    public string CarouselNumber { get; set; }
    /// <summary>
    /// Gets or sets the Status of the Baggage Claim.
    /// </summary>
    public BaggageClaimStatus Status { get; set; }

    /// <summary>
    /// The ID of the Terminal that Terminaled the Baggage Claim.
    /// </summary>
    public int TerminalId { get; set; }
}
