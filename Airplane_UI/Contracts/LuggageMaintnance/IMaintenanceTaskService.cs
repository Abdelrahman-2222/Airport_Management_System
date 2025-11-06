using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for MaintenanceTask service operations,
/// including retrieval, creation, updating, and deletion of MaintenanceTask records.
/// </summary>
public interface IMaintenanceTaskService
{
    /// <summary>
    /// Retrieves all MaintenanceTask records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of MaintenanceTask DTOs. </returns>
   	Task<IList<GetMaintenanceTaskDTO>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific MaintenanceTask record by its unique identifier.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the MaintenanceTask.</param>
    /// <returns>A task representing the asynchronous operation that returns the MaintenanceTask DTO.</returns>
    Task<GetMaintenanceTaskDTO> GetByIdAsync(int maintenanceTaskId);
    /// <summary>
    /// Creates a new MaintenanceTask record.
    /// </summary>
    /// <param name="dto">The data transfer object containing MaintenanceTask details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created MaintenanceTask DTO.</returns>
    Task<GetMaintenanceTaskDTO> CreateAsync(CreateAndUpdateMaintenanceTaskDTO dto);
    /// <summary>
    /// Updates an existing MaintenanceTask record.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the MaintenanceTask to update.</param>
    /// <param name="dto">The data transfer object containing updated MaintenanceTask details.</param>
    /// <returns>A task representing the asynchronous operation that returns a MaintenanceTask indicating success or failure.</returns>
    Task<GetMaintenanceTaskDTO> UpdateAsync(int maintenanceTaskId, CreateAndUpdateMaintenanceTaskDTO dto);
    /// <summary>
    /// Deletes a MaintenanceTask record by its unique identifier.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the MaintenanceTask to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int maintenanceTaskId);
}
