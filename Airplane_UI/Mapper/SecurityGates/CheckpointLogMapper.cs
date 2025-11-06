using Airplane_UI.DTOs.SecurityGates.CheckpointLog;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mapper.SecurityGates
{
    /// <summary>
    /// Provides extension methods for mapping between CheckpointLog entities and their DTOs.
    /// </summary>
    public static class CheckpointLogMapper
    {
        /// <summary>
        /// Converts a <see cref="CheckpointLog"/> entity to a <see cref="GetCheckpointLogDto"/>.
        /// </summary>
        /// <param name="entity">The <see cref="CheckpointLog"/> entity to convert.</param>
        /// <returns>A <see cref="GetCheckpointLogDto"/> representing the mapped data.</returns>
        public static GetCheckpointLogDto ToDto(this CheckpointLog entity)
        {
            return new GetCheckpointLogDto
            {
                Id = entity.Id,
                CheckpointID = entity.CheckpointID,
                Timestamp = entity.Timestamp,
                ReportedWaitTime = entity.ReportedWaitTime
            };
        }

        /// <summary>
        /// Converts a <see cref="CheckpointLog"/> entity to a <see cref="GetCheckpointLogDetailsDto"/>,
        /// including related checkpoint information.
        /// </summary>
        /// <param name="entity">The <see cref="CheckpointLog"/> entity to convert.</param>
        /// <returns>A <see cref="GetCheckpointLogDetailsDto"/> containing detailed information.</returns>
        public static GetCheckpointLogDetailsDto ToDetailsDto(this CheckpointLog entity)
        {
            return new GetCheckpointLogDetailsDto
            {
                Id = entity.Id,
                CheckpointID = entity.CheckpointID,
                CheckpointName = entity.SecurityCheckpoint?.Name ?? "Unknown",
                Timestamp = entity.Timestamp,
                ReportedWaitTime = entity.ReportedWaitTime
            };
        }

        /// <summary>
        /// Converts a <see cref="CreateCheckpointLogDto"/> to a <see cref="CheckpointLog"/> entity.
        /// </summary>
        /// <param name="dto">The DTO containing data for creating a new checkpoint log.</param>
        /// <returns>A <see cref="CheckpointLog"/> entity instance.</returns>
        public static CheckpointLog ToEntity(this CreateCheckpointLogDto dto)
        {
            return new CheckpointLog
            {
                CheckpointID = dto.CheckpointID,
                ReportedWaitTime = dto.ReportedWaitTime,
                Timestamp = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Updates the existing <see cref="CheckpointLog"/> entity based on an <see cref="UpdateCheckpointLogDto"/>.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="dto">The DTO containing updated data.</param>
        public static void UpdateEntity(this CheckpointLog entity, UpdateCheckpointLogDto dto)
        {
            entity.ReportedWaitTime = dto.ReportedWaitTime;
        }
    }
}
