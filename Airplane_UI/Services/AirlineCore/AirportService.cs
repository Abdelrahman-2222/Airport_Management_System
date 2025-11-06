using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides implementation for managing airport data,
    /// including creating, retrieving, updating, and deleting airport records.
    /// </summary>
    public class AirportService : IAirportService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the AirportService class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AirportService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all airports asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the airport DTO if found; otherwise, null.
        /// </returns>
        public async Task<IList<GetAirportDTO>> GetAllAsync()
        {
            var airports = await _context.Airports
                .Select(a => a.ToDto())
                .ToListAsync();

            return airports;
        }

        /// <summary>
        /// Retrieves a specific airport by its unique identifier asynchronously.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the airport DTO if found; otherwise, null.
        /// </returns>
        public async Task<GetAirportDTO> GetyByIdAsync(int airportId)
        {
            var airport = await _context.Airports
                .Where(a => a.Id == airportId)
                .Select(a => a.ToDto())
                .SingleOrDefaultAsync();

            return airport;
        }

        /// <summary>
        /// Creates a new airport record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing airport details to create.</param>
        /// <returns>
        /// The new created airport as a DTO.
        /// </returns>
        public async Task<GetAirportDTO> CreateAsync(CreateAndUpdateAirportDTO dto)
        {
            var airport = dto.ToEntity();

            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return airport.ToDto();
        }

        /// <summary>
        /// Updates an existing airport record by ID.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to update.</param>
        /// <param name="dto">The DTO containing updated airport details.</param>
        /// <returns>
        /// The task result contains the updated GetAirportDTO object if the update succeeded. otherwise, null if the airport was not found.
        /// </returns>
        public async Task<GetAirportDTO> UpdateAsync(int airportId, CreateAndUpdateAirportDTO dto)
        {
            var existingAirport = await _context.Airports.FindAsync(airportId);
            if (existingAirport == null)
            {
                return null;
            }

            var updateAirport = dto.ToEntity();
            if (updateAirport == null)
            {
                return null;
            }

            dto.UpdateEntity(existingAirport);
            await _context.SaveChangesAsync();

            return updateAirport.ToDto();
        }

        /// <summary>
        /// Deletes an airport record by ID asynchronously.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to delete.</param>
        /// <returns>
        /// A message indicating the result of the delete operation, or <c>null</c> if not found.
        /// </returns>
        public async Task<string> DeleteAsync(int airportId)
        {
            var airport = await _context.Airports.FindAsync(airportId);
            if (airport == null)
            {
                return null;
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return $"Airport with ID {airportId} deleted successfully.";
        }
    }
}