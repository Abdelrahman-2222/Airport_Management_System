using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
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
            DateFound = claims.DateFound,
            ItemDescription = claims.ItemDescription,
            Status = claims.Status.ToString(),
        };
        return result;
    }

    /// <summary>
    /// Projects a BaggageClaim entity (with Terminal navigation) directly to a GetBaggageClaimDto.
    /// Used inside IQueryable to avoid loading full entities and the use of 'Include'.
    /// </summary>
    public static LostAndFound ToEntity(this GetLostAndFoundDTO claims)
    {
        var result = new LostAndFound
        {
            DateFound = claims.DateFound, 
            ItemDescription = claims.ItemDescription,
            Status = Enum.Parse<LostAndFoundStatus>(claims.Status, true)
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
}
