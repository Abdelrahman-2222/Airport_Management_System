using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines operations for managing Security Checkpoints in the airport system.
    /// </summary>
    public interface ISecurityCheckpointService
    {
        /// <summary>
        /// Retrieves all security checkpoints available in the system.
        /// </summary>
        /// <returns>A list of all existing security checkpoints.</returns>
        Task<List<GetSecurityCheckpointDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific security checkpoint by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint.</param>
        /// <returns>The corresponding checkpoint if found; otherwise, null.</returns>
        Task<GetSecurityCheckpointDto> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves detailed information about a specific checkpoint, 
        /// including its related logs and staff assignments.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint.</param>
        /// <returns>Detailed information about the checkpoint.</returns>
        Task<GetSecurityCheckpointDetailsDto> GetDetailsAsync(int id);

        /// <summary>
        /// Retrieves all security checkpoints that belong to a specific terminal.
        /// </summary>
        /// <param name="terminalId">The identifier of the terminal.</param>
        /// <returns>An enumerable collection of checkpoints within the given terminal.</returns>
        Task<IEnumerable<GetSecurityCheckpointDto>> GetByTerminalAsync(int terminalId);

        /// <summary>
        /// Retrieves all checkpoints that share a specific operational status (e.g., Active, Maintenance).
        /// </summary>
        /// <param name="status">The operational status to filter checkpoints by.</param>
        /// <returns>An enumerable collection of checkpoints with the given status.</returns>
        Task<IEnumerable<GetSecurityCheckpointDto>> GetByStatusAsync(string status);

        /// <summary>
        /// Creates a new security checkpoint and adds it to the system.
        /// </summary>
        /// <param name="createDto">The data required to create the new checkpoint.</param>
        /// <returns>The created checkpoint with its generated ID.</returns>
        Task<GetSecurityCheckpointDto> CreateAsync(CreateSecurityCheckpointDto createDto);

        /// <summary>
        /// Updates the information of an existing security checkpoint.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint to be updated.</param>
        /// <param name="updateDto">The updated data for the checkpoint.</param>
        /// <returns>The updated checkpoint after modification.</returns>
        Task<GetSecurityCheckpointDto> UpdateAsync(int id, UpdateSecurityCheckpointDto updateDto);

        /// <summary>
        /// Permanently deletes a specific security checkpoint from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates only the operational status of a specific checkpoint (e.g., from Active to Maintenance).
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint to update.</param>
        /// <param name="status">The new operational status to set.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateStatusAsync(int id, string status);
    }
}
