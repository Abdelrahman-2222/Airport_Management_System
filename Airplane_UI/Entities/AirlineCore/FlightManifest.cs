using Airplane_API.Entities.Base;

namespace Airplane_API.Entities.AirlineCore
{
    /// <summary>
    /// Represents a record linking a Passenger to a specific Flight, 
    /// typically used to track passenger assignments, seat numbers, and flight participation details.
    /// </summary>
    public class FlightManifest : IBaseEntity
    {
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
        /// Gets or sets the navigation property for the related Flight entity.
        /// Represents the flight on which the passenger is booked.
        /// </summary>
        public virtual Flight Flight { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the passenger associated with this manifest entry.
        /// </summary>
        public int PassengerId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the related Passenger entity.
        /// Represents the passenger recorded on the flight manifest.
        /// </summary>
        public virtual Passenger Passenger { get; set; }
    }
}
