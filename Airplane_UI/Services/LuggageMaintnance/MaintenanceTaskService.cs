using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTO;
using Airplane_UI.DTOs.LuggageMaintnance.MaintinanceTaskDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Service class that handles business logic for managing maintenance tasks,
/// including creation, retrieval, updating, and deletion operations.
/// </summary>
public class MaintenanceTaskService : IMaintenanceTaskService
{
    /// <summary>
    /// The database context used to interact with maintenance task data.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    /// <summary>
    /// Initializes a new instance of the MaintenanceTaskService  class.
    /// </summary>
    /// <param name="context">The database context for accessing maintenance task data.</param>
    public MaintenanceTaskService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Retrieves all maintenance task records asynchronously.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation that returns a collection of maintenance task DTOs.
    /// </returns>
    public async Task<IList<GetMaintenanceTaskDTO>> GetAllAsync()
    {
        var result = await _context.MaintenanceTasks.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    /// <summary>
    /// Retrieves a specific maintenance task record by its unique identifier.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns the maintenance task DTO if found; otherwise, null.
    /// </returns>
    public async Task<GetMaintenanceTaskDTO> GetByIdAsync(int maintenanceTaskId)
    {
        var result = await _context.MaintenanceTasks.Where(b => b.Id == maintenanceTaskId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    /// <summary>
    /// Creates a new maintenance task record asynchronously.
    /// </summary>
    /// <param name="dto">The data transfer object containing maintenance task details.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns the created maintenance task DTO.
    /// </returns>
    public async Task<GetMaintenanceTaskDTO> CreateAsync(CreateAndUpdateMaintenanceTaskDTO dto)
    {
        var maintenanceTaskEntity = dto.ToEntity();

        var response = await _context.MaintenanceTasks.AddAsync(maintenanceTaskEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = maintenanceTaskEntity.ToDto();
        return result;
    }

    /// <summary>
    /// Updates an existing maintenance task record asynchronously.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task to update.</param>
    /// <param name="dto">The data transfer object containing updated maintenance task details.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns the updated maintenance task DTO if successful; otherwise, null.
    /// </returns>
    public async Task<GetMaintenanceTaskDTO> UpdateAsync(int maintenanceTaskId, CreateAndUpdateMaintenanceTaskDTO dto)
    {
        if (maintenanceTaskId < 0)
        {
            return null;
        }
        var existingMaintenanceTask = await _context.MaintenanceTasks.FindAsync(maintenanceTaskId);
        if (existingMaintenanceTask == null)
        {
            return null;
        }
        var updateMaintenanceTaskEntity = dto.ToEntity();
        if (updateMaintenanceTaskEntity == null)
        {
            return null;
        }
        var result = existingMaintenanceTask.ToDto();
        return result;
    }
    /// <summary>
    /// Deletes a maintenance task record by its unique identifier asynchronously.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task to delete.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns a confirmation message if deleted successfully; otherwise, null or an error message.
    /// </returns>
    public async Task<string> DeleteAsync(int maintenanceTaskId)
    {
        if (maintenanceTaskId < 0)
        {
            return "Invalid Id";
        }
        var maintenanceTask = await _context.MaintenanceTasks.FindAsync(maintenanceTaskId);
        if (maintenanceTask == null)
        {
            return null;
        }
        _context.MaintenanceTasks.Remove(maintenanceTask);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{maintenanceTaskId} is Deleted successfully";
    }

}
