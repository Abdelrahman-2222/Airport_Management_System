using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.GateAssignments
{
    public class Runway : IBaseEntity, INamedBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RunwayStatus Status { get; set; }

        public virtual ICollection<RunwaySchedule> RunwaySchedules { get; set; } = new HashSet<RunwaySchedule>();
    }
}
