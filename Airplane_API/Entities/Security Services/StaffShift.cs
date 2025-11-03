using Airplane_API.Entities.Base;
using Airplane_API.Entities.Security_Services;
namespace Airport.Models.Security_Services;

/// <summary>
/// Represents a specific work shift assigned to a staff member at one operational location within the airport.
/// </summary>
public class StaffShift : BaseEntity
{
    /// <summary>
    /// Foreign Key linking the shift to the staff member performing it.
    /// </summary>
    public int StaffID { get; set; }

    /// <summary>
    /// Optional Foreign Key linking the shift to a security checkpoint.
    /// </summary>
    public int? AssignedCheckpointID { get; set; }

    /// <summary>
    /// Optional Foreign Key linking the shift to a customs desk.
    /// </summary>
    public int? AssignedDeskID { get; set; }

    /// <summary>
    /// The date and time when the staff member's shift begins.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// The date and time when the staff member's shift ends.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Navigation property to the staff member assigned to this shift.
    /// </summary>
    public AirportStaff AirportStaff { get; set; }

    /// <summary>
    /// Navigation property to the security checkpoint assigned to this shift, if applicable.
    /// </summary>
    public SecurityCheckpoint AssignedCheckpoint { get; set; }

    /// <summary>
    /// Navigation property to the customs desk assigned to this shift, if applicable.
    /// </summary>
    public CustomsDesk AssignedDesk { get; set; }
}
