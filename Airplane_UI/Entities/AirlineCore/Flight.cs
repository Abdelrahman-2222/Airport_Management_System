using Airplane_UI.Entities.Base;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.AirlineCore
{
    /// <summary>
    /// Represents a flight within the system.
    /// </summary>
    public class Flight : IBaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the Flight class.
        /// The constructor initializes related entity collections to prevent null reference exceptions 
        /// when adding or modifying relationships.
        /// </summary>

        /// <summary>
        /// Gets or sets the unique flight number assigned by the airline.
        /// </summary>
        /// <example>Example: "AA102", "BA453", "EK231"</example>
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
        public FlightStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airline operating this flight.
        /// </summary>
        public int AirlineId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the airline operating this flight.
        /// </summary>
        public virtual Airline Airline { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the aircraft assigned to this flight.
        /// </summary>
        public int AircraftId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the aircraft assigned to this flight.
        /// </summary>
        public virtual Aircraft Aircraft { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airport from which this flight departs.
        /// </summary>
        public int OriginAirportId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the airport from which this flight departs.
        /// </summary>
        public virtual Airport OriginAirport { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airport where this flight is scheduled to arrive.
        /// </summary>
        public int DestinationAirportId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the airport where this flight is scheduled to arrive.
        /// </summary>
        public virtual Airport DestinationAirport { get; set; }

        /// <summary>
        /// Gets or sets the collection of flight manifests associated with this flight.
        /// </summary>
        public virtual ICollection<FlightManifest> FlightManifests { get; set; } = new HashSet<FlightManifest>();

        /// <summary>
        /// Gets or sets the collection of gate assignments associated with this flight.
        /// </summary>
        public virtual ICollection<GateAssignment> GateAssignments { get; set; } = new HashSet<GateAssignment>();

        /// <summary>
        /// Gets or sets the collection of runway schedules associated with this flight.
        /// </summary>
        public virtual ICollection<RunwaySchedule> RunwaySchedules { get; set; } = new HashSet<RunwaySchedule>();

        /// <summary>
        /// Gets or sets the catering order associated with this flight, if any.
        /// </summary>
        public virtual CateringOrder CateringOrder { get; set; }
        
    }
}
