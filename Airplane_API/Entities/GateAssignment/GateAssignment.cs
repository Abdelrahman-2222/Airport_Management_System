using Airplane_API.Entities.AirlineCore;
using Airplane_API.Entities.Base;

namespace Airplane_API.Entities.GateAssignment
{
    public class GateAssignment : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int GateId { get; set; }
        public virtual Gate Gate { get; set; }
    }
}
