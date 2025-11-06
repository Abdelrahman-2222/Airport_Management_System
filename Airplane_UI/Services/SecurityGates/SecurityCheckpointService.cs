using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mappers.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Provides implementation for managing security checkpoints and related data.
    /// </summary>
    public class SecurityCheckpointService : ISecurityCheckpointService
    {
        private readonly AirplaneManagementSystemContext _context;


        /// <summary>
        /// Initializes a new instance of <see cref="SecurityCheckpointService"/>.
        /// </summary>
        /// <param name="context">The database context used for accessing SecurityCheckpoint data.</param>
        public SecurityCheckpointService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<GetSecurityCheckpointDto>> GetAllAsync()
        {
            var checkpoints = await _context.SecurityCheckpoints.AsNoTracking().ToListAsync();
            return checkpoints.Select(SecurityCheckpointMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityCheckpointDto?> GetByIdAsync(int id)
        {
            var checkpoint = await _context.SecurityCheckpoints.AsNoTracking().FirstOrDefaultAsync(sc => sc.Id == id);
            return checkpoint?.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityCheckpointDetailsDto?> GetDetailsAsync(int id)
        {
            var checkpoint = await _context.SecurityCheckpoints
                .Include(sc => sc.CheckpointLogs)
                .Include(sc => sc.AssignedShifts)
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.Id == id);

            return checkpoint?.ToDetailsDto();
        }

        /// <inheritdoc/>
        public async Task<List<GetSecurityCheckpointDto>> GetByTerminalAsync(int terminalId)
        {
            var checkpoints = await _context.SecurityCheckpoints
                .AsNoTracking()
                .Where(sc => sc.TerminalID == terminalId)
                .ToListAsync();

            return checkpoints.Select(SecurityCheckpointMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<GetSecurityCheckpointDto>> GetByStatusAsync(string status)
        {
            var checkpoints = await _context.SecurityCheckpoints
                .AsNoTracking()
                .Where(sc => sc.Status == status)
                .ToListAsync();

            return checkpoints.Select(SecurityCheckpointMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityCheckpointDto?> CreateAsync(CreateSecurityCheckpointDto dto)
        {
            var terminalExists = await _context.Terminals.AsNoTracking().AnyAsync(t => t.Id == dto.TerminalID);
            if (!terminalExists)
                return null;

            var exists = await _context.SecurityCheckpoints
                .AsNoTracking()
                .AnyAsync(sc => sc.Name == dto.Name && sc.TerminalID == dto.TerminalID);

            if (exists)
                return null;

            var checkpoint = SecurityCheckpointMapper.ToEntity(dto);
            _context.SecurityCheckpoints.Add(checkpoint);
            await _context.SaveChangesAsync();

            return checkpoint.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetSecurityCheckpointDto?> UpdateAsync(int id, UpdateSecurityCheckpointDto dto)
        {
            var checkpoint = await _context.SecurityCheckpoints.FirstOrDefaultAsync(sc => sc.Id == id);
            if (checkpoint == null)
                return null;

            SecurityCheckpointMapper.UpdateEntity(checkpoint, dto);
            await _context.SaveChangesAsync();

            return checkpoint.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int id)
        {
            var checkpoint = await _context.SecurityCheckpoints.FirstOrDefaultAsync(sc => sc.Id == id);
            if (checkpoint == null)
                return $"SecurityCheckpoint {id} not found.";

            _context.SecurityCheckpoints.Remove(checkpoint);
            await _context.SaveChangesAsync();
            return $"Checkpoint {id} deleted successfully.";
        }

        /// <inheritdoc/>
        public async Task UpdateStatusAsync(int id, string status)
        {
            var checkpoint = await _context.SecurityCheckpoints.FirstOrDefaultAsync(sc => sc.Id == id);
            if (checkpoint == null)
                return;

            checkpoint.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
