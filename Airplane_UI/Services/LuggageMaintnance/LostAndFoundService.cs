using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Provides implementation for Lost and Found service operations such as retrieving,
/// creating, updating, and deleting Lost and Found records.
/// </summary>
public class LostAndFoundService : ILostAndFoundService
{
    /// <summary>
    /// The database context used for accessing Lost and Found data.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    /// <summary>
    /// Initializes a new instance of the <see cref="LostAndFoundService"/> class.
    /// </summary>
    /// <param name="context">The database context for the airplane management system.</param>
    public LostAndFoundService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    ///<inheritdoc/>
    public async Task<IList<GetLostAndFoundDTO>> GetAllAsync()
    {
        var result = await _context.LostAndFounds.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetLostAndFoundDTO> GetByIdAsync(int loadAndFoundId)
    {
        var result = await _context.LostAndFounds.Where(b => b.Id == loadAndFoundId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetLostAndFoundDTO> CreateAsync(CreateAndUpdateLostandFoundDTO dto)
    {
        var LostAndFoundEntity = dto.ToEntity();

        var response = await _context.LostAndFounds.AddAsync(LostAndFoundEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = LostAndFoundEntity.ToDto();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetLostAndFoundDTO> UpdateAsync(int loadAndFoundId, CreateAndUpdateLostandFoundDTO dto)
    {
        if (loadAndFoundId < 0)
        {
            return null;
        }
        var existingLostAndFound = await _context.LostAndFounds.FindAsync(loadAndFoundId);
        if (existingLostAndFound == null)
        {
            return null;
        }
        var updateLostAndFoundEntity = dto.ToEntity();
        if (updateLostAndFoundEntity == null)
        {
            return null;
        }
        var result = existingLostAndFound.ToDto();
        return result;
    }
    ///<inheritdoc/>
    public async Task<string> DeleteAsync(int loadAndFoundId)
    {
        if (loadAndFoundId < 0)
        {
            return "Invalid Id";
        }
        var loadAndFound = await _context.LostAndFounds.FindAsync(loadAndFoundId);
        if (loadAndFound == null)
        {
            return null;
        }
        _context.LostAndFounds.Remove(loadAndFound);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{loadAndFoundId} is Deleted successfully";
    }

}
