
using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for LostAndFound service operations,
/// including retrieval, creation, updating, and deletion of LostAndFound records.
/// </summary>
public interface ILostAndFoundService
{
    /// <summary>
    /// Retrieves all LostAndFound records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of LostAndFound DTOs. </returns>
    Task<IList<GetLostAndFoundDTO>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific LostAndFound record by its unique identifier.
    /// </summary>
    /// <param name="loadAndFoundId">The unique identifier of the LostAndFound.</param>
    /// <returns>A task representing the asynchronous operation that returns the LostAndFound DTO.</returns>
    Task<GetLostAndFoundDTO> GetByIdAsync(int loadAndFoundId);
    /// <summary>
    /// Creates a new LostAndFound record.
    /// </summary>
    /// <param name="dto">The data transfer object containing LostAndFound details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created LostAndFound DTO.</returns>
    Task<GetLostAndFoundDTO> CreateAsync(CreateAndUpdateLostandFoundDTO dto);
    /// <summary>
    /// Updates an existing LostAndFound record.
    /// </summary>
    /// <param name="loadAndFoundId">The unique identifier of the LostAndFound to update.</param>
    /// <param name="dto">The data transfer object containing updated LostAndFound details.</param>
    /// <returns>A task representing the asynchronous operation that returns a GetLostAndFoundDto indicating success or failure.</returns>
    Task<GetLostAndFoundDTO> UpdateAsync(int loadAndFoundId, CreateAndUpdateLostandFoundDTO dto);
    /// <summary>
    /// Deletes a LostAndFound record by its unique identifier.
    /// </summary>
    /// <param name="loadAndFoundId">The unique identifier of the LostAndFound to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int loadAndFoundId);
}
