using Airplane_UI.Entities.AirlineCore;

namespace Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS
{
    /// <summary>
    /// Represents a (DTO) for retrieving flight manifest details.
    /// </summary>
    public class GetFlightManifestDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the flight manifest record.
        /// </summary>
        public int Id { get; set; }

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