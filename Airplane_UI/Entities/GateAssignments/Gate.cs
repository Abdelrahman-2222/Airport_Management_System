using Airplane_UI.Entities.Base;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.GateAssignments
{
    public class Gate : IBaseEntity
    {
        public int Id { get; set; }

        public string GateNumber { get; set; }
        public GateStatus Status { get; set; }

        public int TerminalId { get; set; }
        public virtual Terminal? Terminal { get; set; }

        public virtual ICollection<GateAssignment> GateAssignments { get; set; } = new HashSet<GateAssignment>();
    }
}
