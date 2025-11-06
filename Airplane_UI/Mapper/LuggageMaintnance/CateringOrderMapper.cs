using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Airplane_UI.Entities.LuggageMaintnance;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Provides mapping extension methods for converting between
/// CateringOrder entities and their corresponding DTOs.
/// </summary>
public static class CateringOrderMapper
{
    /// <summary>
    /// Converts a CateringOrder entity into a GetCateringOrderDTO
    /// </summary>
    /// <param name="claims">The catering order entity to convert.</param>
    /// <returns>A GetCateringOrderDTO containing the mapped data.</returns>
    public static GetCateringOrderDTO ToDto(this CateringOrder claims)
    {
        var result = new GetCateringOrderDTO
        {
            Id = claims.Id,
            Status = claims.Status,
            CateringFacilitiesDTO = new GetCateringFacilitiesDTO
            {
                Id = claims.CateringFacilities.Id,
                Name = claims.CateringFacilities.Name,
                ContactInfo = claims.CateringFacilities.ContactInfo
            },
            MealCount = claims.MealCount,
        };
        return result;
    }
    /// <summary>
    /// Converts a GetCateringOrderDTO into a CateringOrder entity.
    /// </summary>
    /// <param name="claims">The DTO containing catering order information.</param>
    /// <returns>A CateringOrder entity created from the DTO data.</returns>
    public static CateringOrder ToEntity(this GetCateringOrderDTO claims)
    {
        var result = new CateringOrder
        {
            Id = claims.Id,
            Status = claims.Status,
            MealCount = claims.MealCount,
            CateringFacilities = new CateringFacilities
            {
                Id = claims.CateringFacilitiesDTO.Id,
                Name = claims.CateringFacilitiesDTO.Name,
                ContactInfo = claims.CateringFacilitiesDTO.ContactInfo
            }

        };
        return result;
    }
    /// <summary>
    /// Converts a CreateAndUpdateCateringOrderDTO into a CateringOrder entity for creation or update operations.
    /// </summary>
    /// <param name="dto">The DTO containing data for creating or updating a catering order.</param>
    /// <returns>A CateringOrder entity populated with the provided data.</returns>
    public static CateringOrder ToEntity(this CreateAndUpdateCateringOrderDTO dto)
    {
        return new CateringOrder
        {
            FlightId = dto.FlightId,
            Status = dto.Status,
            ServiceId = dto.ServiceId,
            MealCount = dto.MealCount,

        };
    }
}
