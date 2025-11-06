namespace Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS
{
    /// <summary>
    /// Represents a (DTO) used when creating a new flight manifest record.
    /// </summary>
    public class CreateAndUpdateFlightManifestDTO
    {
        /// <summary>
        /// Gets or sets the seat number assigned to the passenger on the flight.
        /// </summary>
        public string SeatNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the flight associated with this manifest entry.
        /// </summary>
        public int FlightId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the passenger associated with this manifest entry.
        /// </summary>
        public int PassengerId { get; set; }
    }
}
