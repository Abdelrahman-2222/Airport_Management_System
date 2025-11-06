using Airplane_UI.DTOs.AirlineCore.AirportDTOs;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing airport-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting airport data.
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Retrieves all airports from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of AirportDTOs objects.
        /// </returns>
        Task<IList<GetAirportDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific airport by its unique identifier.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to retrieve.</param>
        /// <returns>
        /// The task result contains the AirportDTOs if found; otherwise, null.
        /// </returns>
        Task<GetAirportDTO> GetyByIdAsync(int airportId);

        /// <summary>
        /// Creates a new airport record in the system.
        /// </summary>
        /// <param name="dto">The data transfer object containing details of the airport to create.</param>
        /// <returns>
        /// The task result contains the created AirportDTOs object.
        /// </returns>
        Task<GetAirportDTO> CreateAsync(CreateAndUpdateAirportDTO dto);

        /// <summary>
        /// Updates an existing airport record identified by its unique identifier.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to update.</param>
        /// <param name="dto">The data transfer object containing updated airport details.</param>
        /// <returns>
        /// The task result indicates whether the update operation was successful.
        /// </returns>
        Task<GetAirportDTO> UpdateAsync(int airportId, CreateAndUpdateAirportDTO dto);

        /// <summary>
        /// Deletes an existing airport record from the system.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to delete.</param>
        /// <returns>
        /// The task result indicates whether the delete operation was successful.
        /// </returns>
        Task<string> DeleteAsync(int airportId);
    }
}
