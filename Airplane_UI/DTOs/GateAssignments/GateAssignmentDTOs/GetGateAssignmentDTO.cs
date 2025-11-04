using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.GateAssignments;

namespace Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs
{
    public class GetGateAssignmentDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
