using Airplane_UI.Entities.Base;
namespace Airplane_UI.Entities.SecurityGates;

/// <summary>
/// Represents an airport employee assigned to security or passenger service roles.
/// </summary>
public class AirportStaff : INamedBaseEntity , IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// The primary role of the staff member (e.g., 'Security', 'Customs', 'Check-In').
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// Collection of work shifts assigned to this staff member.
    /// </summary>
    public ICollection<StaffShift> StaffShifts { get; set; } = new HashSet<StaffShift>();

    /// <summary>
    /// Collection of security incidents this staff member has been assigned to handle.
    /// </summary>
    public ICollection<SecurityIncident> SecurityIncidentsHandled { get; set; } = new HashSet<SecurityIncident>();
}
