using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayDTOs
{
    public class CreateAndUpdateRunwayDTO
    {
        public string Name { get; set; }

        public RunwayStatus Status { get; set; }
    }
}
