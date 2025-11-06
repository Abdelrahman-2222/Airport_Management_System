using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mappers.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Service implementation for managing security incidents.
    /// Provides CRUD operations for SecurityIncident entities.
    /// </summary>
    public class SecurityIncidentService : ISecurityIncidentService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="SecurityIncidentService"/>.
        /// </summary>
        /// <param name="context">The database context for accessing security incidents.</param>
        public SecurityIncidentService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<List<GetSecurityIncidentDto>> GetAllAsync()
        {
            var incidents = await _context.SecurityIncidents
                .Include(si => si.AssignedStaff)
                .ToListAsync();
            return incidents.Select(si => si.ToGetDto()).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityIncidentDto?> GetByIdAsync(int SecurityIncidentId)
        {
            var incident = await _context.SecurityIncidents
                .Include(si => si.AssignedStaff)
                .FirstOrDefaultAsync(si => si.Id == SecurityIncidentId);
            return incident?.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityIncidentDto> CreateAsync(CreateSecurityIncidentDto dto)
        {
            var incident = dto.ToEntity();
            _context.SecurityIncidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityIncidentDto?> UpdateAsync(int SecurityIncidentId, UpdateSecurityIncidentDto dto)
        {
            var incident = await _context.SecurityIncidents
                .FirstOrDefaultAsync(si => si.Id == SecurityIncidentId);
            if (incident == null)
                return null;
            dto.UpdateEntity(incident);
            await _context.SaveChangesAsync();
            return incident.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int SecurityIncidentId)
        {
            var incident = await _context.SecurityIncidents
                .FirstOrDefaultAsync(si => si.Id == SecurityIncidentId);

            if (incident == null)
                return $"Security incident with ID {SecurityIncidentId} not found";

            _context.SecurityIncidents.Remove(incident);
            await _context.SaveChangesAsync();

            return $"Security incident with ID {SecurityIncidentId} deleted successfully";
        }
    }

}
