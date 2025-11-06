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
        /// Converts a CheckpointLog entity to a GetCheckpointLogDto.
        /// </summary>
        /// <param name="entity">The CheckpointLog entity to convert.</param>
        /// <returns>
        /// A GetCheckpointLogDto representing the mapped data.
        /// </returns>
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
        /// Converts a CreateCheckpointLogDto to a CheckpointLog entity.
        /// </summary>
        /// <param name="dto">The DTO containing data for creating a new checkpoint log.</param>
        /// <returns>
        /// A CheckpointLog entity instance.
        /// </returns>
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
        /// Updates an existing CheckpointLog entity with values from an UpdateCheckpointLogDto.
        /// </summary>
        /// <param name="dto">The DTO containing updated data.</param>
        /// <param name="entity">The CheckpointLog entity to update.</param>
        public static void UpdateEntity(this UpdateCheckpointLogDto dto, CheckpointLog entity)
        {
            if (entity == null || dto == null) return;

            entity.ReportedWaitTime = dto.ReportedWaitTime;
        }
    }
}
