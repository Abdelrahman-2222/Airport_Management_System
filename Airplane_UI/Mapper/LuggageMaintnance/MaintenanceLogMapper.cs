using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.Mapper.LuggageMaintnance;
/// <summary>
/// Provides mapping extension methods for converting between
/// MaintenanceLog entities and their corresponding DTOs.
/// </summary>
public static class MaintenanceLogMapper
{
    /// <summary>
    /// Converts a MaintenanceLog entity to a GetMaintenanceLogDTO.
    /// </summary>
    /// <param name="claims">The MaintenanceLog entity to convert.</param>
    /// <returns>
    /// A GetMaintenanceLogDTO object containing data mapped from the entity.
    /// </returns>
    public static GetMaintenanceLogDTO ToDto(this MaintenanceLog claims)
    {
        var result = new GetMaintenanceLogDTO
        {
            Status = claims.Status,
            //MaintenanceTask = claims.MaintenanceTask,
            //Aircraft = claims.Aircraft,
            Date = claims.Date,
            Description = claims.Description
        };
        return result;
    }
    /// <summary>
    /// Converts a GetMaintenanceLogDTO object to aMaintenanceLog entity.
    /// </summary>
    /// <param name="claims">The GetMaintenanceLogDTO object to convert.</param>
    /// <returns>
    /// A MaintenanceLog entity populated with data from the DTO.
    /// </returns>
    public static MaintenanceLog ToEntity(this GetMaintenanceLogDTO claims)
    {
        var result = new MaintenanceLog
        {
            Status = claims.Status,
            Description = claims.Description,
            Date = claims.Date,
            //Aircraft = claims.Aircraft,
            //MaintenanceTask = claims.MaintenanceTask,
            
        };
        return result;
    }
    /// <summary>
    /// Converts a CreateAndUpdateMaintenanceLogDTO object to a MaintenanceLog entity.
    /// </summary>
    /// <param name="dto">The CreateAndUpdateMaintenanceLogDTO containing the maintenance log details.</param>
    /// <returns>
    /// A MaintenanceLog entity populated with data from the DTO.
    /// </returns>
    public static MaintenanceLog ToEntity(this CreateAndUpdateMaintenanceLogDTO dto)
    {
        return new MaintenanceLog
        {
            Id = dto.Id,
            AircraftId = dto.AircraftId,
            Date = dto.Date,
            Description = dto.Description,
            MaintenanceTaskId = dto.MaintenanceTaskId,
            Status = dto.Status,
        };
    }
}
