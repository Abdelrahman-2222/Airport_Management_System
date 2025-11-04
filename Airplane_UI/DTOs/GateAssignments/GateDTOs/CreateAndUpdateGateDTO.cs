using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.GateDTOs
{
    public class CreateAndUpdateGateDTO
    {
        public string GateNumber { get; set; }
        public GateStatus Status { get; set; }
        public int TerminalId { get; set; }
    }
}
