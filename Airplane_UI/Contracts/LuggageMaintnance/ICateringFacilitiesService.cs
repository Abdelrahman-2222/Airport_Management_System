
using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;

namespace Airplane_UI.Contracts.LuggageMaintnance;
/// <summary>
/// Defines the contract for CateringFacilities service operations,
/// including retrieval, creation, updating, and deletion of CateringFacilities records.
/// </summary>
public interface ICateringFacilitiesService
{
    /// <summary>
    /// Retrieves all CateringFacilities records asynchronously.
    /// </summary>
    /// <returns> A task representing the asynchronous operation that returns a collection of CateringFacilities DTOs. </returns>
    Task<IList<GetCateringFacilitiesDTO>> GetAllAsync();
    /// <summary>
    /// Retrieves a specific CateringFacilities record by its unique identifier.
    /// </summary>
    /// <param name="cateringFacilitieId">The unique identifier of the CateringFacilities.</param>
    /// <returns>A task representing the asynchronous operation that returns the CateringFacilities DTO.</returns>
    Task<GetCateringFacilitiesDTO> GetByIdAsync(int cateringFacilitieId);
    /// <summary>
    /// Creates a new CateringFacilities record.
    /// </summary>
    /// <param name="dto">The data transfer object containing CateringFacilities details.</param>
    /// <returns>A task representing the asynchronous operation that returns the created CateringFacilities DTO.</returns>
    Task<GetCateringFacilitiesDTO> CreateAsync(CreateAndUpdateCateringFacilitiesDTO dto);
    /// <summary>
    /// Updates an existing CateringFacilities record.
    /// </summary>
    /// <param name="cateringFacilitieId">The unique identifier of the CateringFacilities to update.</param>
    /// <param name="dto">The data transfer object containing updated CateringFacilities details.</param>
    /// <returns>A task representing the asynchronous operation that returns a GetBaggageClaimDto indicating success or failure.</returns>
    Task<GetCateringFacilitiesDTO> UpdateAsync(int cateringFacilitieId, CreateAndUpdateCateringFacilitiesDTO dto);
    /// <summary>
    /// Deletes a CateringFacilities record by its unique identifier.
    /// </summary>
    /// <param name="cateringFacilitieId">The unique identifier of the CateringFacilities to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a string indicating success or failure.</returns>
    Task<string> DeleteAsync(int cateringFacilitieId);
}
