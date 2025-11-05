using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Airplane_UI.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.Entities.LuggageMaintnance;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides implementation for managing airline data,
    /// including creating, retrieving, updating, and deleting airport records.
    /// </summary>
    public class AirlineService : IAirlineService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the AirlineService class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AirlineService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all airlines asynchronously.
        /// </summary>
        public async Task<IList<GetAirlineDTO>> GetAllAsync()
        {
            var airlines = await _context.Airlines
                .Select(a => a.ToDto())
                .ToListAsync();

            return airlines;
        }

        /// <summary>
        /// Retrieves a specific airline by its unique identifier.
        /// </summary>
        public async Task<GetAirlineDTO> GetyByIdAsync(int airlineId)
        {
            var airline = await _context.Airlines
                .Where(a => a.Id == airlineId)
                .Select(a => a.ToDto())
                .SingleOrDefaultAsync();

            return airline;
        }

        /// <summary>
        /// Creates a new airline record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing airline details to create.</param>
        /// <returns>The new created airline as a DTO.</returns>
        public async Task<GetAirlineDTO> CreateAsync(CreateAndUpdateAirlineDTO dto)
        {
            var airline = dto.ToEntity();

            _context.Airlines.Add(airline);
            await _context.SaveChangesAsync();

            return airline.ToDto();
        }
        /// <summary>
        /// Updates an existing airline record by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the airline to update.</param>
        /// <param name="dto">The DTO containing updated airline details.</param>
        /// <returns>
        /// The task result contains the updated GetAirlineDTO object if the update succeeded. otherwise, null if the airline was not found.
        /// </returns>
        public async Task<GetAirlineDTO> UpdateAsync(int airlineId, CreateAndUpdateAirlineDTO dto)
        {
            var existingAirline = await _context.Airlines.FindAsync(airlineId);
            if (existingAirline == null)
            {
                return null;
            }

            var updateAirline = dto.ToEntity();
            if (updateAirline == null)
            {
                return null;
            }

            existingAirline.UpdateEntity(dto);
            await _context.SaveChangesAsync();

            return existingAirline.ToDto();
        }

        /// <summary>
        /// Deletes an airline record by ID asynchronously.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to delete.</param>
        /// <returns>A message indicating the result of the delete operation, or null if not found.</returns>
        public async Task<string> DeleteAsync(int airlineId)
        {
            var airline = await _context.Airlines.FindAsync(airlineId);
            if (airline == null) return null;

            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();

            return $"Airport with ID {airlineId} deleted successfully.";
        }

    }
}
