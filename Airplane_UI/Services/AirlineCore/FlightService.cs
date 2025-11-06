using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.FlightDTOs;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides implementation for managing flight data,
    /// including creating, retrieving, updating, and deleting flight records.
    /// </summary>
    public class FlightService : IFlightService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the FlightService class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public FlightService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all flights asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of GetFlightDTO objects.
        /// </returns>
        public async Task<IList<GetFlightDTO>> GetAllAsync()
        {
            var flights = await _context.Flights
                .Select(a => a.ToDTO())
                .ToListAsync();

            return flights;
        }

        /// <summary>
        /// Retrieves a specific flight by its unique identifier asynchronously.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the flight DTO if found; otherwise, null.
        /// </returns>
        public async Task<GetFlightDTO> GetByIdAsync(int flightId)
        {
            var flight = await _context.Flights
                .Where(a => a.Id == flightId)
                .Select(a => a.ToDTO())
                .SingleOrDefaultAsync();
            
            return flight;
        }

        /// <summary>
        /// Creates a new flight record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing flight details to create.</param>
        /// <returns>
        /// The new created flight as a DTO.
        /// </returns>
        public async Task<GetFlightDTO> CreateAsync(CreateAndUpdateFlightDTO dto)
        {
            var flightEntity = dto.ToEntity();

            _context.Flights.Add(flightEntity);
            await _context.SaveChangesAsync();

            return flightEntity.ToDTO();
        }

        /// <summary>
        /// Updates an existing flight record by ID.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to update.</param>
        /// <param name="dto">The DTO containing updated flight details.</param>
        /// <returns>
        /// The task result contains the updated GetFlightDTO object if the update succeeded; otherwise, null if the flight was not found.
        /// </returns>
        public async Task<GetFlightDTO> UpdateAsync(int flightId, CreateAndUpdateFlightDTO dto)
        {
            var existingFlight = await _context.Flights.FindAsync(flightId);
            if (existingFlight == null)
            {
                return null;
            }

            var updateFlight = dto.ToEntity();
            if (updateFlight == null)
            {
                return null;
            }

            dto.UpdateEntity(existingFlight);
            await _context.SaveChangesAsync();

            return existingFlight.ToDTO();
        }

        /// <summary>
        /// Deletes a flight record by ID asynchronously.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to delete.</param>
        /// <returns>
        /// A message indicating the result of the delete operation, or null if the flight was not found.
        /// </returns>
        public async Task<string> DeleteAsync(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight == null)
            {
                return null;
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return $"Flight with ID {flightId} deleted successfully.";
        }
    }
}