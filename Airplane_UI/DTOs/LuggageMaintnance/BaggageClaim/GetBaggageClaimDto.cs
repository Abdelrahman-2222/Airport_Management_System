using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
/// <summary>
/// Data transfer object for retrieving baggage claim information,
/// </summary>
public class GetBaggageClaimDto
{
    /// <summary>
    /// The number of the baggage carousel.
    /// </summary>
    public string CarouselNumber { get; set; }
    /// <summary>
    /// The current status of the baggage claim.
    /// </summary>
    public BaggageClaimStatus Status { get; set; }
    /// <summary>
    /// The name or identifier of the terminal associated with the baggage claim.
    /// </summary>
    public string TerminalName { get; set; }
}
