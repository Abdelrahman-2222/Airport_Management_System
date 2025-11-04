namespace Airplane_UI.DTOs.SecurityGates.CustomsDesk
{
    /// <summary>
    /// Represents the data required to create a new customs desk.
    /// </summary>
    public class CreateCustomsDeskDto
    {
        /// <summary>
        /// Gets or sets the terminal ID where the new customs desk will be located.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Gets or sets the unique number assigned to the new customs desk.
        /// </summary>
        public string DeskNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial operational status of the new desk.
        /// </summary>
        public string Status { get; set; } = "Active";
    }
}
