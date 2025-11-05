namespace Airplane_UI.DTOs.SecurityGates.CheckpointLog
{
    /// <summary>
    /// DTO for creating a new CheckpointLog.
    /// </summary>
    public class CreateCheckpointLogDto
    {
        /// <summary>
        /// Identifier of the checkpoint.
        /// </summary>
        public int CheckpointID { get; set; }

        /// <summary>
        /// The reported wait time at the checkpoint.
        /// </summary>
        public TimeSpan ReportedWaitTime { get; set; }
    }
}
