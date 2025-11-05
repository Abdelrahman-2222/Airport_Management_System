using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.CheckpointLog;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Service responsible for managing CheckpointLogs, including
    /// CRUD operations and retrieval of checkpoint log data.
    /// </summary>
    public class CheckpointLogService : ICheckpointLogService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointLogService"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing checkpoint logs.</param>
        public CheckpointLogService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all checkpoint logs from the system.
        /// </summary>
        /// <returns>A list of <see cref="GetCheckpointLogDto"/> representing all checkpoint logs.</returns>
        public async Task<List<GetCheckpointLogDto>> GetAllAsync()
        {
            return await _context.CheckpointLogs
                .Select(cl => new GetCheckpointLogDto
                {
                    Id = cl.Id,
                    CheckpointID = cl.CheckpointID,
                    Timestamp = cl.Timestamp,
                    ReportedWaitTime = cl.ReportedWaitTime
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a single checkpoint log by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log.</param>
        /// <returns>
        /// A <see cref="GetCheckpointLogDto"/> representing the checkpoint log, 
        /// </returns>
        public async Task<GetCheckpointLogDto> GetByIdAsync(int CheckpointId)
        {
            var log = await _context.CheckpointLogs.FindAsync(CheckpointId);
            if (log == null) return null;

            return new GetCheckpointLogDto
            {
                Id = log.Id,
                CheckpointID = log.CheckpointID,
                Timestamp = log.Timestamp,
                ReportedWaitTime = log.ReportedWaitTime
            };
        }

        /// <summary>
        /// Creates a new checkpoint log in the system.
        /// </summary>
        /// <param name="dto">The data required to create a new checkpoint log.</param>
        /// <returns>A <see cref="GetCheckpointLogDto"/> representing the newly created log.</returns>
        public async Task<GetCheckpointLogDto> CreateAsync(CreateCheckpointLogDto dto)
        {
            var log = new CheckpointLog
            {
                CheckpointID = dto.CheckpointID,
                Timestamp = DateTime.UtcNow,
                ReportedWaitTime = dto.ReportedWaitTime
            };

            await _context.CheckpointLogs.AddAsync(log);
            await _context.SaveChangesAsync();

            return new GetCheckpointLogDto
            {
                Id = log.Id,
                CheckpointID = log.CheckpointID,
                Timestamp = log.Timestamp,
                ReportedWaitTime = log.ReportedWaitTime
            };
        }

        /// <summary>
        /// Updates an existing checkpoint log's reported wait time.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log to update.</param>
        /// <param name="dto">The data containing the updated wait time.</param>
        /// <returns>
        /// A <see cref="GetCheckpointLogDto"/> representing the updated log, 
        /// </returns>
        public async Task<GetCheckpointLogDto> UpdateAsync(int CheckpointId, UpdateCheckpointLogDto dto)
        {
            var log = await _context.CheckpointLogs.FindAsync(CheckpointId);
            if (log == null) return null;

            log.ReportedWaitTime = dto.ReportedWaitTime;
            await _context.SaveChangesAsync();

            return new GetCheckpointLogDto
            {
                Id = log.Id,
                CheckpointID = log.CheckpointID,
                Timestamp = log.Timestamp,
                ReportedWaitTime = log.ReportedWaitTime
            };
        }

        /// <summary>
        /// Deletes a checkpoint log by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log to delete.</param>
        /// <returns>
        /// A string message indicating the result of the deletion operation.
        /// </returns>
        public async Task<string> DeleteAsync(int CheckpointId)
        {
            var log = await _context.CheckpointLogs.FindAsync(CheckpointId);
            if (log == null) return $"CheckpointLog {CheckpointId} not found";

            _context.CheckpointLogs.Remove(log);
            await _context.SaveChangesAsync();
            return $"CheckpointLog {CheckpointId} deleted successfully";
        }

    }
}
