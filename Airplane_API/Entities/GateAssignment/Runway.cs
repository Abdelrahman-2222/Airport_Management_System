using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.GateAssignment
{
    public class Runway : NamedBaseEntity
    {
        public Runway()
        {
            RunwaySchedules = new HashSet<RunwaySchedule>();
        }

        public RunwayStatus Status { get; set; }

        public virtual ICollection<RunwaySchedule> RunwaySchedules { get; set; }
    }
}
