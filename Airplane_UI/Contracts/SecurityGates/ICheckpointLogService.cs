using Airplane_UI.DTOs.CheckpointLog;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines the contract for managing CheckpointLogs, including CRUD operations.
    /// </summary>
    public interface ICheckpointLogService
    {
        /// <summary>
        /// Retrieves all checkpoint logs from the system.
        /// </summary>
        /// <returns>A list of <see cref="GetCheckpointLogDto"/> representing all checkpoint logs.</returns>
        Task<IList<GetCheckpointLogDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a single checkpoint log by its unique identifier.
        /// </summary>
        /// <param name="CheckpointId">The unique identifier of the checkpoint log.</param>
        /// <returns>
        /// A <see cref="GetCheckpointLogDto"/> representing the checkpoint log,
        /// </returns>
        Task<GetCheckpointLogDto> GetByIdAsync(int CheckpointId);

        /// <summary>
        /// Creates a new checkpoint log in the system.
        /// </summary>
        /// <param name="dto">The data required to create a new checkpoint log.</param>
        /// <returns>A <see cref="GetCheckpointLogDto"/> representing the newly created log.</returns>
        Task<GetCheckpointLogDto> CreateAsync(CreateCheckpointLogDto dto);

        /// <summary>
        /// Updates an existing checkpoint log's reported wait time.
        /// </summary>
        /// <param name="CheckpointId">The unique identifier of the checkpoint log to update.</param>
        /// <param name="dto">The data containing the updated wait time.</param>
        /// <returns>
        /// A <see cref="GetCheckpointLogDto"/> representing the updated log,
        /// </returns>
        Task<GetCheckpointLogDto> UpdateAsync(int CheckpointId, UpdateCheckpointLogDto dto);

        /// <summary>
        /// Deletes a checkpoint log by its unique identifier.
        /// </summary>
        /// <param name="CheckpointId">The unique identifier of the checkpoint log to delete.</param>
        /// <returns>A string message indicating the result of the deletion operation.</returns>
        Task<string> DeleteAsync(int CheckpointId);
    }
}
