using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping methods between StaffShift entities and their corresponding DTOs.
    /// </summary>
    public static class StaffShiftMapper
    {
        /// <summary>
        /// Converts a StaffShift entity to a GetStaffShiftDto.
        /// </summary>
        /// <param name="shift">The StaffShift entity to convert.</param>
        /// <returns>
        /// A GetStaffShiftDto containing the mapped data from the entity.
        /// </returns>
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

        /// <summary>
        /// Converts a CreateStaffShiftDto to a new StaffShift entity.
        /// </summary>
        /// <param name="dto">The DTO containing the data for creating a new staff shift.</param>
        /// <returns>
        /// A new StaffShift entity populated with the provided data.
        /// </returns>
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

        /// <summary>
        /// Updates an existing StaffShift entity using data from an UpdateStaffShiftDto.
        /// </summary>
        /// <param name="dto">The DTO containing updated shift information.</param>
        /// <param name="entity">The existing StaffShift entity to be updated.</param>
        public static void UpdateEntity(this UpdateStaffShiftDto dto, StaffShift entity)
        {
            if (entity == null || dto == null) return;

            entity.AssignedCheckpointID = dto.AssignedCheckpointID;
            entity.AssignedDeskID = dto.AssignedDeskID;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
        }
    }
}
