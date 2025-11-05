namespace Airplane_UI.DTOs.SecurityGates.StaffShift
{
    /// <summary>
    /// Detailed Data Transfer Object representing a staff shift with related staff and location info.
    /// </summary>
    public class GetStaffShiftDetailsDto
    {
        /// <summary>
        /// Unique identifier for the staff shift.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the staff member assigned to this shift.
        /// </summary>
        public int StaffID { get; set; }

        /// <summary>
        /// Full name of the staff member.
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// Identifier of the assigned checkpoint, if applicable.
        /// </summary>
        public int? AssignedCheckpointID { get; set; }

        /// <summary>
        /// Name of the assigned checkpoint.
        /// </summary>
        public string CheckpointName { get; set; }

        /// <summary>
        /// Identifier of the assigned desk, if applicable.
        /// </summary>
        public int? AssignedDeskID { get; set; }

        /// <summary>
        /// Number or label of the assigned desk.
        /// </summary>
        public string DeskNumber { get; set; }

        /// <summary>
        /// The start time of the shift.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the shift.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The duration of the shift.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
