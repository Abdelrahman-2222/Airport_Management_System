using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for creating or updating maintenance log records.
/// </summary>
public class CreateAndUpdateMaintenanceLogDTO
{
    /// <summary>
    /// Description of the maintenance activity performed.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The date when the maintenance activity took place.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// The current status of the maintenance log entry.
    /// </summary>
    public MaintenanceStatus Status { get; set; }
    /// <summary>
    /// The identifier of the associated aircraft.
    /// </summary>
    public int AircraftId { get; set; }
    /// <summary>
    /// The identifier of the related maintenance task.
    /// </summary>
    public int MaintenanceTaskId { get; set; }
}
