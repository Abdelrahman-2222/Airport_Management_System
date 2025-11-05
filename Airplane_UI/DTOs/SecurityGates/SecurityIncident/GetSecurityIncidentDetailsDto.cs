namespace Airplane_UI.DTOs.SecurityGates.SecurityIncident
{
    /// <summary>
    /// DTO for SecurityIncident with assigned staff information.
    /// </summary>
    public class GetSecurityIncidentDetailsDto
    {
        /// <summary>
        /// The unique identifier of the security incident.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the staff member assigned to this incident, if any.
        /// </summary>
        public int? AssignedStaffID { get; set; }

        /// <summary>
        /// The full name of the assigned staff member.
        /// </summary>
        public string AssignedStaffName { get; set; }

        /// <summary>
        /// The location where the incident occurred.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date and time when the incident occurred.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Detailed report describing the incident.
        /// </summary>
        public string ReportDetails { get; set; }

        /// <summary>
        /// The severity level of the incident (e.g., Low, Medium, High).
        /// </summary>
        public string Severity { get; set; }
    }
}
