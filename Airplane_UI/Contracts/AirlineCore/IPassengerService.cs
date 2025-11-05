using Airplane_UI.DTOs.AirlineCore.PassengerDTOs;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing passenger-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting passenger data.
    /// </summary>
    public interface IPassengerService
    {
        /// <summary>
        /// Retrieves all passengers asynchronously.
        /// </summary>
        /// <returns> The task result contains a collection of GetPassengerDTO objects representing all passengers.</returns>
        Task<IEnumerable<GetPassengerDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific passenger by their unique identifier.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to retrieve.</param>
        /// <returns> The task result contains the GetPassengerDTO if found; otherwise, null.</returns>
        Task<GetPassengerDTO> GetByIdAsync(int passengerId);

        /// <summary>
        /// Creates a new passenger record asynchronously.
        /// </summary>
        /// <param name="dto">The data transfer object containing passenger details to create.</param>
        /// <returns> The task result contains the created GetPassengerDTO object.</returns>
        Task<GetPassengerDTO> CreateAsync(CreateAndUpdatePassengerDTO dto);

        /// <summary>
        /// Updates an existing passenger record by their unique identifier.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to update.</param>
        /// <param name="dto">The data transfer object containing updated passenger details.</param>
        /// <returns> The task result contains the updated GetPassengerDTO if successful; otherwise, null.</returns>
        Task<GetPassengerDTO?> UpdateAsync(int passengerId, CreateAndUpdatePassengerDTO dto);

        /// <summary>
        /// Deletes a passenger record by their unique identifier asynchronously.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to delete.</param>
        /// <returns> The task result is <c>true</c> if the deletion was successful; otherwise, false.</returns>
        Task<string> DeleteAsync(int passengerId);
    }
}
