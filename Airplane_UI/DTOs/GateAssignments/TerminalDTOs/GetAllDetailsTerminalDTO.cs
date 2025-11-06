using Airplane_UI.DTOs.GateAssignments.GateDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.DTOs.GateAssignments.TerminalDTOs
{
    public class GetAllDetailsTerminalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GetGateDTO> Gates { get; set; } = new HashSet<GetGateDTO>();
        public virtual ICollection<GetBaggageClaimDto> BaggageClaims { get; set; } = new HashSet<GetBaggageClaimDto>();
        public virtual ICollection<GetSecurityCheckpointDto> SecurityCheckpoints { get; set; } = new HashSet<GetSecurityCheckpointDto>();
        public virtual ICollection<GetCustomsDeskDto> CustomsDesks { get; set; } = new HashSet<GetCustomsDeskDto>();
    }
}
