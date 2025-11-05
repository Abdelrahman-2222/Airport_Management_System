using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs
{
    public class GetAllDetailsRunwayScheduleDTO
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Type { get; set; }
        public string FlightNumber { get; set; }
        public string RunwayName { get; set; }
    }
}
