using Airplane_API.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_API.Entities.GateAssignment
{
    public class GroundCrewTeam : NamedBaseEntity
    {
        public string TeamName { get; set; }

        [NotMapped]
        public override string Name
        {
            get => TeamName;
            set => TeamName = value;
        }
    }
}
