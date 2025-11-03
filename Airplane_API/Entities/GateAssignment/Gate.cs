using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.GateAssignment
{
    public class Gate : BaseEntity
    {
        public Gate()
        {
            GateAssignments = new HashSet<GateAssignment>();
        }

        public string GateNumber { get; set; }
        public GateStatus Status { get; set; }

        public int TerminalId { get; set; }
        public virtual Terminal Terminal { get; set; }

        public virtual ICollection<GateAssignment> GateAssignments { get; set; }
    }
}
