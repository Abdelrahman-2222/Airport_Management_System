using Airplane_UI.DTOs.GateAssignments.RunwayDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing runway-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting runway data.
    /// </summary>
    public interface IRunwayService
    {
        /// <summary>
        /// Retrieves all runways from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetRunwayDTO objects.
        /// </returns>
        Task<IList<GetRunwayDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all runways with their full details from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetAllDetailsRunwayDTO objects.
        /// </returns>
        Task<IList<GetAllDetailsRunwayDTO>> GetDetailsAsync();

        /// <summary>
        /// Retrieves a specific runway by its unique identifier.
        /// </summary>
        /// <param name="runwayId">The unique identifier of the runway to retrieve.</param>
        /// <returns>
        /// The task result contains the GetRunwayDTO if found; otherwise, null.
        /// </returns>
        Task<GetRunwayDTO> GetByIdAsync(int runwayId);

        /// <summary>
        /// Creates a new runway record in the system.
        /// </summary>
        /// <param name="runwayDto">The DTO containing details of the runway to create.</param>
        /// <returns>
        /// The task result contains the created GetAllDetailsRunwayDTO object.
        /// </returns>
        Task<GetAllDetailsRunwayDTO> CreateAsync(CreateAndUpdateRunwayDTO runwayDto);

        /// <summary>
        /// Updates an existing runway record identified by its unique identifier.
        /// </summary>
        /// <param name="runwayId">The unique identifier of the runway to update.</param>
        /// <param name="runwayDto">The DTO containing updated runway details.</param>
        /// <returns>
        /// The task result contains the updated GetRunwayDTO object.
        /// </returns>
        Task<GetRunwayDTO> UpdateAsync(int runwayId, CreateAndUpdateRunwayDTO runwayDto);

        /// <summary>
        /// Deletes an existing runway record from the system.
        /// </summary>
        /// <param name="runwayId">The unique identifier of the runway to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int runwayId);
    }
}