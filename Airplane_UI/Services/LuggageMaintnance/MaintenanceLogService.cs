using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Data;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Airplane_UI.Mapper.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.LuggageMaintnance;
/// <summary>
/// Service class that provides business logic for managing maintenance logs,
/// including creating, updating, retrieving, and deleting maintenance log records.
/// </summary>
public class MaintenanceLogService : IMaintenanceLogService
{
    /// <summary>
    /// The database context used to access maintenance log data.
    /// </summary>
    private readonly AirplaneManagementSystemContext _context;
    /// <summary>
    /// Initializes a new instance of the MaintenanceLogService class.
    /// </summary>
    /// <param name="context">The database context for accessing maintenance log data.</param>
    public MaintenanceLogService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }
    ///<inheritdoc/>
    public async Task<IList<GetMaintenanceLogDTO>> GetAllAsync()
    {
        var result = await _context.MaintenanceLogs
            .Include(b => b.Aircraft)
            .Include(b => b.MaintenanceTask)
            .Select(b => b.ToDto()).ToListAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetMaintenanceLogDTO> GetByIdAsync(int maintenanceLogId)
    {
        var result = await _context.MaintenanceLogs.Where(b => b.Id == maintenanceLogId)
            .Select(b => b.ToDto()).SingleOrDefaultAsync();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetMaintenanceLogDTO> CreateAsync(CreateAndUpdateMaintenanceLogDTO dto)
    {
        var maintenanceLogEntity = dto.ToEntity();

        var response = await _context.MaintenanceLogs.AddAsync(maintenanceLogEntity);
        if (response == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();

        var result = maintenanceLogEntity.ToDto();
        return result;
    }
    ///<inheritdoc/>
    public async Task<GetMaintenanceLogDTO> UpdateAsync(int maintenanceLogId, CreateAndUpdateMaintenanceLogDTO dto)
    {
        if (maintenanceLogId < 0)
        {
            return null;
        }
        var existingMaintenanceLog = await _context.MaintenanceLogs.FindAsync(maintenanceLogId);
        if (existingMaintenanceLog == null)
        {
            return null;
        }
        var updateMaintenanceLogEntity = dto.ToEntity();
        if (updateMaintenanceLogEntity == null)
        {
            return null;
        }
        dto.UpdateEntity(existingMaintenanceLog);
        await _context.SaveChangesAsync();

        return existingMaintenanceLog.ToDto();
    }
    ///<inheritdoc/>
    public async Task<string> DeleteAsync(int maintenanceLogId)
    {
        if (maintenanceLogId < 0)
        {
            return "Invalid Id";
        }
        var maintenanceLog = await _context.MaintenanceLogs.FindAsync(maintenanceLogId);
        if (maintenanceLog == null)
        {
            return null;
        }
        _context.MaintenanceLogs.Remove(maintenanceLog);
        var result = await _context.SaveChangesAsync();
        if (result == null)
        {
            return null;
        }
        return $"{maintenanceLogId} is Deleted successfully";
    }

}
