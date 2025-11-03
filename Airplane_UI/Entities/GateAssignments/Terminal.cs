using Airplane_UI.Entities.Base;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Entities.GateAssignments
{
    public class Terminal : IBaseEntity, INamedBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Gate> Gates { get; set; } = new HashSet<Gate>();
        public virtual ICollection<BaggageClaim> BaggageClaims { get; set; } = new HashSet<BaggageClaim>();
        public virtual ICollection<SecurityCheckpoint> SecurityCheckpoints { get; set; } = new HashSet<SecurityCheckpoint>();
        public virtual ICollection<CustomsDesk> CustomsDesks { get; set; } = new HashSet<CustomsDesk>();
    }
}
