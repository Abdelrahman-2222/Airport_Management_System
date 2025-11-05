using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for retrieving detailed information about a catering order.
/// </summary>
public class GetCateringOrderDTO
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
    /// the related catering facility details associated with the order.
    /// </summary>
    public GetCateringFacilitiesDTO CateringFacilitiesDTO { get; set; }
}
