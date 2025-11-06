using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.Entities.SecurityGates;
using Airplane_UI.Mappers.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Provides functionality for managing Airport Staff, including
    /// retrieving, creating, updating, and deleting staff records.
    /// </summary>
    public class AirportStaffService : IAirportStaffService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="AirportStaffService"/>.
        /// </summary>
        /// <param name="context">The database context used for accessing Airport Staff data.</param>
        public AirportStaffService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<GetAirportStaffDto>> GetAllAsync()
        {
            var staffList = await _context.AirportStaffs.AsNoTracking().ToListAsync();
            return staffList.Select(AirportStaffMapper.ToGetDto).ToList();
        }

        /// <inheritdoc/>
        public async Task<GetAirportStaffDto?> GetByIdAsync(int id)
        {
            var staff = await _context.AirportStaffs.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return staff == null ? null : AirportStaffMapper.ToGetDto(staff);
        }

        /// <inheritdoc/>
        public async Task<GetAirportStaffDto?> CreateAsync(CreateAirportStaffDto dto)
        {
            var staff = AirportStaffMapper.ToEntity(dto);
            _context.AirportStaffs.Add(staff);
            await _context.SaveChangesAsync();
            return AirportStaffMapper.ToGetDto(staff);
        }

        /// <inheritdoc/>
        public async Task<GetAirportStaffDto?> UpdateAsync(int id, UpdateAirportStaffDto dto)
        {
            var staff = await _context.AirportStaffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null)
                return null;

            AirportStaffMapper.UpdateEntity(staff, dto);
            await _context.SaveChangesAsync();
            return AirportStaffMapper.ToGetDto(staff);
        }

        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int id)
        {
            var staff = await _context.AirportStaffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null)
                return "Staff not found.";

            _context.AirportStaffs.Remove(staff);
            await _context.SaveChangesAsync();

            return "Staff deleted successfully.";
        }
    }
}
