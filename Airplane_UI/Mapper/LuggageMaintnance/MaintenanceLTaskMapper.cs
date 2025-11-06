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

    /// <summary>
    /// Converts a CreateAndUpdateMaintenanceTaskDTO into a MaintenanceTask entity.
    /// </summary>
    /// <param name="dto">The CreateAndUpdateMaintenanceTaskDTO containing data for creation or update.</param>
    /// <param name="entity">The MaintenanceTask entity to convert.</param>
    public static void UpdateEntity(this CreateAndUpdateMaintenanceTaskDTO dto, MaintenanceTask entity)
    {
        if (entity == null || dto == null) return;

        entity.Name = dto.Name;
        entity.Description = dto.Description;
    }
}
