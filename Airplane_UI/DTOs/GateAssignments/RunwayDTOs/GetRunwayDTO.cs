using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayDTOs
{
    public class GetRunwayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
    }
}
