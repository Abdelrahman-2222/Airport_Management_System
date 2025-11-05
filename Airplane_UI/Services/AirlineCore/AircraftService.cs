using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides implementation for managing aircraft data,
    /// including creating, retrieving, updating, and deleting airport records.
    /// </summary>
    public class AircraftService : IAircraftService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the AircraftService class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AircraftService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all aircrafts asynchronously.
        /// </summary>
        public async Task<IList<GetAircraftDTO>> GetAllAsync()
        {
            var aircrafts = await _context.Aircrafts
                .Select(a => a.ToDto())
                .ToListAsync();

            return aircrafts;
        }
        /// <summary>
        /// Retrieves a specific aircraft by its unique identifier.
        /// </summary>
        public async Task<GetAircraftDTO> GetyByIdAsync(int aircraftId)
        {
            var aircraft = await _context.Aircrafts
                .Where(a => a.Id == aircraftId)
                .Select(a => a.ToDto())
                .SingleOrDefaultAsync();

            return aircraft;
        }
        /// <summary>
        /// Creates a new aircraft record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing aircraft details to create.</param>
        /// <returns>The new created aircraft as a DTO.</returns>
        public async Task<GetAircraftDTO> CreateAsync(CreateAndUpdateAircraftDTO dto)
        {
            var aircraftEntity = dto.ToEntity();

            _context.Aircrafts.Add(aircraftEntity);
            await _context.SaveChangesAsync();

            return aircraftEntity.ToDto();
        }
        /// <summary>
        /// Updates an existing aircraft record by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the aircraft to update.</param>
        /// <param name="dto">The DTO containing updated aircraft details.</param>
        /// <returns> The task result contains the updated GetAircraftDTO object if the update succeeded. otherwise, null if the aircraft was not found.</returns>
        public async Task<GetAircraftDTO> UpdateAsync(int aircraftId, CreateAndUpdateAircraftDTO dto)
        {
            var updatedAircraft = await _context.Aircrafts.FindAsync(aircraftId);
            if (updatedAircraft == null) return null;

            dto.ToEntity();

            await _context.SaveChangesAsync();
            return updatedAircraft.ToDto();
        }
        // <summary>
        /// Deletes an aircraft record by ID asynchronously.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to delete.</param>
        /// <returns>A message indicating the result of the delete operation, or null if not found.</returns>
        public async Task<string> DeleteAsync(int aircraftId)
        {
            var aircraft = await _context.Aircrafts.FindAsync(aircraftId);
            if (aircraft == null) return null;

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();

            return $"Aircraft with ID {aircraftId} deleted successfully.";
        }
    }
}
