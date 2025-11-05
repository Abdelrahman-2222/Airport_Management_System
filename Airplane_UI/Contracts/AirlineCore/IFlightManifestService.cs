using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;

namespace Airplane_UI.Contracts.AirlineCore
{
    /// <summary>
    /// Defines the contract for managing flight manifest records,
    /// including operations for creating, retrieving, updating, and deleting manifests.
    /// </summary>
    public interface IFlightManifestService
    {
        /// <summary>
        /// Retrieves all flight manifest records asynchronously.
        /// </summary>
        /// <returns> The task result contains a list of GetFlightManifestDTO objects. </returns>
        Task<IList<GetFlightManifestDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific flight manifest record by its unique identifier.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to retrieve.</param>
        /// <returns> The task result contains a GetFlightManifestDTO object representing the requested flight manifest.</returns>
        Task<GetFlightManifestDTO> GetByIdAsync(int flightManifestId);

        /// <summary>
        /// Creates a new flight manifest record asynchronously.
        /// </summary>
        /// <param name="dto">The data transfer object containing the details of the flight manifest to create.</param>
        /// <returns> The task result contains the created GetFlightManifestDTO object. </returns>
        Task<GetFlightManifestDTO> CreateAsync(CreateAndUpdateFlightManifestDTO dto);

        /// <summary>
        /// Updates an existing flight manifest record asynchronously.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to update.</param>
        /// <param name="dto">The data transfer object containing the updated flight manifest details.</param>
        /// <returns> The task result contains the updated GetFlightManifestDTO object if the update is successful;otherwise, null. </returns>
        Task<GetFlightManifestDTO> UpdateAsync(int flightManifestId, CreateAndUpdateFlightManifestDTO dto);

        /// <summary>
        /// Deletes an existing flight manifest record asynchronously.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to delete.</param>
        /// <returns> The task result contains a message describing the result of the deletion.</returns>
        Task<string> DeleteAsync(int flightManifestId);
    }
}