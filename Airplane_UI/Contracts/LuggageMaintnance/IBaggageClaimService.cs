using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for baggage claim service operations,
/// including retrieval, creation, updating, and deletion of baggage claim records.
/// </summary>
public interface IBaggageClaimService
{
    /// <summary>
    /// Retrieves all baggage claim records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of baggage claim DTOs. </returns>
   	Task<IList<GetBaggageClaimDto>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific baggage claim record by its unique identifier.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim.</param>
    /// <returns>A task representing the asynchronous operation that returns the baggage claim DTO.</returns>
    Task<GetBaggageClaimDto> GetByIdAsync(int baggageId);
    /// <summary>
    /// Creates a new baggage claim record.
    /// </summary>
    /// <param name="dto">The data transfer object containing baggage claim details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created baggage claim DTO.</returns>
    Task<GetBaggageClaimDto> CreateAsync(CreateAndUpdateBaggageClaimDto dto);
    /// <summary>
    /// Updates an existing baggage claim record.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim to update.</param>
    /// <param name="dto">The data transfer object containing updated baggage claim details.</param>
    /// <returns>A task representing the asynchronous operation that returns a GetBaggageClaimDto indicating success or failure.</returns>
    Task<GetBaggageClaimDto> UpdateAsync(int baggageId, CreateAndUpdateBaggageClaimDto dto);
    /// <summary>
    /// Deletes a baggage claim record by its unique identifier.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int baggageId);
}