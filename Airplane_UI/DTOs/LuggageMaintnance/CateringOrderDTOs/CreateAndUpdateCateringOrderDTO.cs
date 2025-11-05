using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for creating or updating catering order records.
/// </summary>
public class CreateAndUpdateCateringOrderDTO
{
    /// <summary>
    /// the number of meals included in the catering order.
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
    /// The identifier of the associated catering facility.
    /// </summary>
    public int ServiceId { get; set; }
}
