using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;
using Airplane_UI.Entities.GateAssignments;
using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.GateAssignments.RunwayDTOs
{
    public class GetAllDetailsRunwayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }

        public virtual ICollection<GetRunwayScheduleDTO> RunwaySchedules { get; set; } = new HashSet<GetRunwayScheduleDTO>();
    }
}
