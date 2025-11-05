namespace Airplane_UI.DTOs.SecurityGates.AirportStaff
{
    /// <summary>
    /// Represents detailed information about an airport staff member,
    /// including assigned shifts and related incidents.
    /// </summary>
    public class GetAirportStaffDetailsDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the staff member.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the staff member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role or job title of the staff member.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the collection of assigned shifts for the staff member.
        /// </summary>
        //public ICollection<StaffShiftDto> AssignedShifts { get; set; } = new List<StaffShiftDto>();

        /// <summary>
        /// Gets or sets the total number of incidents reported by the staff member.
        /// </summary>
        public int IncidentCount { get; set; }
    }
}
