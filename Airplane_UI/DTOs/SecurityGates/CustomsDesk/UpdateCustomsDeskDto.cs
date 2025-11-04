namespace Airplane_UI.DTOs.SecurityGates.CustomsDesk
{
    /// <summary>
    /// Represents the data used to update an existing customs desk.
    /// </summary>
    public class UpdateCustomsDeskDto
    {
        /// <summary>
        /// Gets or sets the updated desk number.
        /// </summary>
        public string DeskNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated operational status of the desk.
        /// </summary>
        public string Status { get; set; } = "Active";
    }
}
