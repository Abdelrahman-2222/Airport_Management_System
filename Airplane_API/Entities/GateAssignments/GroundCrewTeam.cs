using Airplane_API.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_API.Entities.GateAssignments
{
    public class GroundCrewTeam : IBaseEntity, INamedBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
