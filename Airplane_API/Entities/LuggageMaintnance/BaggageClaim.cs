using Airplane_API.Entities.Base;
using Airplane_API.Entities.GateAssignments;
using Airplane_API.Enums;

namespace Airplane_API.Entities.LuggageMaintnance;
/// <summary>
/// Represents an BaggageClaim in the Airplane. 
/// </summary>
public class BaggageClaim : BaseEntity
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

    /// <summary>
    /// Navigation property for the Terminal who received the Terminal.
    /// </summary>
    public virtual Terminal Terminal { get; set; }
}
