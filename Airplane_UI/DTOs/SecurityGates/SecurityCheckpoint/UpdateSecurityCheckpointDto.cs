namespace Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint
{
    /// <summary>
    /// Data Transfer Object used to update an existing Security Checkpoint.
    /// </summary>
    public class UpdateSecurityCheckpointDto
    {
        /// <summary>
        /// Updated name of the checkpoint (optional).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Updated operational status (e.g., Active, Maintenance).
        /// </summary>
        public string Status { get; set; }
    }
}
