using Airplane_UI.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_UI.Entities.LuggageMaintnance;
/// <summary>
/// Represents a maintenance task with a name, description, and related maintenance logs.
/// </summary>
public class MaintenanceTask : INamedBaseEntity , IBaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the maintenance task.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of the maintenance task.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Collection of maintenance logs associated with this task.
    /// </summary>
    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new HashSet<MaintenanceLog>();
}
