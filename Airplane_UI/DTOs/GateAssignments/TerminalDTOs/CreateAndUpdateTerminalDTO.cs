using Airplane_UI.Entities.Base;

namespace Airplane_UI.DTOs.GateAssignments.TerminalDTOs
{
    public class CreateAndUpdateTerminalDTO : INamedBaseEntity
    {
        public string Name { get; set; }
    }
}
