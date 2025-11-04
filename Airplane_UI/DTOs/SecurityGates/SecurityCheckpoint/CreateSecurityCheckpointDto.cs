namespace Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint
{

    /// <summary>
    /// Data Transfer Object used to create a new Security Checkpoint.
    /// </summary>
    public class CreateSecurityCheckpointDto
    {
        /// <summary>
        /// Name of the new security checkpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the terminal this checkpoint belongs to.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Initial operational status of the checkpoint.
        /// </summary>
        public string Status { get; set; }
    }
}
