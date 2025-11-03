using Airplane_UI.Entities.Base;
using Airplane_UI.Enums;

namespace Airplane_UI.Entities.GateAssignments
{
    public class Runway : IBaseEntity, INamedBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RunwayStatus Status { get; set; }

        public virtual ICollection<RunwaySchedule> RunwaySchedules { get; set; } = new HashSet<RunwaySchedule>();
    }
}
