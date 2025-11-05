namespace Airplane_UI.DTOs.AirlineCore.PassengerDTOs
{
    /// <summary>
    /// Represents a (DTO) used when creating a new passenger record.
    /// </summary>
    public class CreateAndUpdatePassengerDTO
    {
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
