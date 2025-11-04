using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.Mapper.LuggageMaintnance;

public static class MaintenanceLogMapper
{

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
