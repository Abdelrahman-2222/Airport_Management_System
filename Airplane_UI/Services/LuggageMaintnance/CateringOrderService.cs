using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Provides services for managing catering orders, including creating, retrieving, updating, and deleting records.
/// </summary>
public class CateringOrderService : ICateringOrderService
{
    /// <summary>
    /// The database context used to interact with the data source.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    /// <summary>
    /// Initializes a new instance of the <see cref="CateringOrderService"/> class.
    /// </summary>
    /// <param name="context">The database context used for accessing catering order data.</param>
    public CateringOrderService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    ///<inheritdoc/>
    public async Task<IList<GetCateringOrderDTO>> GetAllAsync()
    {
        var result = await _context.CateringOrders.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetCateringOrderDTO> GetByIdAsync(int cateringOrderId)
    {
        var result = await _context.CateringOrders.Where(b => b.Id == cateringOrderId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetCateringOrderDTO> CreateAsync(CreateAndUpdateCateringOrderDTO dto)
    {
        var cateringOrderEntity = dto.ToEntity();

        var response = await _context.CateringOrders.AddAsync(cateringOrderEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = cateringOrderEntity.ToDto();
        return result;
    }

    ///<inheritdoc/>
    public async Task<GetCateringOrderDTO> UpdateAsync(int cateringOrderId, CreateAndUpdateCateringOrderDTO dto)
    {
        if (cateringOrderId < 0)
        {
            return null;
        }
        var existingCateringOrder = await _context.CateringOrders.FindAsync(cateringOrderId);
        if (existingCateringOrder == null)
        {
            return null;
        }
        var updateCateringOrderEntity = dto.ToEntity();
        if (updateCateringOrderEntity == null)
        {
            return null;
        }
        var result = existingCateringOrder.ToDto();
        return result;
    }
    ///<inheritdoc/>
    public async Task<string> DeleteAsync(int cateringOrderId)
    {
        if (cateringOrderId < 0)
        {
            return "Invalid Id";
        }
        var cateringOrder = await _context.CateringOrders.FindAsync(cateringOrderId);
        if (cateringOrder == null)
        {
            return null;
        }
        _context.CateringOrders.Remove(cateringOrder);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{cateringOrderId} is Deleted successfully";
    }

}
