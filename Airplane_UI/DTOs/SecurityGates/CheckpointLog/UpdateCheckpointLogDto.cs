namespace Airplane_UI.DTOs.SecurityGates.CheckpointLog
{
    /// <summary>
    /// DTO for updating an existing CheckpointLog.
    /// </summary>
    public class UpdateCheckpointLogDto
    {
        /// <summary>
        /// The updated reported wait time at the checkpoint.
        /// </summary>
        public TimeSpan ReportedWaitTime { get; set; }
    }
}
