using Airplane_API.DTOs.AirlineCore.AirportDTOs;

namespace Airplane_API.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing airport-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting airport data.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Retrieves all airports from the system asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of GetAirportDTO objects.
        /// </returns>
        Task<IList<GetAirportDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific airport by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the airport to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the GetAirportDTO if found; otherwise, <c>null</c>.
        /// </returns>
        Task<GetAirportDTO> GetyByIdAsync(int id);

        /// <summary>
        /// Creates a new airport record in the system asynchronously.
        /// </summary>
        /// <param name="dto">The data transfer object containing details of the airport to create.</param>
        /// <returns>
        /// The task result contains the newly created GetAirportDTO.
        /// </returns>
        Task<GetAirportDTO> CreateAsync(CreateAndUpdateAirportDTO dto);

        /// <summary>
        /// Updates an existing airport record identified by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the airport to update.</param>
        /// <param name="dto">The data transfer object containing updated airport details.</param>
        /// <returns>
        /// The task result contains the updated GetAirportDTO if the operation was successful; otherwise, null.
        /// </returns>
        Task<GetAirportDTO> UpdateAsync(int id, CreateAndUpdateAirportDTO dto);

        /// <summary>
        /// Deletes an existing airport record from the system asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the airport to delete.</param>
        /// <returns>
        /// The task result contains a message indicating whether the delete operation was successful.
        /// </returns>
        Task<string> DeleteAsync(int id);
    }
}
