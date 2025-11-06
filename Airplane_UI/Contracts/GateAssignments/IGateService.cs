using Airplane_UI.DTOs.GateAssignments.GateDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing gate-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting gate data.
    /// </summary>
    public interface IGateService
    {
        /// <summary>
        /// Retrieves all gates from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetGateDTO objects.
        /// </returns>
        Task<IList<GetGateDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all gates with their full details from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetAllDetailsGateDTO objects.
        /// </returns>
        Task<IList<GetAllDetailsGateDTO>> GetDetailsAsync();

        /// <summary>
        /// Retrieves a specific gate by its unique identifier.
        /// </summary>
        /// <param name="gateId">The unique identifier of the gate to retrieve.</param>
        /// <returns>
        /// The task result contains the GetGateDTO if found; otherwise, null.
        /// </returns>
        Task<GetGateDTO> GetByIdAsync(int gateId);

        /// <summary>
        /// Creates a new gate record in the system.
        /// </summary>
        /// <param name="gateDto">The DTO containing details of the gate to create.</param>
        /// <returns>
        /// The task result contains the created GetAllDetailsGateDTO object.
        /// </returns>
        Task<GetAllDetailsGateDTO> CreateAsync(CreateAndUpdateGateDTO gateDto);

        /// <summary>
        /// Updates an existing gate record identified by its unique identifier.
        /// </summary>
        /// <param name="gateId">The unique identifier of the gate to update.</param>
        /// <param name="gateDto">The DTO containing updated gate details.</param>
        /// <returns>
        /// The task result contains the updated GetGateDTO object.
        /// </returns>
        Task<GetGateDTO> UpdateAsync(int gateId, CreateAndUpdateGateDTO gateDto);

        /// <summary>
        /// Deletes an existing gate record from the system.
        /// </summary>
        /// <param name="gateId">The unique identifier of the gate to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int gateId);
    }
}