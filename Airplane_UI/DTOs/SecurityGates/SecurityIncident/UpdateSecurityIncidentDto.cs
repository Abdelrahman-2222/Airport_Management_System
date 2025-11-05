namespace Airplane_UI.DTOs.SecurityGates.SecurityIncident
{
    /// <summary>
    /// DTO for updating an existing SecurityIncident.
    /// </summary>
    public class UpdateSecurityIncidentDto
    {
        /// <summary>
        /// Optional: the ID of the staff assigned to this incident.
        /// </summary>
        public int? AssignedStaffID { get; set; }

        /// <summary>
        /// Updated details of the incident report.
        /// </summary>
        public string ReportDetails { get; set; }

        /// <summary>
        /// Updated severity of the incident.
        /// </summary>
        public string Severity { get; set; }
    }
}
