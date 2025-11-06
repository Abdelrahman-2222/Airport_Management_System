using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs
{
    public class CreateAndUpdateRunwayScheduleDTO
    {
        public DateTime ScheduledTime { get; set; }
        public RunwayScheduleType Type { get; set; }
        public int FlightId { get; set; }
        public int RunwayId { get; set; }
    }
}
