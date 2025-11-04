namespace Airplane_UI.DTOs.SecurityGates.AirportStaff
{
    /// <summary>
    /// Represents the data required to create a new airport staff member.
    /// </summary>
    public class CreateAirportStaffDto
    {
        /// <summary>
        /// Gets or sets the name of the new staff member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role or job title of the new staff member.
        /// </summary>
        public string Role { get; set; }
    }
}