namespace Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for get GetCateringFacilitiesDTO records.
/// </summary>
public class GetCateringFacilitiesDTO
{
    /// <summary>
    /// Initializes a new instance of the CateringFacilities class and sets up the CateringOrders collection.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the catering service provider.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Contact information for the catering service provider.
    /// </summary>
    public string ContactInfo { get; set; }
}
