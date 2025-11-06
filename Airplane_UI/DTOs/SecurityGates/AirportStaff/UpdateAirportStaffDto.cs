namespace Airplane_UI.DTOs.SecurityGates.AirportStaff
{
    /// <summary>
    /// Represents the data required to update an existing airport staff member.
    /// </summary>
    public class UpdateAirportStaffDto
    {
        /// <summary>
        /// Gets or sets the updated name of the staff member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the updated role or job title of the staff member.
        /// </summary>
        public string Role { get; set; }
    }
}
