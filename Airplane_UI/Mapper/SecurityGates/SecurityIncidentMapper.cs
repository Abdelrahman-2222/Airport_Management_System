using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Airplane_UI.Entities.SecurityGates;
using System;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping methods between SecurityIncident entities and their corresponding DTOs.
    /// </summary>
    public static class SecurityIncidentMapper
    {
        /// <summary>
        /// Converts a SecurityIncident entity to a GetSecurityIncidentDto.
        /// </summary>
        /// <param name="incident">The SecurityIncident entity to convert.</param>
        /// <returns>
        /// A GetSecurityIncidentDto containing basic incident information.
        /// </returns>
        public static GetSecurityIncidentDto ToGetDto(this SecurityIncident incident)
        {
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
        /// Converts a SecurityIncident entity to a GetSecurityIncidentDetailsDto,
        /// including related staff information when available.
        /// </summary>
        /// <param name="incident">The SecurityIncident entity to convert.</param>
        /// <returns>
        /// A GetSecurityIncidentDetailsDto containing detailed incident information.
        /// </returns>
        public static GetSecurityIncidentDetailsDto ToDetailsDTO(this SecurityIncident incident)
        {
            return new GetSecurityIncidentDetailsDto
            {
                Id = incident.Id,
                AssignedStaffID = incident.AssignedStaffID,
                AssignedStaffName = incident.AssignedStaff != null
                                    ? $"{incident.AssignedStaff.Name}"
                                    : null,
                Location = incident.Location,
                Time = incident.Time,
                ReportDetails = incident.ReportDetails,
                Severity = incident.Severity
            };
        }

        /// <summary>
        /// Converts a CreateSecurityIncidentDto to a new SecurityIncident entity.
        /// </summary>
        /// <param name="dto">The DTO containing data for creating a new incident record.</param>
        /// <returns>
        /// A new SecurityIncident entity populated with data from the DTO.
        /// </returns>
        public static SecurityIncident ToEntity(this CreateSecurityIncidentDto dto)
        {
            return new SecurityIncident
            {
                AssignedStaffID = dto.AssignedStaffID,
                Location = dto.Location,
                Time = DateTime.UtcNow,
                ReportDetails = dto.ReportDetails,
                Severity = dto.Severity
            };
        }

        /// <summary>
        /// Updates an existing SecurityIncident entity using data from an UpdateSecurityIncidentDto.
        /// </summary>
        /// <param name="dto">The DTO containing updated incident data.</param>
        /// <param name="entity">The existing SecurityIncident entity to update.</param>
        public static void UpdateEntity(this UpdateSecurityIncidentDto dto, SecurityIncident entity)
        {
            if (entity == null || dto == null) return;

            entity.AssignedStaffID = dto.AssignedStaffID;
            entity.ReportDetails = dto.ReportDetails;
            entity.Severity = dto.Severity;
        }
    }
}
