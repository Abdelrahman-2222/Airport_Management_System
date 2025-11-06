using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing runway schedule-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting runway schedule data.
    /// </summary>
    public interface IRunwayScheduleService
    {
        /// <summary>
        /// Retrieves all runway schedules from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetRunwayScheduleDTO objects.
        /// </returns>
        Task<IList<GetRunwayScheduleDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all runway schedules with their full details from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetAllDetailsRunwayScheduleDTO objects.
        /// </returns>
        Task<IList<GetAllDetailsRunwayScheduleDTO>> GetDetailsAsync();

        /// <summary>
        /// Retrieves a specific runway schedule by its unique identifier.
        /// </summary>
        /// <param name="runwayScheduleId">The unique identifier of the runway schedule to retrieve.</param>
        /// <returns>
        /// The task result contains the GetRunwayScheduleDTO if found; otherwise, null.
        /// </returns>
        Task<GetRunwayScheduleDTO> GetByIdAsync(int runwayScheduleId);

        /// <summary>
        /// Creates a new runway schedule record in the system.
        /// </summary>
        /// <param name="runwayScheduleDto">The DTO containing details of the runway schedule to create.</param>
        /// <returns>
        /// The task result contains the created GetAllDetailsRunwayScheduleDTO object.
        /// </returns>
        Task<GetAllDetailsRunwayScheduleDTO> CreateAsync(CreateAndUpdateRunwayScheduleDTO runwayScheduleDto);

        /// <summary>
        /// Updates an existing runway schedule record identified by its unique identifier.
        /// </summary>
        /// <param name="runwayScheduleId">The unique identifier of the runway schedule to update.</param>
        /// <param name="runwayScheduleDto">The DTO containing updated runway schedule details.</param>
        /// <returns>
        /// The task result contains the updated GetRunwayScheduleDTO object.
        /// </returns>
        Task<GetRunwayScheduleDTO> UpdateAsync(int runwayScheduleId, CreateAndUpdateRunwayScheduleDTO runwayScheduleDto);

        /// <summary>
        /// Deletes an existing runway schedule record from the system.
        /// </summary>
        /// <param name="runwayScheduleId">The unique identifier of the runway schedule to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int runwayScheduleId);
    }
}