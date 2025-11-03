using Airplane_API.Entities.AirlineCore;
using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.GateAssignments
{
    public class RunwaySchedule : BaseEntity
    {
        public DateTime ScheduledTime { get; set; }
        public RunwayScheduleType Type { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int RunwayId { get; set; }
        public virtual Runway Runway { get; set; }
    }
}
