using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Airplane_UI.Entities.SecurityGates;
using System;
using System.Linq;

namespace Airplane_UI.Mappers.SecurityGates
{
    ///
    /// Provides mapping logic for SecurityIncident entity and its DTOs.
    ///
    public static class SecurityIncidentMapper
    {
        ///
        /// Converts a SecurityIncident entity to its Get DTO.
        ///
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
        /// Converts a SecurityIncident entity to a detailed DTO including staff info.
        /// </summary>
        public static GetSecurityIncidentDetailsDto ToDetailsDto(this SecurityIncident incident)
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
        /// Converts a CreateSecurityIncidentDto to a SecurityIncident entity.
        /// </summary>
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
        /// Updates an existing SecurityIncident entity using Update DTO.
        /// </summary>
        public static void UpdateEntity(this SecurityIncident incident, UpdateSecurityIncidentDto dto)
        {
            incident.AssignedStaffID = dto.AssignedStaffID;
            incident.ReportDetails = dto.ReportDetails;
            incident.Severity = dto.Severity;
        }
    }

}