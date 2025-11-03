using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.Base;

namespace Airplane_UI.Entities.GateAssignments
{
    public class GateAssignment : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int GateId { get; set; }
        public virtual Gate Gate { get; set; }
    }
}
