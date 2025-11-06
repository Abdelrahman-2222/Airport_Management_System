namespace Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for craete and update MaintenanceTask records.
/// </summary>
public class CreateAndUpdateMaintenanceTaskDTO
{
    /// <summary>
    /// The name of the maintenance task.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of the maintenance task.
    /// </summary>
    public string Description { get; set; }

}
