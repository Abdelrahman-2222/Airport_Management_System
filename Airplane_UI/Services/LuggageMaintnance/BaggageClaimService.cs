using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;


namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Provides implementation for baggage claim service operations such as retrieving,
/// creating, updating, and deleting baggage claim records.
/// </summary>
public class BaggageClaimService : IBaggageClaimService
{
    /// <summary>
    /// The database context used for accessing baggage claim data.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    //private readonly IMapper<BaggageClaim, GetBaggageClaimDto> _mapper;
    /// <summary>
    /// Initializes a new instance of the BaggageClaimService class.
    /// </summary>
    /// <param name="context">The database context for the airplane management system.</param>
    public BaggageClaimService(AirplaneManagementSystemContext context)
    {
        _context = context;
        //_mapper = mapper;
    }
    /// <inheritdoc/>
    public async Task<IList<GetBaggageClaimDto>> GetAllAsync()
    {
        var result = await _context.BaggageClaims.Include(b => b.Terminal).Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetBaggageClaimDto> GetByIdAsync(int BaggageId)
    {
        var result = await _context.BaggageClaims.Where(b => b.Id == BaggageId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetBaggageClaimDto> CreateAsync(CreateAndUpdateBaggageClaimDto dto)
    {
        var baggageClaimEntity = dto.ToEntity();

        var response = await _context.BaggageClaims.AddAsync(baggageClaimEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = baggageClaimEntity.ToDto();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetBaggageClaimDto> UpdateAsync(int BaggageId, CreateAndUpdateBaggageClaimDto dto)
    {
        if (BaggageId < 0)
        {
            return null;
        }
        var existingClaim = await _context.BaggageClaims.FindAsync(BaggageId);
        if (existingClaim == null )
        {
            return null;
        }
        var updateBaggageClaimEntity = dto.ToEntity();
        if (updateBaggageClaimEntity == null)
        {
            return null;
        }
        dto.UpdateEntity(existingClaim);
        await _context.SaveChangesAsync();

        return existingClaim.ToDto();
    }
    /// <inheritdoc/>
    public async Task<string> DeleteAsync(int BaggageId)
    {
        if (BaggageId < 0)
        {
            return "Invalid Id";
        }
        var baggageClaim = await _context.BaggageClaims.FindAsync(BaggageId);
        if (baggageClaim == null)
        {
            return null;
        }
        _context.BaggageClaims.Remove(baggageClaim);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{BaggageId} is Deleted successfully";
    }
}

//public interface IMapper<TEntity, TDto>
//{
//    Expression<Func<TEntity, TDto>> ToDto();
//    Expression<Func<TDto, TEntity>> ToEntity();
//}

//public class BaggageClaimMapper : IMapper<BaggageClaim, GetBaggageClaimDto>
//{
//    public Expression<Func<BaggageClaim, GetBaggageClaimDto>> ToDto()
//    {
//        return claims => new GetBaggageClaimDto
//        {
//            Id = claims.Id,
//            CarouselNumber = claims.CarouselNumber,
//            Status = claims.Status.ToString(),
//            TerminalName = claims.Terminal.Name
//        };
//    }

//    public Expression<Func<GetBaggageClaimDto, BaggageClaim>> ToEntity()
//    {
//        throw new NotImplementedException();
//    }
//}

//public static class extensions
//{
//    public static IServiceCollection RegisterMapping(this IServiceCollection services)
//    {
//        services.AddScoped<IMapper<BaggageClaim, GetBaggageClaimDto>, BaggageClaimMapper>();
//        return services;
//    }
//}
