using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Provides services for managing catering facilities, including creation, retrieval, updating, and deletion operations.
/// </summary>
public class CateringFacilitiesService : ICateringFacilitiesService
{
    /// <summary>
    /// The database context used to access and manage catering facilities data.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    /// <summary>
    /// Initializes a new instance of the CateringFacilitiesService class.
    /// </summary>
    /// <param name="context">The database context used for data access operations.</param>
    public CateringFacilitiesService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    /// <inheritdoc/>
    public async Task<IList<GetCateringFacilitiesDTO>> GetAllAsync()
    {
        var result = await _context.CateringFacilities.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetCateringFacilitiesDTO> GetByIdAsync(int cateringFacilitieId)
    {
        var result = await _context.CateringFacilities.Where(b => b.Id == cateringFacilitieId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetCateringFacilitiesDTO> CreateAsync(CreateAndUpdateCateringFacilitiesDTO dto)
    {
        var cateringFacilitiesEntity = dto.ToEntity();

        var response = await _context.CateringFacilities.AddAsync(cateringFacilitiesEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = cateringFacilitiesEntity.ToDto();
        return result;
    }
    /// <inheritdoc/>
    public async Task<GetCateringFacilitiesDTO> UpdateAsync(int cateringFacilitieId, CreateAndUpdateCateringFacilitiesDTO dto)
    {
        if (cateringFacilitieId < 0)
        {
            return null;
        }
        var existingCateringFacilitie = await _context.CateringFacilities.FindAsync(cateringFacilitieId);
        if (existingCateringFacilitie == null)
        {
            return null;
        }
        var updateBaggageClaimEntity = existingCateringFacilitie.ToEntity();
        if (updateBaggageClaimEntity == null)
        {
            return null;
        }

        dto.UpdateEntity(existingCateringFacilitie);
        await _context.SaveChangesAsync();

        return existingCateringFacilitie.ToDto();
    }
    /// <inheritdoc/>
    public async Task<string> DeleteAsync(int cateringFacilitieId)
    {
        if (cateringFacilitieId < 0)
        {
            return "Invalid Id";
        }
        var cateringFacilitie = await _context.CateringFacilities.FindAsync(cateringFacilitieId);
        if (cateringFacilitie == null)
        {
            return null;
        }
        _context.CateringFacilities.Remove(cateringFacilitie);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{cateringFacilitieId} is Deleted successfully";
    }
}
