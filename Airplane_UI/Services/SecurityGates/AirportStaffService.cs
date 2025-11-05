using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.SecurityGates
{
    /// <summary>
    /// Provides functionality for managing Airport Staff, including
    /// retrieving, creating, updating, and deleting staff records.
    /// </summary>
    public class AirportStaffService
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

        /// <summary>
        /// Retrieves all airport staff members from the system.
        /// </summary>
        /// <returns>A list of all existing airport staff members.</returns>
        public async Task<List<GetAirportStaffDto>> GetAllAsync()
        {
            return await _context.AirportStaffs
                .AsNoTracking()
                .Select(s => new GetAirportStaffDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Role = s.Role
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific airport staff member by their unique identifier.
        /// </summary>
        /// <param name="id">The unique ID of the staff member.</param>
        /// <returns>The matching staff member if found; otherwise, null.</returns>
        public async Task<GetAirportStaffDto?> GetByIdAsync(int id)
        {
            return await _context.AirportStaffs
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new GetAirportStaffDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Role = s.Role
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new airport staff member record.
        /// </summary>
        /// <param name="dto">The data required to create the new staff member.</param>
        /// <returns>The created staff member DTO if successful; otherwise, null.</returns>
        public async Task<GetAirportStaffDto?> CreateAsync(CreateAirportStaffDto dto)
        {
            var staff = new AirportStaff
            {
                Name = dto.Name,
                Role = dto.Role
            };

            _context.AirportStaffs.Add(staff);
            await _context.SaveChangesAsync();

            return new GetAirportStaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role
            };
        }

        /// <summary>
        /// Updates the information of an existing airport staff member.
        /// </summary>
        /// <param name="id">The ID of the staff member to update.</param>
        /// <param name="dto">The updated data for the staff member.</param>
        /// <returns>The updated staff member DTO if found; otherwise, null.</returns>
        public async Task<GetAirportStaffDto?> UpdateAsync(int id, UpdateAirportStaffDto dto)
        {
            var staff = await _context.AirportStaffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null)
                return null;

            staff.Name = dto.Name;
            staff.Role = dto.Role;

            await _context.SaveChangesAsync();

            return new GetAirportStaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role
            };
        }

        /// <summary>
        /// Deletes an airport staff member by their unique ID.
        /// </summary>
        /// <param name="id">The ID of the staff member to delete.</param>
        public async Task DeleteAsync(int id)
        {
            var staff = await _context.AirportStaffs.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null)
                return;

            _context.AirportStaffs.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }
}
