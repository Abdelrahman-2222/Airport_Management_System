using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Provides functionality for managing customs desks, including
    /// retrieving, creating, updating, deleting, and modifying their operational status.
    /// </summary>
    public class CustomsDeskService : ICustomsDeskService

    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomsDeskService"/>.
        /// </summary>
        /// <param name="context">The database context used for accessing Customs Desk data.</param>
        public CustomsDeskService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Customs Desks across all terminals.
        /// </summary>
        /// <returns>A list of all Customs Desk DTOs.</returns>
        public async Task<List<GetCustomsDeskDto>> GetAllAsync()
        {
            return await _context.CustomsDesks
                .AsNoTracking()
                .Select(d => new GetCustomsDeskDto
                {
                    Id = d.Id,
                    TerminalID = d.TerminalID,
                    DeskNumber = d.DeskNumber,
                    Status = d.Status
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific Customs Desk by ID.
        /// </summary>
        /// <param name="id">The unique ID of the Customs Desk.</param>
        /// <returns>The matching Customs Desk DTO if found; otherwise, null.</returns>
        public async Task<GetCustomsDeskDto?> GetByIdAsync(int id)
        {
            return await _context.CustomsDesks
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new GetCustomsDeskDto
                {
                    Id = d.Id,
                    TerminalID = d.TerminalID,
                    DeskNumber = d.DeskNumber,
                    Status = d.Status
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves detailed information about a Customs Desk including assigned staff shifts.
        /// </summary>
        /// <param name="id">The ID of the Customs Desk.</param>
        /// <returns>The detailed Customs Desk DTO if found; otherwise, null.</returns>
        public async Task<GetCustomsDeskDetailsDto?> GetDetailsAsync(int id)
        {
            //return await _context.CustomsDesks
            //    .AsNoTracking()
            //    .Where(d => d.Id == id)
            //    .Select(d => new GetCustomsDeskDetailsDto
            //    {
            //        Id = d.Id,
            //        TerminalID = d.TerminalID,
            //        DeskNumber = d.DeskNumber,
            //        Status = d.Status,
            //        AssignedShifts = d.AssignedShifts
            //            .Select(s => new StaffShiftDto
            //            {
            //                Id = s.Id,
            //                StaffName = s.Staff.Name,
            //                Role = s.Staff.Role,
            //                StartTime = s.StartTime,
            //                EndTime = s.EndTime
            //            }).ToList()
            //    })
            //    .FirstOrDefaultAsync();
            return null;
        }

        /// <summary>
        /// Retrieves all Customs Desks belonging to a specific terminal.
        /// </summary>
        /// <param name="terminalId">The ID of the terminal.</param>
        /// <returns>A list of Customs Desks within the specified terminal.</returns>
        public async Task<List<GetCustomsDeskDto>> GetByTerminalAsync(int terminalId)
        {
            return await _context.CustomsDesks
                .AsNoTracking()
                .Where(d => d.TerminalID == terminalId)
                .Select(d => new GetCustomsDeskDto
                {
                    Id = d.Id,
                    TerminalID = d.TerminalID,
                    DeskNumber = d.DeskNumber,
                    Status = d.Status
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves all Customs Desks with a specific operational status.
        /// </summary>
        /// <param name="status">The operational status (e.g., "Active", "Inactive").</param>
        /// <returns>A list of desks matching the given status.</returns>
        public async Task<List<GetCustomsDeskDto>> GetByStatusAsync(string status)
        {
            return await _context.CustomsDesks
                .AsNoTracking()
                .Where(d => d.Status == status)
                .Select(d => new GetCustomsDeskDto
                {
                    Id = d.Id,
                    TerminalID = d.TerminalID,
                    DeskNumber = d.DeskNumber,
                    Status = d.Status
                })
                .ToListAsync();
        }

        /// <summary>
        /// Creates a new Customs Desk entry.
        /// </summary>
        /// <param name="createDto">The DTO containing desk creation data.</param>
        /// <returns>The created Customs Desk DTO if successful; otherwise, null.</returns>
        public async Task<GetCustomsDeskDto?> CreateAsync(CreateCustomsDeskDto createDto)
        {
            var terminalExists = await _context.Terminals
                .AsNoTracking()
                .AnyAsync(t => t.Id == createDto.TerminalID);

            if (!terminalExists)
                return null;

            var exists = await _context.CustomsDesks
                .AsNoTracking()
                .AnyAsync(d => d.DeskNumber == createDto.DeskNumber && d.TerminalID == createDto.TerminalID);

            if (exists)
                return null;

            var desk = new CustomsDesk
            {
                TerminalID = createDto.TerminalID,
                DeskNumber = createDto.DeskNumber,
                Status = string.IsNullOrWhiteSpace(createDto.Status) ? "Active" : createDto.Status
            };

            _context.CustomsDesks.Add(desk);
            await _context.SaveChangesAsync();

            return new GetCustomsDeskDto
            {
                Id = desk.Id,
                TerminalID = desk.TerminalID,
                DeskNumber = desk.DeskNumber,
                Status = desk.Status
            };
        }

        /// <summary>
        /// Updates an existing Customs Desk.
        /// </summary>
        /// <param name="id">The ID of the Customs Desk to update.</param>
        /// <param name="updateDto">The updated desk information.</param>
        /// <returns>The updated Customs Desk DTO if found; otherwise, null.</returns>
        public async Task<GetCustomsDeskDto?> UpdateAsync(int id, UpdateCustomsDeskDto updateDto)
        {
            var desk = await _context.CustomsDesks.FirstOrDefaultAsync(d => d.Id == id);
            if (desk == null)
                return null;

            desk.DeskNumber = updateDto.DeskNumber;
            desk.Status = updateDto.Status;

            await _context.SaveChangesAsync();

            return new GetCustomsDeskDto
            {
                Id = desk.Id,
                TerminalID = desk.TerminalID,
                DeskNumber = desk.DeskNumber,
                Status = desk.Status
            };
        }

        /// <summary>
        /// Deletes a Customs Desk by its ID.
        /// </summary>
        /// <param name="id">The ID of the Customs Desk to delete.</param>
        public async Task DeleteAsync(int id)
        {
            var desk = await _context.CustomsDesks.FirstOrDefaultAsync(d => d.Id == id);
            if (desk == null)
                return;

            _context.CustomsDesks.Remove(desk);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the operational status of a Customs Desk.
        /// </summary>
        /// <param name="id">The ID of the desk to update.</param>
        /// <param name="status">The new operational status.</param>
        public async Task UpdateStatusAsync(int id, string status)
        {
            var desk = await _context.CustomsDesks.FirstOrDefaultAsync(d => d.Id == id);
            if (desk == null)
                return;

            desk.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
