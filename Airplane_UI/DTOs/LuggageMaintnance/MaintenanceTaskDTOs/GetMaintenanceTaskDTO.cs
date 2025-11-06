using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;

namespace Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for get Maintenance task records.
/// </summary>
public class GetMaintenanceTaskDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the Maintenance task.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of the Maintenance task.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Collection of GetDetailsMaintenanceLogDTO associated with this task.
    /// </summary>
    public ICollection<GetDetailsMaintenanceLogDTO> MaintenanceLogs { get; set; } = new HashSet<GetDetailsMaintenanceLogDTO>();
}
