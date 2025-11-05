using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
/// <summary>
/// Data Transfer Object (DTO) used for get details MaintenanceLog records.
/// </summary>
public class GetDetailsMaintenanceLogDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
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
}
