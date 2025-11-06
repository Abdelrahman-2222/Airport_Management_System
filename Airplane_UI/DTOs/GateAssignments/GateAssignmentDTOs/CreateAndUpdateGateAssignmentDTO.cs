using System.ComponentModel.DataAnnotations;

namespace Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs
{
    public class CreateAndUpdateGateAssignmentDTO
    {
        public int FlightId { get; set; }
        public int GateId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
