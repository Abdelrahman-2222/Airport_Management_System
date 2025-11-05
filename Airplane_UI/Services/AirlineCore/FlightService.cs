using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.DTOs.AirlineCore.FlightDTOs;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    public class FlightService : IFlightService
    {
        private readonly AirplaneManagementSystemContext _context;

        public FlightService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all flights asynchronously.
        /// </summary>
        public async Task<IList<GetFlightDTO>> GetAllAsync()
        {
            var flights = await _context.Flights
                .Select(a => a.ToDTO())
                .ToListAsync();

            return flights;
        }

        /// <summary>
        /// Retrieves a specific flight by its unique identifier.
        /// </summary>
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
        /// <returns>The new created flight as a DTO.</returns>
        public async Task<GetFlightDTO> CreateAsync(CreateAndUpdateFlightDTO dto)
        {
            var flight = dto.ToEntity();

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return flight.ToDTO();
        }
        /// <summary>
        /// Updates an existing airport record by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the airport to update.</param>
        /// <param name="dto">The DTO containing updated airport details.</param>
        /// <returns>
        /// The task result contains the updated GetAirportDTO object if the update succeeded. otherwise, null if the airport was not found.
        /// </returns>
        public async Task<GetFlightDTO> UpdateAsync(int id, CreateAndUpdateFlightDTO dto)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null) return null;

            var updatedFlight = dto.ToEntity();

            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();

            return flight.ToDTO();
        }

        /// <summary>
        /// Deletes an flight record by ID asynchronously.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to delete.</param>
        /// <returns>A message indicating the result of the delete operation, or null if not found.</returns>
        public async Task<string> DeleteAsync(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight == null) return null;

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return $"Flight with ID {flight} deleted successfully.";
        }
    }
}
