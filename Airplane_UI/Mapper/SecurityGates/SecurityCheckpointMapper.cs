using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping methods between SecurityCheckpoint entities and their corresponding DTOs.
    /// </summary>
    public static class SecurityCheckpointMapper
    {
        /// <summary>
        /// Converts a SecurityCheckpoint entity to a GetSecurityCheckpointDto.
        /// </summary>
        /// <param name="checkpoint">The SecurityCheckpoint entity to convert.</param>
        /// <returns>
        /// A GetSecurityCheckpointDto containing basic checkpoint information.
        /// </returns>
        public static GetSecurityCheckpointDto ToDTO(this SecurityCheckpoint checkpoint)
        {
            return new GetSecurityCheckpointDto
            {
                Id = checkpoint.Id,
                Name = checkpoint.Name,
                TerminalID = checkpoint.TerminalID,
                Status = checkpoint.Status
            };
        }

        /// <summary>
        /// Converts a CreateSecurityCheckpointDto to a new SecurityCheckpoint entity.
        /// </summary>
        /// <param name="dto">The DTO containing data for creating a new security checkpoint.</param>
        /// <returns>
        /// A new SecurityCheckpoint entity populated with data from the DTO.
        /// </returns>
        public static SecurityCheckpoint ToEntity(this CreateSecurityCheckpointDto dto)
        {
            return new SecurityCheckpoint
            {
                Name = dto.Name,
                TerminalID = dto.TerminalID,
                Status = string.IsNullOrWhiteSpace(dto.Status) ? "Active" : dto.Status
            };
        }

        /// <summary>
        /// Converts a SecurityCheckpoint entity to a GetSecurityCheckpointDetailsDto,
        /// including additional computed information such as log count, active shifts, and average wait time.
        /// </summary>
        /// <param name="checkpoint">The SecurityCheckpoint entity to convert.</param>
        /// <returns>
        /// A GetSecurityCheckpointDetailsDto containing detailed checkpoint information.
        /// </returns>
        public static GetSecurityCheckpointDetailsDto ToDetailsDTO(this SecurityCheckpoint checkpoint)
        {
            var averageWaitTime = checkpoint.CheckpointLogs.Any()
                ? TimeSpan.FromTicks((long)checkpoint.CheckpointLogs.Average(cl => cl.ReportedWaitTime.Ticks))
                : (TimeSpan?)null;

            return new GetSecurityCheckpointDetailsDto
            {
                Id = checkpoint.Id,
                Name = checkpoint.Name,
                TerminalID = checkpoint.TerminalID,
                Status = checkpoint.Status,
                LogCount = checkpoint.CheckpointLogs.Count,
                ActiveShifts = checkpoint.AssignedShifts.Count(ss => ss.EndTime > DateTime.UtcNow),
                AverageWaitTime = averageWaitTime
            };
        }

        /// <summary>
        /// Updates an existing SecurityCheckpoint entity using values from an UpdateSecurityCheckpointDto.
        /// </summary>
        /// <param name="dto">The DTO containing updated values for the checkpoint.</param>
        /// <param name="entity">The SecurityCheckpoint entity to be updated.</param>
        public static void UpdateEntity(this UpdateSecurityCheckpointDto dto, SecurityCheckpoint entity)
        {
            if (entity == null || dto == null) return;

            entity.Name = dto.Name;
            entity.Status = dto.Status;
        }
    }
}
