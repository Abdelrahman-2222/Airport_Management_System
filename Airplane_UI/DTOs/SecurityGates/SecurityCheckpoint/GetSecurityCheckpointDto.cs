namespace Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint
{
    /// <summary>
    /// Represents a Security Checkpoint within the airport system.
    /// </summary>
    public class GetSecurityCheckpointDto
    {
        /// <summary>
        /// Unique identifier of the security checkpoint.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the security checkpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the terminal this checkpoint belongs to.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Current operational status (e.g., Active, Inactive).
        /// </summary>
        public string Status { get; set; }
    }
}