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
    /// <summary>
    /// Retrieves all catering orders asynchronously.
    /// </summary>
    /// <returns>A list of GetCateringOrderDTO objects representing all catering orders.</returns>
    public async Task<IList<GetCateringOrderDTO>> GetAllAsync()
    {
        var result = await _context.CateringOrders.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    /// <summary>
    /// Retrieves a specific catering order by its ID asynchronously.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order.</param>
    /// <returns>
    /// A GetCateringOrderDTO representing the catering order,
    /// </returns>
    public async Task<GetCateringOrderDTO> GetByIdAsync(int cateringOrderId)
    {
        var result = await _context.CateringOrders.Where(b => b.Id == cateringOrderId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    /// <summary>
    /// Creates a new catering order asynchronously.
    /// </summary>
    /// <param name="dto">The data transfer object containing information for the new catering order.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a GetCateringOrderDTO representing the created catering order,
    /// </returns>
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

    /// <summary>
    /// Updates an existing catering order asynchronously.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order to update.</param>
    /// <param name="dto">The data transfer object containing the updated information.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a GetCateringOrderDTO representing the updated catering order,
    /// </returns>
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
        var updateBaggageClaimEntity = dto.ToEntity();
        if (updateBaggageClaimEntity == null)
        {
            return null;
        }
        var result = existingCateringOrder.ToDto();
        return result;
    }
    /// <summary>
    /// Deletes an existing catering order asynchronously by its unique identifier.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a string message indicating whether the deletion was successful.
    /// </returns>
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
