namespace Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for craete and update CateringFacilitiesDTO records.
/// </summary>
public class CreateAndUpdateCateringFacilitiesDTO
{
    /// <summary>
    /// The name of the catering service provider.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Contact information for the catering service provider.
    /// </summary>
    public string ContactInfo { get; set; }
}
