using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.Entities.LuggageMaintnance;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Provides mapping functionality between CateringFacilities entities and their corresponding DTOs.
/// </summary>
public static class CateringFacilitiesMapper
{
    /// <summary>
    /// Converts a CateringFacilities entity into a GetCateringFacilitiesDTO
    /// </summary>
    /// <param name="claims">The CateringFacilities entity to convert.</param>
    /// <returns>
    /// A new GetCateringFacilitiesDTO object containing the mapped data.
    /// </returns>
    public static GetCateringFacilitiesDTO ToDto(this CateringFacilities claims)
    {
        var result = new GetCateringFacilitiesDTO
        {
            ContactInfo = claims.ContactInfo,
            Id = claims.Id,
            Name = claims.Name,
        };
        return result;
    }
    /// <summary>
    /// Converts a GetCateringFacilitiesDTO back into a CateringFacilities entity.
    /// </summary>
    /// <param name="claims">The GetCateringFacilitiesDTO to convert.</param>
    /// <returns>
    /// A new CateringFacilities entity populated with data from the DTO.
    /// </returns>
    public static CateringFacilities ToEntity(this GetCateringFacilitiesDTO claims)
    {
        var result = new CateringFacilities
        {
            Name = claims.Name,
            ContactInfo = claims.ContactInfo,
            Id = claims.Id,
        };
        return result;
    }
    /// <summary>
    /// Converts a CreateAndUpdateCateringFacilitiesDTO into a CateringFacilities entity.
    /// </summary>
    /// <param name="dto">The CreateAndUpdateCateringFacilitiesDTO containing data for creation or update.</param>
    /// <returns>
    /// A new CateringFacilities entity populated with data from the DTO.
    /// </returns>
    public static CateringFacilities ToEntity(this CreateAndUpdateCateringFacilitiesDTO dto)
    {
        return new CateringFacilities
        {
            Name = dto.Name,
            ContactInfo = dto.ContactInfo,
        };
    }
}
