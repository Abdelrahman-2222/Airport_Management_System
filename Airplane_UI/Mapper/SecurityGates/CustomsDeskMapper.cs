using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping methods for converting between CustomsDesk entities and DTOs.
    /// </summary>
    public static class CustomsDeskMapper
    {
        /// <summary>
        /// Converts a CustomsDesk entity into a GetCustomsDeskDto.
        /// </summary>
        /// <param name="desk">The CustomsDesk entity to convert.</param>
        /// <returns>A DTO representing the CustomsDesk.</returns>
        public static GetCustomsDeskDto ToGetDto(this CustomsDesk desk)
        {
            return new GetCustomsDeskDto
            {
                Id = desk.Id,
                TerminalID = desk.TerminalID,
                DeskNumber = desk.DeskNumber,
                Status = desk.Status
            };
        }

        /// <summary>
        /// Converts a CreateCustomsDeskDto into a CustomsDesk entity.
        /// </summary>
        /// <param name="dto">The DTO containing creation data.</param>
        /// <returns>A CustomsDesk entity.</returns>
        public static CustomsDesk ToEntity(this CreateCustomsDeskDto dto)
        {
            return new CustomsDesk
            {
                TerminalID = dto.TerminalID,
                DeskNumber = dto.DeskNumber,
                Status = string.IsNullOrWhiteSpace(dto.Status) ? "Active" : dto.Status
            };
        }

        /// <summary>
        /// Updates an existing CustomsDesk entity with new values from an UpdateCustomsDeskDto.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="dto">The DTO containing updated data.</param>
        public static void UpdateEntity(this CustomsDesk entity, UpdateCustomsDeskDto dto)
        {
            entity.DeskNumber = dto.DeskNumber;
            entity.Status = dto.Status;
        }

        /// <summary>
        /// Converts a CustomsDesk entity with related staff shifts into a GetCustomsDeskDetailsDto.
        /// </summary>
        /// <param name="desk">The CustomsDesk entity.</param>
        /// <returns>A detailed DTO with staff shift information.</returns>
        public static GetCustomsDeskDetailsDto ToDetailsDto(this CustomsDesk desk)
        {
            return new GetCustomsDeskDetailsDto
            {
                Id = desk.Id,
                TerminalID = desk.TerminalID,
                DeskNumber = desk.DeskNumber,
                Status = desk.Status,
                AssignedShifts = desk.AssignedShifts?.Select(s => new GetStaffShiftDto
                {
                    Id = s.Id,
                    StaffID = s.StaffID,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    AssignedCheckpointID=s.AssignedCheckpointID,
                    AssignedDeskID=s.AssignedDeskID
                    
                }).ToList() ?? new List<GetStaffShiftDto>()
            };
        }
        }
}
