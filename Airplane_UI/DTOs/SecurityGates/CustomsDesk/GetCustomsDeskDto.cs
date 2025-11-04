namespace Airplane_UI.DTOs.SecurityGates.CustomsDesk
{
    /// <summary>
    /// Represents a simplified data transfer object for a customs desk in an airport terminal.
    /// </summary>
    public class GetCustomsDeskDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customs desk.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the terminal this desk belongs to.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Gets or sets the unique number identifying this customs desk.
        /// </summary>
        public string DeskNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current operational status of the desk (e.g., Active, Closed, Maintenance).
        /// </summary>
        public string Status { get; set; } = "Active";
    }
}
