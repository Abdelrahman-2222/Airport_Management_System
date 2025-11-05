using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Entities.GateAssignments;

namespace Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs
{
    public class GetAllDetailsGateAssignmentDTO
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string GateNumber { get; set; }
        public string TerminalName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
