using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing gate assignment-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting gate assignment data.
    /// </summary>
    public interface IGateAssignmentService
    {
        /// <summary>
        /// Retrieves all gate assignments from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetGateAssignmentDTO objects.
        /// </returns>
        Task<IList<GetGateAssignmentDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all gate assignments with their full details from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetAllDetailsGateAssignmentDTO objects.
        /// </returns>
        Task<IList<GetAllDetailsGateAssignmentDTO>> GetDetailsAsync();

        /// <summary>
        /// Retrieves a specific gate assignment by its unique identifier.
        /// </summary>
        /// <param name="gateAssignmentId">The unique identifier of the gate assignment to retrieve.</param>
        /// <returns>
        /// The task result contains the GetGateAssignmentDTO if found; otherwise, null.
        /// </returns>
        Task<GetGateAssignmentDTO> GetByIdAsync(int gateAssignmentId);

        /// <summary>
        /// Creates a new gate assignment record in the system.
        /// </summary>
        /// <param name="gateAssignmentDto">The DTO containing details of the gate assignment to create.</param>
        /// <returns>
        /// The task result contains the created GetAllDetailsGateAssignmentDTO object.
        /// </returns>
        Task<GetAllDetailsGateAssignmentDTO> CreateAsync(CreateAndUpdateGateAssignmentDTO gateAssignmentDto);

        /// <summary>
        /// Updates an existing gate assignment record identified by its unique identifier.
        /// </summary>
        /// <param name="gateAssignmentId">The unique identifier of the gate assignment to update.</param>
        /// <param name="gateAssignmentDto">The DTO containing updated gate assignment details.</param>
        /// <returns>
        /// The task result contains the updated GetGateAssignmentDTO object.
        /// </returns>
        Task<GetGateAssignmentDTO> UpdateAsync(int gateAssignmentId, CreateAndUpdateGateAssignmentDTO gateAssignmentDto);

        /// <summary>
        /// Deletes an existing gate assignment record from the system.
        /// </summary>
        /// <param name="gateAssignmentId">The unique identifier of the gate assignment to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int gateAssignmentId);
    }
}