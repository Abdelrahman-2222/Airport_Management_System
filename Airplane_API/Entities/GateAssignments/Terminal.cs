using Airplane_API.Entities.Base;
using Airplane_API.Entities.LuggageMaintnance;
using Airplane_API.Entities.Security_Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airplane_API.Entities.GateAssignments
{
    public class Terminal : NamedBaseEntity
    {
        public Terminal()
        {
            Gates = new HashSet<Gate>();
            BaggageClaims = new HashSet<BaggageClaim>();
            SecurityCheckpoints = new HashSet<SecurityCheckpoint>();
            CustomsDesks = new HashSet<CustomsDesk>();
        }

        public virtual ICollection<Gate> Gates { get; set; }
        public virtual ICollection<BaggageClaim> BaggageClaims { get; set; }
        public virtual ICollection<SecurityCheckpoint> SecurityCheckpoints { get; set; }
        public virtual ICollection<CustomsDesk> CustomsDesks { get; set; }
    }
}
