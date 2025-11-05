namespace Airplane_UI.DTOs.SecurityGates.SecurityIncident
{
    /// <summary>
    /// Data Transfer Object for SecurityIncident entity.
    /// </summary>
    public class GetSecurityIncidentDto
    {
        /// <summary>
        /// The unique identifier of the security incident.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the staff assigned to handle this incident.
        /// </summary>
        public int? AssignedStaffID { get; set; }

        /// <summary>
        /// The location where the incident occurred.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date and time of the incident.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Details of the incident report.
        /// </summary>
        public string ReportDetails { get; set; }

        /// <summary>
        /// The severity level of the incident.
        /// </summary>
        public string Severity { get; set; }
    }
}
