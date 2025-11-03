using Airplane_UI.Entities.Base;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.LuggageMaintnance;
/// <summary>
/// Represents an BaggageClaim in the Airplane. 
/// </summary>
public class BaggageClaim : IBaseEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }
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
