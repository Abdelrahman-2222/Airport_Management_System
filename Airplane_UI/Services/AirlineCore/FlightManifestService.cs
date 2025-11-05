using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;
using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides functionality for managing FlightManifest records, 
    /// including creation, retrieval, updating, and deletion operations.
    /// </summary>
    public class FlightManifestService : IFlightManifestService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the FlightManifestService class.
        /// </summary>
        /// <param name="context">The database context used to access flight manifest data.</param>
        public FlightManifestService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IList<GetFlightManifestDTO>> GetAllAsync()
        {
            var flightManifests = await _context.FlightManifests
                .Select(a => a.ToDTO())
                .ToListAsync();

            return flightManifests;
        }

        /// <inheritdoc />
        public async Task<GetFlightManifestDTO> GetByIdAsync(int flightManifestId)
        {
            var flightManifest = await _context.FlightManifests
                .Where(a => a.Id == flightManifestId)
                .Select(a => a.ToDTO())
                .SingleOrDefaultAsync();

            return flightManifest;
        }

        /// <inheritdoc />
        public async Task<GetFlightManifestDTO> CreateAsync(CreateAndUpdateFlightManifestDTO dto)
        {
            var flightManifest = dto.ToEntity();

            _context.FlightManifests.Add(flightManifest);
            await _context.SaveChangesAsync();

            return flightManifest.ToDTO();
        }

        /// <inheritdoc />
        public async Task<GetFlightManifestDTO> UpdateAsync(int flightManifestId, CreateAndUpdateFlightManifestDTO dto)
        {
            var flightManifests = await _context.FlightManifests.FindAsync(flightManifestId);
            if (flightManifests == null) return null;

            var updatedFlightManifests = dto.ToEntity();

            _context.FlightManifests.Update(flightManifests);
            await _context.SaveChangesAsync();

            return flightManifests.ToDTO();
        }

        /// <inheritdoc />
        public async Task<string> DeleteAsync(int flightManifestId)
        {
            var flightManifest = await _context.FlightManifests.FindAsync(flightManifestId);
            if (flightManifest == null) return null;

            _context.FlightManifests.Remove(flightManifest);
            await _context.SaveChangesAsync();

            return $"Flight with ID {flightManifest} deleted successfully.";
        }
    }
}
