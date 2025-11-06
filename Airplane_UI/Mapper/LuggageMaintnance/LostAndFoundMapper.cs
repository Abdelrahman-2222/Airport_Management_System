using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Provides mapping extension methods for converting between
/// LostAndFoundMapper entities and their corresponding DTOs.
/// </summary>
public static class LostAndFoundMapper
{
    /// <summary>
    /// Projects a BaggageClaim entity (with Terminal navigation) directly to a GetBaggageClaimDto.
    /// Used inside IQueryable to avoid loading full entities and the use of 'Include'.
    /// </summary>
    public static GetLostAndFoundDTO ToDto(this LostAndFound claims)
    {
        var result = new GetLostAndFoundDTO
        {
            Id = claims.Id,
            DateFound = claims.DateFound,
            ItemDescription = claims.ItemDescription,
            Status = claims.Status.ToString(),
        };
        return result;
    }


    /// <summary>
    /// Manually maps a CreateBaggageClaimDto to a BaggageClaim entity.
    /// </summary>
    public static LostAndFound ToEntity(this CreateAndUpdateLostandFoundDTO dto)
    {
        return new LostAndFound
        {
            DateFound = dto.DateFound,
            ItemDescription = dto.ItemDescription,
            Status =dto.Status,
        };
    }
    /// <summary>
    /// Converts a CreateAndUpdateLostandFoundDTO into a LostAndFound entity.
    /// </summary>
    /// <param name="dto">The CreateAndUpdateLostandFoundDTO containing data for creation or update.</param>
    /// <param name="entity">The LostAndFound entity to convert.</param>
    public static void UpdateEntity(this CreateAndUpdateLostandFoundDTO dto, LostAndFound entity)
    {
        if (entity == null || dto == null) return;

        entity.DateFound = dto.DateFound;
        entity.ItemDescription = dto.ItemDescription;
        entity.Status = dto.Status;
    }
}
