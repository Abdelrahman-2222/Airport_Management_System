namespace Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint
{
    /// <summary>
    /// Detailed DTO that provides additional data about a Security Checkpoint.
    /// </summary>
    public class GetSecurityCheckpointDetailsDto
    {
        /// <summary>
        /// Unique identifier of the checkpoint.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the checkpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Terminal identifier to which the checkpoint belongs.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// Current status of the checkpoint.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Total number of logs associated with this checkpoint.
        /// </summary>
        public int LogCount { get; set; }

        /// <summary>
        /// Number of active staff shifts assigned to this checkpoint.
        /// </summary>
        public int ActiveShifts { get; set; }

        /// <summary>
        /// Average wait time for passengers at this checkpoint.
        /// </summary>
        public TimeSpan? AverageWaitTime { get; set; }
    }
}
