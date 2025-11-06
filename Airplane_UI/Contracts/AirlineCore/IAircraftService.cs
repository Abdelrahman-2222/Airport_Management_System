using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing aircraft-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting airport data.
    /// </summary>
    public interface IAircraftService
    {
        /// <summary>
        /// Retrieves all aircrafts from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of AircraftDTOs objects.
        /// </returns>
        Task<IList<GetAircraftDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific aircraft by its unique identifier.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to retrieve.</param>
        /// <returns>
        /// The task result contains the AircraftDTOs if found; otherwise, null.
        /// </returns>
        Task<GetAircraftDTO> GetByIdAsync(int aircraftId);

        /// <summary>
        /// Creates a new aircraft record in the system.
        /// </summary>
        /// <param name="dto">The dto containing details of the aircraft to create.</param>
        /// <returns>
        /// The task result contains the created AircraftDTOs object.
        /// </returns>
        Task<GetAircraftDTO> CreateAsync(CreateAndUpdateAircraftDTO dto);

        /// <summary>
        /// Updates an existing aircraft record identified by its unique identifier.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to update.</param>
        /// <param name="dto">The dto containing updated aircraft details.</param>
        /// <returns>
        /// The task result indicates whether the update operation was successful.
        /// </returns>
        Task<GetAircraftDTO> UpdateAsync(int aircraftId, CreateAndUpdateAircraftDTO dto);

        /// <summary>
        /// Deletes an existing aircraft record from the system.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to delete.</param>
        /// <returns> A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
        Task<string> DeleteAsync(int aircraftId);
    }
}
