using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.Base;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.LuggageMaintnance;

/// <summary>
/// Represents a maintenance log entry that records details about maintenance activities, 
/// </summary>
public class MaintenanceLog : IBaseEntity
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
    /// <summary>
    /// The identifier of the associated aircraft.
    /// </summary>
    public int AircraftId { get; set; }
    /// <summary>
    /// The aircraft associated with this maintenance log.
    /// </summary>
    public virtual Aircraft Aircraft { get; set; }
    /// <summary>
    /// The identifier of the related maintenance task.
    /// </summary>
    public int MaintenanceTaskId { get; set; }
    /// <summary>
    /// The maintenance task linked to this log entry.
    /// </summary>
    public virtual MaintenanceTask MaintenanceTask { get; set; }
}
