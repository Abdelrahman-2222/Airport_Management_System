using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mappers.SecurityGates;
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

        /// <inheritdoc/>
        public async Task<List<GetCustomsDeskDto>> GetAllAsync()
        {
            var desks = await _context.CustomsDesks.AsNoTracking().ToListAsync();
            return desks.Select(CustomsDeskMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetCustomsDeskDto?> GetByIdAsync(int id)
        {
            var desk = await _context.CustomsDesks.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
            return desk?.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetCustomsDeskDetailsDto?> GetDetailsAsync(int id)
        {
            var desk = await _context.CustomsDesks
                .Include(d => d.AssignedShifts)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            return desk?.ToDetailsDto();
        }

        /// <inheritdoc/>
        public async Task<List<GetCustomsDeskDto>> GetByTerminalAsync(int terminalId)
        {
            var desks = await _context.CustomsDesks
                .AsNoTracking()
                .Where(d => d.TerminalID == terminalId)
                .ToListAsync();

            return desks.Select(CustomsDeskMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<GetCustomsDeskDto>> GetByStatusAsync(string status)
        {
            var desks = await _context.CustomsDesks
                .AsNoTracking()
                .Where(d => d.Status == status)
                .ToListAsync();

            return desks.Select(CustomsDeskMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetCustomsDeskDto?> CreateAsync(CreateCustomsDeskDto dto)
        {
            var terminalExists = await _context.Terminals.AsNoTracking()
                .AnyAsync(t => t.Id == dto.TerminalID);

            if (!terminalExists)
                return null;

            var exists = await _context.CustomsDesks
                .AsNoTracking()
                .AnyAsync(d => d.DeskNumber == dto.DeskNumber && d.TerminalID == dto.TerminalID);

            if (exists)
                return null;

            var desk = dto.ToEntity();

            _context.CustomsDesks.Add(desk);
            await _context.SaveChangesAsync();

            return desk.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetCustomsDeskDto?> UpdateAsync(int id, UpdateCustomsDeskDto dto)
        {
            var desk = await _context.CustomsDesks.FirstOrDefaultAsync(d => d.Id == id);
            if (desk == null)
                return null;

            desk.UpdateEntity(dto);
            await _context.SaveChangesAsync();

            return desk.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int id)
        {
            var desk = await _context.CustomsDesks.FirstOrDefaultAsync(d => d.Id == id);
            if (desk == null)
                return "Customs desk not found.";

            _context.CustomsDesks.Remove(desk);
            await _context.SaveChangesAsync();
            return "Customs desk deleted successfully.";
        }

        /// <inheritdoc/>
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
