
using Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for CateringOrder service operations,
/// including retrieval, creation, updating, and deletion of CateringOrder records.
/// </summary>
public interface ICateringOrderService
{
    /// <summary>
    /// Retrieves all CateringOrder records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of CateringOrder DTOs. </returns>
    Task<IList<GetCateringOrderDTO>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific CateringOrder record by its unique identifier.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the CateringOrder.</param>
    /// <returns>A task representing the asynchronous operation that returns the CateringOrder DTO.</returns>
    Task<GetCateringOrderDTO> GetByIdAsync(int cateringOrderId);
    /// <summary>
    /// Creates a new CateringOrder record.
    /// </summary>
    /// <param name="dto">The data transfer object containing CateringOrder details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created CateringOrder DTO.</returns>
    Task<GetCateringOrderDTO> CreateAsync(CreateAndUpdateCateringOrderDTO dto);
    /// <summary>
    /// Updates an existing CateringOrder record.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the CateringOrder to update.</param>
    /// <param name="dto">The data transfer object containing updated CateringOrder details.</param>
    /// <returns>A task representing the asynchronous operation that returns a GetBaggageClaimDto indicating success or failure.</returns>
    Task<GetCateringOrderDTO> UpdateAsync(int cateringOrderId, CreateAndUpdateCateringOrderDTO dto);
    /// <summary>
    /// Deletes a CateringOrder record by its unique identifier.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the CateringOrder to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int cateringOrderId);
}
