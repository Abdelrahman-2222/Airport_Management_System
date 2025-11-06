using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;
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

        /// <summary>
        /// Retrieves all flight manifests asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of GetFlightManifestDTO objects.
        /// </returns>
        public async Task<IList<GetFlightManifestDTO>> GetAllAsync()
        {
            var flightManifests = await _context.FlightManifests
                .Select(a => a.ToDTO())
                .ToListAsync();

            return flightManifests;
        }

        /// <summary>
        /// Retrieves a specific flight manifest by its unique identifier asynchronously.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the flight manifest DTO if found; otherwise, null.
        /// </returns>
        public async Task<GetFlightManifestDTO> GetByIdAsync(int flightManifestId)
        {
            var flightManifest = await _context.FlightManifests
                .Where(a => a.Id == flightManifestId)
                .Select(a => a.ToDTO())
                .SingleOrDefaultAsync();

            return flightManifest;
        }

        /// <summary>
        /// Creates a new flight manifest record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing flight manifest details to create.</param>
        /// <returns>
        /// The new created flight manifest as a DTO.
        /// </returns>
        public async Task<GetFlightManifestDTO> CreateAsync(CreateAndUpdateFlightManifestDTO dto)
        {
            var flightManifestEntity = dto.ToEntity();

            _context.FlightManifests.Add(flightManifestEntity);
            await _context.SaveChangesAsync();

            return flightManifestEntity.ToDTO();
        }

        /// <summary>
        /// Updates an existing flight manifest record by ID.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to update.</param>
        /// <param name="dto">The DTO containing updated flight manifest details.</param>
        /// <returns>
        /// The task result contains the updated GetFlightManifestDTO object if the update succeeded; otherwise, null if the flight manifest was not found.
        /// </returns>
        public async Task<GetFlightManifestDTO> UpdateAsync(int flightManifestId, CreateAndUpdateFlightManifestDTO dto)
        {
            var existingFlightManifest = await _context.FlightManifests.FindAsync(flightManifestId);
            if (existingFlightManifest == null)
            {
                return null;
            }

            var updateFlightManifest = dto.ToEntity();
            if (updateFlightManifest == null)
            {
                return null;
            }

            dto.UpdateEntity(existingFlightManifest);
            await _context.SaveChangesAsync();

            return existingFlightManifest.ToDTO();
        }

        /// <summary>
        /// Deletes a flight manifest record by ID asynchronously.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flight manifest to delete.</param>
        /// <returns>
        /// A message indicating the result of the delete operation, or null if the flight manifest was not found.
        /// </returns>
        public async Task<string> DeleteAsync(int flightManifestId)
        {
            var flightManifest = await _context.FlightManifests.FindAsync(flightManifestId);
            if (flightManifest == null)
            {
                return null;
            }

            _context.FlightManifests.Remove(flightManifest);
            await _context.SaveChangesAsync();

            return $"Flight with ID {flightManifestId} deleted successfully.";
        }
    }
}