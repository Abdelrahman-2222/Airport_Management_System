using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using System;

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
            /// <param name="context">The database context instance used for data access.</param>
            public SecurityCheckpointService(AirplaneManagementSystemContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Retrieves all security checkpoints.
            /// </summary>
            /// <returns>A list of all security checkpoints.</returns>
            public async Task<List<GetSecurityCheckpointDto>> GetAllAsync()
            {
                return await _context.SecurityCheckpoints
                    .AsNoTracking()
                    .Select(sc => new GetSecurityCheckpointDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        TerminalID = sc.TerminalID,
                        Status = sc.Status
                    })
                    .ToListAsync();
            }

            /// <summary>
            /// Retrieves a security checkpoint by ID.
            /// </summary>
            /// <param name="id">The unique identifier of the security checkpoint.</param>
            /// <returns>The matching checkpoint if found; otherwise, null.</returns>
            public async Task<GetSecurityCheckpointDto?> GetByIdAsync(int id)
            {
                return await _context.SecurityCheckpoints
                    .AsNoTracking()
                    .Where(sc => sc.Id == id)
                    .Select(sc => new GetSecurityCheckpointDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        TerminalID = sc.TerminalID,
                        Status = sc.Status
                    })
                    .FirstOrDefaultAsync();
            }

            /// <summary>
            /// Retrieves detailed information about a checkpoint including logs and assignments.
            /// </summary>
            /// <param name="id">The ID of the security checkpoint.</param>
            /// <returns>Detailed checkpoint data, or null if not found.</returns>
            public async Task<GetSecurityCheckpointDetailsDto?> GetDetailsAsync(int id)
            {
                return await _context.SecurityCheckpoints
                    .AsNoTracking()
                    .Where(sc => sc.Id == id)
                    .Select(sc => new GetSecurityCheckpointDetailsDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        TerminalID = sc.TerminalID,
                        Status = sc.Status,
                        LogCount = sc.CheckpointLogs.Count,
                        ActiveShifts = sc.AssignedShifts.Count(ss => ss.EndTime > DateTime.UtcNow),
                        AverageWaitTime = sc.CheckpointLogs.Count > 0
                            ? TimeSpan.FromTicks((long)sc.CheckpointLogs.Average(cl => cl.ReportedWaitTime.Ticks))
                            : (TimeSpan?)null
                    })
                    .FirstOrDefaultAsync();
            }

            /// <summary>
            /// Retrieves all checkpoints in a specific terminal.
            /// </summary>
            /// <param name="terminalId">The terminal ID to filter checkpoints by.</param>
            /// <returns>A collection of checkpoints within the given terminal.</returns>
            public async Task<List<GetSecurityCheckpointDto>> GetByTerminalAsync(int terminalId)
            {
                return await _context.SecurityCheckpoints
                    .AsNoTracking()
                    .Where(sc => sc.TerminalID == terminalId)
                    .Select(sc => new GetSecurityCheckpointDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        TerminalID = sc.TerminalID,
                        Status = sc.Status
                    })
                    .ToListAsync();
            }

            /// <summary>
            /// Retrieves checkpoints with a specific operational status.
            /// </summary>
            /// <param name="status">The status to filter checkpoints by.</param>
            /// <returns>A collection of checkpoints matching the specified status.</returns>
            public async Task<List<GetSecurityCheckpointDto>> GetByStatusAsync(string status)
            {
                return await _context.SecurityCheckpoints
                    .AsNoTracking()
                    .Where(sc => sc.Status == status)
                    .Select(sc => new GetSecurityCheckpointDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        TerminalID = sc.TerminalID,
                        Status = sc.Status
                    })
                    .ToListAsync();
            }

        /// <summary>
        /// Creates a new security checkpoint and saves it to the database.
        /// </summary>
        /// <param name="createDto">The data used to create the new checkpoint.</param>
        /// <returns>
        /// The created <see cref="GetSecurityCheckpointDto"/> if successful; otherwise, <c>null</c> if the terminal does not exist or a duplicate name is found. </returns>
        public async Task<GetSecurityCheckpointDto?> CreateAsync(CreateSecurityCheckpointDto createDto)
        {
            var terminalExists = await _context.Terminals
                .AsNoTracking()
                .AnyAsync(t => t.Id == createDto.TerminalID);

            if (!terminalExists)
                return null;

            var exists = await _context.SecurityCheckpoints
                .AsNoTracking()
                .AnyAsync(sc => sc.Name == createDto.Name && sc.TerminalID == createDto.TerminalID);

            if (exists)
                return null;

            var checkpoint = new SecurityCheckpoint
            {
                Name = createDto.Name,
                TerminalID = createDto.TerminalID,
                Status = string.IsNullOrWhiteSpace(createDto.Status) ? "Active" : createDto.Status
            };

            _context.SecurityCheckpoints.Add(checkpoint);
            await _context.SaveChangesAsync();

            return await _context.SecurityCheckpoints
                .AsNoTracking()
                .Where(sc => sc.Id == checkpoint.Id)
                .Select(sc => new GetSecurityCheckpointDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    TerminalID = sc.TerminalID,
                    Status = sc.Status
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates an existing security checkpoint.
        /// </summary>
        /// <param name="id">The ID of the checkpoint to update.</param>
        /// <param name="updateDto">The updated checkpoint data.</param>
        /// <returns>The updated checkpoint DTO, or null if not found.</returns>
        public async Task<GetSecurityCheckpointDto?> UpdateAsync(int id, UpdateSecurityCheckpointDto updateDto)
            {
                var checkpoint = await _context.SecurityCheckpoints.FirstOrDefaultAsync(sc => sc.Id == id);
                if (checkpoint == null)
                    return null;

                checkpoint.Name = updateDto.Name;
                checkpoint.Status = updateDto.Status;

                await _context.SaveChangesAsync();

                return new GetSecurityCheckpointDto
                {
                    Id = checkpoint.Id,
                    Name = checkpoint.Name,
                    TerminalID = checkpoint.TerminalID,
                    Status = checkpoint.Status
                };
            }

        /// <summary>
        /// Deletes a security checkpoint by ID.
        /// </summary>
        /// <param name="id">The ID of the checkpoint to delete.</param>
        public async Task<string> DeleteAsync(int id)
        {
            var checkpoint = await _context.SecurityCheckpoints.FindAsync(id);
            if (checkpoint == null) return $"SecurityCheckpoint {id} not found";


            _context.SecurityCheckpoints.Remove(checkpoint);
            await _context.SaveChangesAsync();
            return $"Checkpoint {id} deleted successfully";
        }

        /// <summary>
        /// Updates the operational status of a checkpoint.
        /// </summary>
        /// <param name="id">The checkpoint ID.</param>
        /// <param name="status">The new status value.</param>
        public async Task UpdateStatusAsync(int id, string status)
            {
                var checkpoint = await _context.SecurityCheckpoints.FirstOrDefaultAsync(sc => sc.Id == id);
                if (checkpoint == null)
                    return;

                checkpoint.Status = status;
                await _context.SaveChangesAsync();
            }

        Task ISecurityCheckpointService.DeleteAsync(int id)
        {
            return DeleteAsync(id);
        }

        Task<string> ISecurityCheckpointService.UpdateStatusAsync(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
    }
