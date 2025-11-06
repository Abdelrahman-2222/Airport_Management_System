using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    ///
    /// Provides mapping methods between StaffShift entity and its DTOs.
    ///
    public static class StaffShiftMapper
    {
        public static GetStaffShiftDto ToGetDto(this StaffShift shift)
        {
            return new GetStaffShiftDto
            {
                Id = shift.Id,
                StaffID = shift.StaffID,
                AssignedCheckpointID = shift.AssignedCheckpointID,
                AssignedDeskID = shift.AssignedDeskID,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime
            };
        }

        public static StaffShift ToEntity(this CreateStaffShiftDto dto)
        {
            return new StaffShift
            {
                StaffID = dto.StaffID,
                AssignedCheckpointID = dto.AssignedCheckpointID,
                AssignedDeskID = dto.AssignedDeskID,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };
        }

        public static void UpdateEntity(this StaffShift shift, UpdateStaffShiftDto dto)
        {
            shift.AssignedCheckpointID = dto.AssignedCheckpointID;
            shift.AssignedDeskID = dto.AssignedDeskID;
            shift.StartTime = dto.StartTime;
            shift.EndTime = dto.EndTime;
        }
    }

}