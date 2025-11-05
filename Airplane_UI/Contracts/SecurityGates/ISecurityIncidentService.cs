using Airplane_UI.DTOs.SecurityGates.SecurityIncident;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines CRUD operations for managing security incidents in the airport system.
    /// </summary>
    public interface ISecurityIncidentService
    {
        /// <summary>
        /// Retrieves all recorded security incidents.
        /// </summary>
        Task<List<GetSecurityIncidentDto>> GetAllAsync();

        /// <summary>
        /// Retrieves details of a specific security incident.
        /// </summary>
        Task<GetSecurityIncidentDto?> GetByIdAsync(int SecurityIncidentId);

        /// <summary>
        /// Creates a new security incident record.
        /// </summary>
        Task<GetSecurityIncidentDto> CreateAsync(CreateSecurityIncidentDto dto);

        /// <summary>
        /// Updates an existing security incident record.
        /// </summary>
        Task<GetSecurityIncidentDto?> UpdateAsync(int SecurityIncidentId, UpdateSecurityIncidentDto dto);

        /// <summary>
        /// Deletes a security incident record by its ID.
        /// </summary>
        Task<string> DeleteAsync(int SecurityIncidentId);
    }
}
