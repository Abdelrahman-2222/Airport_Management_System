using Airplane_API.Entities.AirlineCore;
using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.LuggageMaintnance;
/// <summary>
/// Represents a catering order associated with a specific flight and catering facility,
/// </summary>
public class CateringOrder : IBaseEntity
{
    public int Id { get; set; }
    /// <summary>
    /// The number of meals included in the catering order.
    /// </summary>
    public int MealCount { get; set; }
    /// <summary>
    /// The current status of the catering order.
    /// </summary>
    public CateringStatus Status { get; set; }
    /// <summary>
    /// The identifier of the associated flight.
    /// </summary>
    public int FlightId { get; set; }
    /// <summary>
    /// The flight associated with this catering order.
    /// </summary>
    public virtual Flight Flight { get; set; }
    /// <summary>
    /// The identifier of the associated catering facility.
    /// </summary>
    public int ServiceId { get; set; }
    /// <summary>
    /// The catering facility that provides this order.
    /// </summary>
    public virtual CateringFacilities CateringFacilities { get; set; }
}
