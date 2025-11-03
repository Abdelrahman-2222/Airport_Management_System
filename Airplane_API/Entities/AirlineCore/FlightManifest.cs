using Airplane_API.Entities.Base;

namespace Airplane_API.Entities.AirlineCore
{
    public class FlightManifest : BaseEntity
    {
        public string SeatNumber { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
