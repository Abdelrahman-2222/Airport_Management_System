using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mappers.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{

    ///
    /// Provides implementation for Staff Shift service operations such as retrieving,
    /// creating, updating, and deleting staff shifts.
    ///
    public class StaffShiftService : IStaffShiftService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffShiftService"/> class.
        /// </summary>
        /// <param name="context">The database context for the airplane management system.</param>
        public StaffShiftService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<GetStaffShiftDto>> GetAllAsync()
        {
            var shifts = await _context.StaffShifts
                .ToListAsync();
            return shifts
                .Select(s => s.ToGetDto())
                .ToList();
        }

        /// <inheritdoc/>
        public async Task<GetStaffShiftDto> GetByIdAsync(int id)
        {
            var shift = await _context.StaffShifts.FindAsync(id);
            return shift?.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetStaffShiftDto> CreateAsync(CreateStaffShiftDto createDto)
        {
            var shift = createDto.ToEntity();
            await _context.StaffShifts.AddAsync(shift);
            await _context.SaveChangesAsync();
            return shift.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<GetStaffShiftDto> UpdateAsync(int id, UpdateStaffShiftDto updateDto)
        {
            var shift = await _context.StaffShifts.FindAsync(id);
            if (shift == null)
                return null;
            updateDto.UpdateEntity(shift);
            await _context.SaveChangesAsync();
            return shift.ToGetDto();
        }

        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int id)
        {
            var shift = await _context.StaffShifts.FindAsync(id);
            if (shift == null) return $"Shift with ID {id} not found";

            _context.StaffShifts.Remove(shift);
            await _context.SaveChangesAsync();
            return $"Shift with ID {id} deleted successfully";
        }
    }
}
