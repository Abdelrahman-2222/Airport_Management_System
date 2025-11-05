using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs
{
    public class GetRunwayScheduleDTO
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Type { get; set; }
    }
}
