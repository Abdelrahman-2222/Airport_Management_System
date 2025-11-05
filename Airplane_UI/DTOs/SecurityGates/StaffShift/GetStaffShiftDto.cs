namespace Airplane_UI.DTOs.SecurityGates.StaffShift
{
    /// <summary>
    /// Represents a staff shift record containing assigned locations and time range.
    /// </summary>
    public class GetStaffShiftDto
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
        /// Identifier of the assigned security checkpoint, if applicable.
        /// </summary>
        public int? AssignedCheckpointID { get; set; }

        /// <summary>
        /// Identifier of the assigned desk, if applicable.
        /// </summary>
        public int? AssignedDeskID { get; set; }

        /// <summary>
        /// The start time of the staff shift.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the staff shift.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}