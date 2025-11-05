namespace Airplane_UI.DTOs.CheckpointLog
{
    /// <summary>
    /// Data Transfer Object for retrieving basic information of a CheckpointLog.
    /// </summary>
    public class GetCheckpointLogDto
    {
        /// <summary>
        /// Unique identifier of the checkpoint log.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the related checkpoint.
        /// </summary>
        public int CheckpointID { get; set; }

        /// <summary>
        /// The timestamp when the log was recorded.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The reported wait time at the checkpoint.
        /// </summary>
        public TimeSpan ReportedWaitTime { get; set; }
    }
}
