using Airplane_UI.DTOs.SecurityGates.SecurityIncident;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines the contract for managing security incident-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting security incident data.
    /// </summary>
    public interface ISecurityIncidentService
    {
        /// <summary>
        /// Retrieves all security incidents from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetSecurityIncidentDto objects.
        /// </returns>
        Task<List<GetSecurityIncidentDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific security incident by its unique identifier.
        /// </summary>
        /// <param name="securityIncidentId">The unique identifier of the security incident to retrieve.</param>
        /// <returns>
        /// The task result contains the GetSecurityIncidentDto if found; otherwise, null.
        /// </returns>
        Task<GetSecurityIncidentDto> GetByIdAsync(int securityIncidentId);

        /// <summary>
        /// Creates a new security incident record in the system.
        /// </summary>
        /// <param name="dto">The DTO containing details of the security incident to create.</param>
        /// <returns>
        /// The task result contains the created GetSecurityIncidentDto object.
        /// </returns>
        Task<GetSecurityIncidentDto> CreateAsync(CreateSecurityIncidentDto dto);

        /// <summary>
        /// Updates an existing security incident record identified by its unique identifier.
        /// </summary>
        /// <param name="securityIncidentId">The unique identifier of the security incident to update.</param>
        /// <param name="dto">The DTO containing updated security incident details.</param>
        /// <returns>
        /// The task result contains the updated GetSecurityIncidentDto object.
        /// </returns>
        Task<GetSecurityIncidentDto> UpdateAsync(int securityIncidentId, UpdateSecurityIncidentDto dto);

        /// <summary>
        /// Deletes an existing security incident record from the system.
        /// </summary>
        /// <param name="securityIncidentId">The unique identifier of the security incident to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int securityIncidentId);
    }
}