namespace Airplane_UI.DTOs.AirlineCore.FlightDTOs
{
    /// <summary>
    /// Represents a (DTO) used when creating a new flight record.
    /// </summary>
    public class CreateAndUpdateFlightDTO
    {
        /// <summary>
        /// Gets or sets the unique flight number assigned by the airline.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the scheduled departure time for the flight.
        /// </summary>
        public DateTime ScheduledDeparture { get; set; }

        /// <summary>
        /// Gets or sets the scheduled arrival time for the flight.
        /// </summary>
        public DateTime ScheduledArrival { get; set; }

        /// <summary>
        /// Gets or sets the current status of the flight.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airline operating this flight.
        /// </summary>
        public int AirlineId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the aircraft assigned to this flight.
        /// </summary>
        public int AircraftId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airport from which this flight departs.
        /// </summary>
        public int OriginAirportId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airport where this flight is scheduled to arrive.
        /// </summary>
        public int DestinationAirportId { get; set; }
    }
}
