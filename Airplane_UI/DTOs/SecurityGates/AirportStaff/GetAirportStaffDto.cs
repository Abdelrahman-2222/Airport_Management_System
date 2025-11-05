namespace Airplane_UI.DTOs.SecurityGates.AirportStaff
{

    /// <summary>
    /// Represents basic information about an airport staff member.
    /// </summary>
    public class GetAirportStaffDto
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
    }
}
