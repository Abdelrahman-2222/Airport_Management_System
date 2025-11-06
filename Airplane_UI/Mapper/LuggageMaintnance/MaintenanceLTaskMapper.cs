using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
using Airplane_UI.Entities.LuggageMaintnance;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Provides mapping extension methods for converting between
/// MaintenanceTask entities and their corresponding DTOs.
/// </summary>
public static class MaintenanceLTaskMapper
{
    /// <summary>
    /// Converts a MaintenanceTask entity to a GetMaintenanceTaskDTO.
    /// </summary>
    /// <param name="claims">The MaintenanceTask entity to convert.</param>
    /// <returns>
    /// A GetMaintenanceTaskDTO containing mapped data from the entity.
    /// </returns>
    public static GetMaintenanceTaskDTO ToDto(this MaintenanceTask claims)
    {
        var result = new GetMaintenanceTaskDTO
        {
            Id = claims.Id,
            Name = claims.Name,
            Description = claims.Description,
            MaintenanceLogs = claims.MaintenanceLogs
            .Select(log => new GetDetailsMaintenanceLogDTO
            {
                Id = log.Id,
                Description = log.Description,
                Date = log.Date,
                Status = log.Status
            }).ToList()
        };
        return result;
    }
    /// <summary>
    /// Converts a GetMaintenanceTaskDTO object to a MaintenanceTask entity.
    /// </summary>
    /// <param name="claims">The GetMaintenanceTaskDTO object to convert.</param>
    /// <returns>
    /// A MaintenanceTask entity populated with data from the DTO.
    /// </returns>
    public static MaintenanceTask ToEntity(this GetMaintenanceTaskDTO claims)
    {
        var result = new MaintenanceTask
        {
           Id = claims.Id,
           Name = claims.Name,
           Description = claims.Description,
           MaintenanceLogs = claims.MaintenanceLogs
            .Select(logDto => new MaintenanceLog
            {
                Id = logDto.Id,
                Description = logDto.Description,
                Date = logDto.Date,
                Status = logDto.Status
            }).ToList()
        };
        return result;
    }
    /// <summary>
    /// Converts a CreateAndUpdateMaintenanceTaskDTO object to a MaintenanceTask entity.
    /// </summary>
    /// <param name="dto">The CreateAndUpdateMaintenanceTaskDTO object to convert.</param>
    /// <returns>
    /// A new MaintenanceTask entity populated with data from the DTO.
    /// </returns>
    public static MaintenanceTask ToEntity(this CreateAndUpdateMaintenanceTaskDTO dto)
    {
        return new MaintenanceTask
        {
           Name = dto.Name,
           Description = dto.Description,
        };
    }
}
