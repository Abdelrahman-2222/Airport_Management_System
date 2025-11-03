using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.AirlineCore
{
    public class Flight : BaseEntity
    {
        public Flight()
        {
            FlightManifests = new HashSet<FlightManifest>();
            GateAssignments = new HashSet<GateAssignment>();
            RunwaySchedules = new HashSet<RunwaySchedule>();
        }

        public string FlightNumber { get; set; }
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public FlightStatus Status { get; set; }

        public int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }

        public int AircraftId { get; set; }
        public virtual Aircraft Aircraft { get; set; }

        public int OriginAirportId { get; set; }
        public virtual Airline OriginAirport { get; set; }

        public int DestinationAirportId { get; set; }
        public virtual Airline DestinationAirport { get; set; }

        public virtual ICollection<FlightManifest> FlightManifests { get; set; }
        public virtual ICollection<GateAssignment> GateAssignments { get; set; }
        public virtual ICollection<RunwaySchedule> RunwaySchedules { get; set; }
        public virtual CateringOrder CateringOrder { get; set; }
    }
}
