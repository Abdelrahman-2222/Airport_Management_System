namespace Airplane_UI.DTOs.AirlineCore.AircraftDTOs
{
    /// <summary>
    /// Represents (DTO) for retrieving aircraft details.
    /// </summary>
    public class GetAircraftDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the aircraft.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique tail number of the aircraft.
        /// </summary>
        public string TailNumber { get; set; }

        /// <summary>
        /// Gets or sets the aircraft model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airline that owns or operates this aircraft.
        /// </summary>
        public int AirlineId { get; set; }
    }
}
