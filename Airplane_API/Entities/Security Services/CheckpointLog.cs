using Airplane_API.Entities.Base;
namespace Airplane_API.Entities.Security_Services;

    /// <summary>
    /// Represents a log entry for a security checkpoint in the airport system.
    /// </summary>
    public class CheckpointLog : BaseEntity
    {
        /// <summary>
        /// The identifier of the related security checkpoint.
        /// </summary>
        public int CheckpointID { get; set; }

        /// <summary>
        /// The exact date and time when the checkpoint log was recorded.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The amount of time passengers reported waiting at the checkpoint.
        /// </summary>
        public TimeSpan ReportedWaitTime { get; set; }

        /// <summary>
        /// The security checkpoint associated with this log entry.
        /// </summary>
        public SecurityCheckpoint SecurityCheckpoint { get; set; }
    }
