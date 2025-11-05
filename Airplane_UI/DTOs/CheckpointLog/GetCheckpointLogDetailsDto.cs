namespace Airplane_UI.DTOs.CheckpointLog
{
    /// <summary>
    /// DTO for retrieving detailed information of a CheckpointLog including related checkpoint information.
    /// </summary>
    public class GetCheckpointLogDetailsDto
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
        /// Name of the checkpoint.
        /// </summary>
        public string CheckpointName { get; set; }

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
