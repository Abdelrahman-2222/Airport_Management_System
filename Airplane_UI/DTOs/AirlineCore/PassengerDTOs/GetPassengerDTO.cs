namespace Airplane_UI.DTOs.AirlineCore.PassengerDTOs
{
    /// <summary>
    /// Represents (DTO) for retrieving passenger details.
    /// </summary>
    public class GetPassengerDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the passenger.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the passenger.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the passenger.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the passport number of the passenger.
        /// </summary>
        public string PassportNumber { get; set; }
    }
}
