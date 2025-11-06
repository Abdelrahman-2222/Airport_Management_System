using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
/// <summary>
/// Data transfer object for retrieving baggage claim information,
/// </summary>
public class GetBaggageClaimDto
{
    /// <summary>
    /// Initializes a new instance of the GetBaggageClaimDto class and sets up the CateringOrders collection.
    /// </summary>
    public int Id { get; set; } 
    /// <summary>
    /// The number of the baggage carousel.
    /// </summary>
    public string CarouselNumber { get; set; }
    /// <summary>
    /// The current status of the baggage claim.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// The name or identifier of the terminal associated with the baggage claim.
    /// </summary>
    public string TerminalName { get; set; }
}
