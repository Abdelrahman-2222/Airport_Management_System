using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Airplane_UI.DTOs.AirlineCore.AirportDTOs;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing airline-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting airport data.
    /// </summary>
    public interface IAirlineService
    {
        /// <summary>
        /// Retrieves all airlines from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of AirlineDTOs objects.
        /// </returns>
        Task<IList<GetAirlineDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific airline by its unique identifier.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to retrieve.</param>
        /// <returns>
        /// The task result contains the AirlineDTOs if found; otherwise, null.
        /// </returns>
        Task<GetAirlineDTO> GetByIdAsync(int airlineId);

        /// <summary>
        /// Creates a new airline record in the system.
        /// </summary>
        /// <param name="dto">The data transfer object containing details of the airline to create.</param>
        /// <returns>
        /// The task result contains the created AirlineDTOs object.
        /// </returns>
        Task<GetAirlineDTO> CreateAsync(CreateAndUpdateAirlineDTO dto);

        /// <summary>
        /// Updates an existing airline record identified by its unique identifier.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to update.</param>
        /// <param name="dto">The data transfer object containing updated airline details.</param>
        /// <returns>
        /// The task result indicates whether the update operation was successful.
        /// </returns>
        Task<GetAirlineDTO> UpdateAsync(int airlineId, CreateAndUpdateAirlineDTO dto);

        /// <summary>
        /// Deletes an existing airline record from the system.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to delete.</param>
        /// <returns>
        /// The task result indicates whether the delete operation was successful.
        /// </returns>
        Task<string> DeleteAsync(int airlineId);
    }
}
