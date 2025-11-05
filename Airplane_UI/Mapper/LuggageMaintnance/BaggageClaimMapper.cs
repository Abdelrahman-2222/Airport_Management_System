using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;
using System.Linq.Expressions;
using System.Net.WebSockets;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Mapp BaggageClaim to GetBaggageClaimDto and CreateAndUpdateBaggageClaimDto.
/// </summary>
public static class BaggageClaimMapper
{
    /// <summary>
    /// Projects a BaggageClaim entity (with Terminal navigation) directly to a GetBaggageClaimDto.
    /// Used inside IQueryable to avoid loading full entities and the use of 'Include'.
    /// </summary>
    public static GetBaggageClaimDto ToDto(this BaggageClaim claims)
    {
        var result = new GetBaggageClaimDto
        {
            Id = claims.Id,
            CarouselNumber = claims.CarouselNumber,
            Status = claims.Status.ToString(),
            TerminalName = claims.Terminal.Name
        };
        return result;
    }

    //public static Expression<Func<BaggageClaim, GetBaggageClaimDto>> ToDto()
    //{
    //    return claims => new GetBaggageClaimDto
    //    {
    //        Id = claims.Id,
    //        CarouselNumber = claims.CarouselNumber,
    //        Status = claims.Status.ToString(),
    //        TerminalName = claims.Terminal.Name
    //    };
    //}

    /// <summary>
    /// Projects a BaggageClaim entity (with Terminal navigation) directly to a GetBaggageClaimDto.
    /// Used inside IQueryable to avoid loading full entities and the use of 'Include'.
    /// </summary>
    public static BaggageClaim ToEntity(this GetBaggageClaimDto claims)
    {
        var result = new BaggageClaim
        {
            CarouselNumber = claims.CarouselNumber,
            Status = Enum.Parse<BaggageClaimStatus>(claims.Status, true),
        };
        return result;
    }

    /// <summary>
    /// Manually maps a CreateBaggageClaimDto to a BaggageClaim entity.
    /// </summary>
    public static BaggageClaim ToEntity(this CreateAndUpdateBaggageClaimDto dto)
    {
        return new BaggageClaim
        {
            CarouselNumber = dto.CarouselNumber,
            Status = dto.Status,
            TerminalId = dto.TerminalId
        };
    }
}
