using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;


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
    /// <summary>
    /// Initializes a new instance of the BaggageClaimService class.
    /// </summary>
    /// <param name="context">The database context for the airplane management system.</param>
    public BaggageClaimService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Retrieves all baggage claim records asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a list of baggage claim DTOs.</returns>
    public async Task<IList<GetBaggageClaimDto>> GetAllAsync()
    {
        var result = await _context.BaggageClaims.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    /// <summary>
    /// Retrieves a baggage claim record by its unique identifier.
    /// </summary>
    /// <param name="BaggageId">The unique identifier of the baggage claim.</param>
    /// <returns>A task representing the asynchronous operation that returns a baggage claim DTO if found; otherwise, null.</returns>
    public async Task<GetBaggageClaimDto> GetByIdAsync(int BaggageId)
    {
        var result = await _context.BaggageClaims.Where(b => b.Id == BaggageId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    /// <summary>
    /// Creates a new baggage claim record asynchronously.
    /// </summary>
    /// <param name="dto">The data transfer object containing details for the new baggage claim.</param>
    /// <returns>A task representing the asynchronous operation that returns the created baggage claim DTO.</returns>
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
    /// <summary>
    /// Updates an existing baggage claim record asynchronously.
    /// </summary>
    /// <param name="BaggageId">The unique identifier of the baggage claim to update.</param>
    /// <param name="dto">The data transfer object containing updated baggage claim details.</param>
    /// <returns>A task representing the asynchronous operation that returns the updated baggage claim DTO if successful; otherwise, null.</returns>
    public async Task<GetBaggageClaimDto> UpdateAsync(int BaggageId, CreateAndUpdateBaggageClaimDto dto)
    {
        if (BaggageId < 0)
        {
            return null;
        }
        var existingClaim = await _context.BaggageClaims.FindAsync(BaggageId);
        if (existingClaim == null || existingClaim.Terminal.Id != dto.TerminalId)
        {
            return null;
        }
        var updateBaggageClaimEntity = dto.ToEntity();
        if (updateBaggageClaimEntity == null)
        {
            return null;
        }
        var result = existingClaim.ToDto();
        return result;
    }
    /// <summary>
    /// Deletes a baggage claim record asynchronously by its unique identifier.
    /// </summary>
    /// <param name="BaggageId">The unique identifier of the baggage claim to delete.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns a message confirming deletion,
    /// or null if the operation fails.
    /// </returns>
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
