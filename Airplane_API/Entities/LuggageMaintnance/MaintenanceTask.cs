using Airplane_API.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_API.Entities.LuggageMaintnance;
/// <summary>
/// Represents a maintenance task with a name, description, and related maintenance logs.
/// </summary>
public class MaintenanceTask : NamedBaseEntity
{
    /// <summary>
    /// The name of the maintenance task.
    /// </summary>
    public string TaskName { get; set; }
    /// <summary>
    /// The name property mapped to the TaskName, not stored in the database.
    /// </summary>  
    [NotMapped]
    public override string Name 
    { 
        get => TaskName; 
        set => TaskName = value; 
    }
    /// <summary>
    /// Description of the maintenance task.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Collection of maintenance logs associated with this task.
    /// </summary>
    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
}
