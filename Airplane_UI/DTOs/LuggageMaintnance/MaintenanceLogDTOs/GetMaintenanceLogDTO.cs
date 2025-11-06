using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for creating or updating maintenance log records.
/// </summary>
public class GetMaintenanceLogDTO
{
    /// <summary>
    /// uniqe id.
    /// </summary>
    public int Id { get; set; }
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
    /// The aircraft associated with this maintenance log.
    /// </summary>
    public string Aircraft { get; set; }
    /// <summary>
    /// The maintenance task linked to this log entry.
    /// </summary>
    public string MaintenanceTask { get; set; }
}
