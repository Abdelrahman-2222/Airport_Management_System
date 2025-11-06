using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.CheckpointLog;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mapper.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Service responsible for managing CheckpointLog operations such as retrieval, creation, update, and deletion.
    /// </summary>
    public class CheckpointLogService : ICheckpointLogService
    {
        private readonly AirplaneManagementSystemContext _context;


        /// <summary>
        /// Initializes a new instance of <see cref="CheckpointLogService"/>.
        /// </summary>
        /// <param name="context">The database context used for accessing CheckpointLog data.</param>
        public CheckpointLogService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<List<GetCheckpointLogDto>> GetAllAsync()
        {
            var logs = await _context.CheckpointLogs.ToListAsync();
            return logs.Select(l => l.ToDto()).ToList();
        }

        /// <inheritdoc />
        public async Task<GetCheckpointLogDto> GetByIdAsync(int CheckpointId)
        {
            var log = await _context.CheckpointLogs
                .Include(l => l.SecurityCheckpoint)
                .FirstOrDefaultAsync(l => l.Id == CheckpointId);

            return log?.ToDto();
        }

        /// <inheritdoc />
        public async Task<GetCheckpointLogDto> CreateAsync(CreateCheckpointLogDto dto)
        {
            var entity = dto.ToEntity();
            _context.CheckpointLogs.Add(entity);
            await _context.SaveChangesAsync();

            return entity.ToDto();
        }

        /// <inheritdoc />
        public async Task<GetCheckpointLogDto> UpdateAsync(int CheckpointId, UpdateCheckpointLogDto dto)
        {
            var entity = await _context.CheckpointLogs.FindAsync(CheckpointId);
            if (entity == null)
                return null;

            dto.UpdateEntity(entity);
            _context.CheckpointLogs.Update(entity);
            await _context.SaveChangesAsync();

            return entity.ToDto();
        }

        /// <inheritdoc />
        public async Task<string> DeleteAsync(int CheckpointId)
        {
            var entity = await _context.CheckpointLogs.FindAsync(CheckpointId);
            if (entity == null)
                return "Checkpoint log not found.";

            _context.CheckpointLogs.Remove(entity);
            await _context.SaveChangesAsync();

            return "Checkpoint log deleted successfully.";
        }
    }
}
