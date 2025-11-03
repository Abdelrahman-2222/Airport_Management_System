using Airplane_API.Entities.Base;
namespace Airplane_API.Entities.SecurityGates;

/// <summary>
/// Defines a recorded security event or incident occurring within the airport.
/// </summary>
public class SecurityIncident : BaseEntity
{
    /// <summary>
    /// Optional Foreign Key linking the incident to the staff member assigned to handle it.
    /// </summary>
    public int? AssignedStaffID { get; set; }

    /// <summary>
    /// The physical location within the airport where the incident occurred.
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// The exact date and time the incident took place.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Detailed report describing the nature and events of the incident.
    /// </summary>
    public string ReportDetails { get; set; }

    /// <summary>
    /// The severity level assigned to the incident (e.g., 'Low', 'Medium', 'High').
    /// </summary>
    public string Severity { get; set; }

    /// <summary>
    /// Navigation property to the staff member assigned to manage the incident (if applicable).
    /// </summary>
    public AirportStaff AssignedStaff { get; set; }
}
