using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
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
    ///<inheritdoc/>
    public async Task<IList<GetMaintenanceTaskDTO>> GetAllAsync()
    {
        var result = await _context.MaintenanceTasks.Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetMaintenanceTaskDTO> GetByIdAsync(int maintenanceTaskId)
    {
        var result = await _context.MaintenanceTasks.Where(b => b.Id == maintenanceTaskId).Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    ///<inheritdoc/>
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
    ///<inheritdoc/>
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
        dto.UpdateEntity(existingMaintenanceTask);
        await _context.SaveChangesAsync();

        return existingMaintenanceTask.ToDto();
    }
    ///<inheritdoc/>
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
