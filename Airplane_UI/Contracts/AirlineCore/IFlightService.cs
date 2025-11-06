using Airplane_UI.DTOs.AirlineCore.FlightDTOs;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing flight-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting flight data.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// Retrieves all flights from the system.
        /// </summary>
        /// <returns> The task result contains a collection of GetFlightDTO objects. </returns>
        Task<IList<GetFlightDTO>> GetAllAsync();
        /// <summary>
        /// Retrieves a specific flight by its unique identifier.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to retrieve.</param>
        /// <returns> The task result contains the GetFlightDTO if found; otherwise, null. </returns>
        Task<GetFlightDTO> GetByIdAsync(int flightId);
        /// <summary>
        /// Creates a new flight record in the system.
        /// </summary>
        /// <param name="dto">The data transfer object containing details of the flight to create.</param>
        /// <returns> The task result contains the created GetFlightDTO object.</returns>
        Task<GetFlightDTO> CreateAsync(CreateAndUpdateFlightDTO dto);
        /// <summary>
        /// Updates an existing flight record identified by its unique identifier.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to update.</param>
        /// <param name="dto">The data transfer object containing updated flight details.</param>
        /// <returns> The task result indicates whether the update operation was successful.</returns>
        Task<GetFlightDTO> UpdateAsync(int flightId, CreateAndUpdateFlightDTO dto);
        /// <summary>
        /// Deletes an existing flight record from the system.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to delete.</param>
        /// <returns> The task result indicates whether the delete operation was successful.</returns>
        Task<string> DeleteAsync(int flightId);
    }
}
