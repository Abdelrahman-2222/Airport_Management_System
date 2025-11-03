using Airplane_UI.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_UI.Entities.GateAssignments
{
    public class GroundCrewTeam : IBaseEntity, INamedBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
