using Airplane_UI.DTOs.GateAssignments.GroundCrewTeamDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing ground crew team-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting ground crew team data.
    /// </summary>
    public interface IGroundCrewTeamService
    {
        /// <summary>
        /// Retrieves all ground crew teams from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetGroundCrewTeamDTO objects.
        /// </returns>
        Task<IList<GetGroundCrewTeamDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific ground crew team by its unique identifier.
        /// </summary>
        /// <param name="groundCrewTeamId">The unique identifier of the ground crew team to retrieve.</param>
        /// <returns>
        /// The task result contains the GetGroundCrewTeamDTO if found; otherwise, null.
        /// </returns>
        Task<GetGroundCrewTeamDTO> GetByIdAsync(int groundCrewTeamId);

        /// <summary>
        /// Creates a new ground crew team record in the system.
        /// </summary>
        /// <param name="groundCrewTeamDto">The DTO containing details of the ground crew team to create.</param>
        /// <returns>
        /// The task result contains the created GetGroundCrewTeamDTO object.
        /// </returns>
        Task<GetGroundCrewTeamDTO> CreateAsync(CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto);

        /// <summary>
        /// Updates an existing ground crew team record identified by its unique identifier.
        /// </summary>
        /// <param name="groundCrewTeamId">The unique identifier of the ground crew team to update.</param>
        /// <param name="groundCrewTeamDto">The DTO containing updated ground crew team details.</param>
        /// <returns>
        /// The task result contains the updated GetGroundCrewTeamDTO object.
        /// </returns>
        Task<GetGroundCrewTeamDTO> UpdateAsync(int groundCrewTeamId, CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto);

        /// <summary>
        /// Deletes an existing ground crew team record from the system.
        /// </summary>
        /// <param name="groundCrewTeamId">The unique identifier of the ground crew team to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int groundCrewTeamId);
    }
}