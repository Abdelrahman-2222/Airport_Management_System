
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for MaintenanceLog service operations,
/// including retrieval, creation, updating, and deletion of MaintenanceLog records.
/// </summary>
public interface IMaintenanceLogService
{
    /// <summary>
    /// Retrieves all MaintenanceLog records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of MaintenanceLog DTOs. </returns>
   	Task<IList<GetMaintenanceLogDTO>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific MaintenanceLog record by its unique identifier.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the MaintenanceLog.</param>
    /// <returns>A task representing the asynchronous operation that returns the MaintenanceLog DTO.</returns>
    Task<GetMaintenanceLogDTO> GetByIdAsync(int maintenanceLogId);
    /// <summary>
    /// Creates a new MaintenanceLog record.
    /// </summary>
    /// <param name="dto">The data transfer object containing MaintenanceLog details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created MaintenanceLog DTO.</returns>
    Task<GetMaintenanceLogDTO> CreateAsync(CreateAndUpdateMaintenanceLogDTO dto);
    /// <summary>
    /// Updates an existing MaintenanceLog record.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the MaintenanceLog to update.</param>
    /// <param name="dto">The data transfer object containing updated MaintenanceLog details.</param>
    /// <returns>A task representing the asynchronous operation that returns a GetMaintenanceLogDTO indicating success or failure.</returns>
    Task<GetMaintenanceLogDTO> UpdateAsync(int maintenanceLogId, CreateAndUpdateMaintenanceLogDTO dto);
    /// <summary>
    /// Deletes a MaintenanceLog record by its unique identifier.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the MaintenanceLog to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int maintenanceLogId);
}
