using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.Base;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.GateAssignments
{
    public class RunwaySchedule : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public RunwayScheduleType Type { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int RunwayId { get; set; }
        public virtual Runway Runway { get; set; }
    }
}
