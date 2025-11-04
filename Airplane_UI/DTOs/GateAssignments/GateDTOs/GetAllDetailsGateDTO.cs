using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.GateDTOs
{
    public class GetAllDetailsGateDTO
    {
        public int Id { get; set; }
        public string GateNumber { get; set; }
        public GateStatus Status { get; set; }
        public virtual GetTerminalDTO Terminal { get; set; }
        public virtual ICollection<GetGateAssignmentDTO> GateAssignments { get; set; } = new HashSet<GetGateAssignmentDTO>();
    }
}
