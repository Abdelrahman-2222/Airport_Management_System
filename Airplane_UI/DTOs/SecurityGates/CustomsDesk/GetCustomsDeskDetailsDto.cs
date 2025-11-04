namespace Airplane_UI.DTOs.SecurityGates.CustomsDesk
{
    /// <summary>
    /// Represents a detailed DTO for a customs desk including assigned staff and related shift information.
    /// </summary>
    public class GetCustomsDeskDetailsDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customs desk.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the terminal ID where this desk is located.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Gets or sets the unique number identifying this desk.
        /// </summary>
        public string DeskNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the operational status of the desk.
        /// </summary>
        public string Status { get; set; } = "Active";

        /// <summary>
        /// Gets or sets a collection of staff shift assignments associated with this desk.
        /// </summary>
        public ICollection<StaffShiftDto> AssignedShifts { get; set; } = new List<StaffShiftDto>();
    }
}
