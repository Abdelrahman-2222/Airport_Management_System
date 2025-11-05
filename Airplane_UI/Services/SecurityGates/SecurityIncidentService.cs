using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using System;

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

        /// <summary>
        /// Retrieves all recorded security incidents.
        /// </summary>
        /// <returns>A list of <see cref="GetSecurityIncidentDto"/> representing all incidents.</returns>
        public async Task<List<GetSecurityIncidentDto>> GetAllAsync()
        {
            return await _context.SecurityIncidents
                .Select(si => new GetSecurityIncidentDto
                {
                    Id = si.Id,
                    AssignedStaffID = si.AssignedStaffID,
                    Location = si.Location,
                    Time = si.Time,
                    ReportDetails = si.ReportDetails,
                    Severity = si.Severity
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves details of a specific security incident by its ID.
        /// </summary>
        /// <param name="SecurityIncidentId">The unique identifier of the incident.</param>
        /// <returns>The corresponding <see cref="GetSecurityIncidentDto"/> if found; otherwise, null.</returns>
        public async Task<GetSecurityIncidentDto?> GetByIdAsync(int SecurityIncidentId)
        {
            var incident = await _context.SecurityIncidents
                .FirstOrDefaultAsync(si => si.Id == SecurityIncidentId);

            if (incident == null)
                return null;

            return new GetSecurityIncidentDto
            {
                Id = incident.Id,
                AssignedStaffID = incident.AssignedStaffID,
                Location = incident.Location,
                Time = incident.Time,
                ReportDetails = incident.ReportDetails,
                Severity = incident.Severity
            };
        }

        /// <summary>
        /// Creates a new security incident record.
        /// </summary>
        /// <param name="dto">The data for the new security incident.</param>
        /// <returns>The created <see cref="GetSecurityIncidentDto"/>.</returns>
        public async Task<GetSecurityIncidentDto> CreateAsync(CreateSecurityIncidentDto dto)
        {
            var incident = new SecurityIncident
            {
                AssignedStaffID = dto.AssignedStaffID,
                Location = dto.Location,
                Time = DateTime.UtcNow,
                ReportDetails = dto.ReportDetails,
                Severity = dto.Severity
            };

            _context.SecurityIncidents.Add(incident);
            await _context.SaveChangesAsync();

            return new GetSecurityIncidentDto
            {
                Id = incident.Id,
                AssignedStaffID = incident.AssignedStaffID,
                Location = incident.Location,
                Time = incident.Time,
                ReportDetails = incident.ReportDetails,
                Severity = incident.Severity
            };
        }

        /// <summary>
        /// Updates an existing security incident record.
        /// </summary>
        /// <param name="SecurityIncidentId">The ID of the incident to update.</param>
        /// <param name="dto">The updated data for the incident.</param>
        /// <returns>The updated <see cref="GetSecurityIncidentDto"/> if the incident exists; otherwise, null.</returns>
        public async Task<GetSecurityIncidentDto?> UpdateAsync(int SecurityIncidentId, UpdateSecurityIncidentDto dto)
        {
            var incident = await _context.SecurityIncidents
                .FirstOrDefaultAsync(si => si.Id == SecurityIncidentId);

            if (incident == null)
                return null;

            incident.AssignedStaffID = dto.AssignedStaffID;
            incident.ReportDetails = dto.ReportDetails;
            incident.Severity = dto.Severity;

            await _context.SaveChangesAsync();

            return new GetSecurityIncidentDto
            {
                Id = incident.Id,
                AssignedStaffID = incident.AssignedStaffID,
                Location = incident.Location,
                Time = incident.Time,
                ReportDetails = incident.ReportDetails,
                Severity = incident.Severity
            };
        }

        /// <summary>
        /// Deletes a security incident record by its ID.
        /// </summary>
        /// <param name="SecurityIncidentId">The ID of the incident to delete.</param>
        /// <returns>A string message indicating success or that the incident was not found.</returns>
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
