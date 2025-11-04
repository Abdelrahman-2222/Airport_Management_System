using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Entities.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;

public class BaggageClaimService : IBaggageClaimService
{
    private readonly AirplaneManagementSystemContext _context;

    public BaggageClaimService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GetBaggageClaimDto>> GetAllAsync()
    {
        return await SelectBaggageClaimDto(_context.BaggageClaims.AsNoTracking()).ToListAsync();
    }

    public async Task<GetBaggageClaimDto> GetByIdAsync(int BaggageId)
    {
        //if(BaggageId < 0)
        //    throw new ArgumentException("Invalid Id", nameof(BaggageId));
        //var baggageClaim = await _context.BaggageClaims
        //    .Include(bc => bc.Terminal)
        //    .SingleAsync(bc => bc.Id == BaggageId);
        //if (baggageClaim == null)
        //    throw new ArgumentException("Not Found baggageClaim", nameof(baggageClaim));

        //return baggageClaim != null ? MapToGetDto(baggageClaim) : null;
        return await SelectBaggageClaimDto(_context.BaggageClaims.AsNoTracking()).FirstOrDefaultAsync(dto => dto.Id == BaggageId);
    }
    public async Task<GetBaggageClaimDto> CreateAsync(CreateBaggageClaimDto dto)
    {
        //var baggageClaimEntity = MapToEntity(dto);

        //_context.BaggageClaims.Add(baggageClaimEntity);
        //await _context.SaveChangesAsync();
        //await _context.Terminals.Entry(baggageClaimEntity.TerminalId).Reference(t => t.Terminal).LoadAsync();

        //return MapToGetDto(baggageClaimEntity);
        var baggageClaimEntity = MapToEntity(dto);

        _context.BaggageClaims.Add(baggageClaimEntity);
        await _context.SaveChangesAsync();

        return await SelectBaggageClaimDto(_context.BaggageClaims.AsNoTracking()).FirstAsync(dto => dto.Id == baggageClaimEntity.Id);
    }

    public async Task<bool> UpdateAsync(int BaggageId, CreateBaggageClaimDto dto)
    {
        var existingClaim = await _context.BaggageClaims.FindAsync(BaggageId);

        if (existingClaim == null)
        {
            return false;
        }

        existingClaim.CarouselNumber = dto.CarouselNumber;
        existingClaim.Status = dto.Status;
        existingClaim.TerminalId = dto.TerminalId;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }
    public async Task<bool> DeleteAsync(int BaggageId)
    {
        if (BaggageId < 0)
            throw new ArgumentException("Invalid Id", nameof(BaggageId));
        var baggageClaim = await _context.BaggageClaims.FindAsync(BaggageId);
        if (baggageClaim == null)
        {
            return false;
        }
        _context.BaggageClaims.Remove(baggageClaim);
        return await _context.SaveChangesAsync() > 0;
    }




    /// <summary>
    /// Manually maps a BaggageClaim entity to a GetBaggageClaimDto.
    /// </summary>
    //private GetBaggageClaimDto MapToGetDto(BaggageClaim entity)
    //{
    //    return new GetBaggageClaimDto
    //    {
    //        CarouselNumber = entity.CarouselNumber,
    //        Status = entity.Status,
    //        TerminalName = entity.Terminal?.Name ?? "N/A"
    //    };
    //}
    /// <summary>
    /// Projects a BaggageClaim entity (with Terminal navigation) directly to a GetBaggageClaimDto.
    /// Used inside IQueryable to avoid loading full entities and the use of 'Include'.
    /// </summary>
    private static IQueryable<GetBaggageClaimDto> SelectBaggageClaimDto(IQueryable<BaggageClaim> claims)
    {
        return claims.Select(bc => new GetBaggageClaimDto
        {
            CarouselNumber = bc.CarouselNumber,
            Status = bc.Status,
            TerminalName = bc.Terminal.Name
        });
    }
    /// <summary>
    /// Manually maps a CreateBaggageClaimDto to a BaggageClaim entity.
    /// </summary>
    //private GetBaggageClaimDto MapToGetEntity(BaggageClaim dto)
    //{
    //    return new GetBaggageClaimDto
    //    {
    //        CarouselNumber = dto.CarouselNumber,
    //        Status = dto.Status,
    //        TerminalName = dto.
    //    };
    //}


    /// <summary>
    /// Manually maps a CreateBaggageClaimDto to a BaggageClaim entity.
    /// </summary>
    private BaggageClaim MapToEntity(CreateBaggageClaimDto dto)
    {
        return new BaggageClaim
        {
            CarouselNumber = dto.CarouselNumber,
            Status = dto.Status,
            TerminalId = dto.TerminalId
        };
    }
    /// <summary>
    /// Manually maps a CreateBaggageClaimDto to a BaggageClaim entity.
    /// </summary>
    //private static BaggageClaim MapToEntity(CreateBaggageClaimDto dto)
    //{
    //    return new BaggageClaim
    //    {
    //        CarouselNumber = dto.CarouselNumber,
    //        Status = dto.Status,
    //        TerminalId = dto.TerminalId
    //    };
    //}
}
