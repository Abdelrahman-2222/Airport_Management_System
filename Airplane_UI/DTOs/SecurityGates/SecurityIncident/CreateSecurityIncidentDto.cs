namespace Airplane_UI.DTOs.SecurityGates.SecurityIncident
{
    /// <summary>
    /// DTO for creating a new SecurityIncident.
    /// </summary>
    public class CreateSecurityIncidentDto
    {
        /// <summary>
        /// The location of the incident.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Details of the incident report.
        /// </summary>
        public string ReportDetails { get; set; }

        /// <summary>
        /// The severity of the incident.
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Optional: the ID of the staff assigned to this incident.
        /// </summary>
        public int? AssignedStaffID { get; set; }
    }
}
