using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Data;
using Airplane_UI.DTOs.AirlineCore.PassengerDTOs;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    /// <summary>
    /// Provides implementation for managing passenger data,
    /// including creating, retrieving, updating, and deleting passenger records.
    /// </summary>
    public class PassengerService : IPassengerService
    {
        private readonly AirplaneManagementSystemContext _context;

        /// <summary>
        /// Initializes a new instance of the PassengerService class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public PassengerService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all passengers asynchronously.
        /// </summary>
        /// <returns>
        /// A collection of GetPassengerDTO objects representing all passengers in the system.
        /// </returns>
        public async Task<IEnumerable<GetPassengerDTO>> GetAllAsync()
        {
            var passengers = await _context.Passengers
                .Select(p => p.ToDTO())
                .ToListAsync();

            return passengers;
        }

        /// <summary>
        /// Retrieves a specific passenger by their unique identifier.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to retrieve.</param>
        /// <returns>
        /// A GetPassengerDTO object representing the passenger, or null if not found.
        /// </returns>
        public async Task<GetPassengerDTO> GetByIdAsync(int passengerId)
        {
            var passenger = await _context.Passengers
                .Where(p => p.Id == passengerId)
                .Select(p => p.ToDTO())
                .SingleOrDefaultAsync();

            return passenger;
        }

        /// <summary>
        /// Creates a new passenger record asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing passenger details to create.</param>
        /// <returns>
        /// The newly created passenger as a GetPassengerDTO object.
        /// </returns>
        public async Task<GetPassengerDTO> CreateAsync(CreateAndUpdatePassengerDTO dto)
        {
            var passengerEntity = dto.ToEntity();

            _context.Passengers.Add(passengerEntity);
            await _context.SaveChangesAsync();

            return passengerEntity.ToDTO();
        }

        /// <summary>
        /// Updates an existing passenger record by ID.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to update.</param>
        /// <param name="dto">The DTO containing updated passenger details.</param>
        /// <returns>
        /// The updated GetPassengerDTO object if the update succeeded; otherwise, null if the passenger was not found.
        /// </returns>
        public async Task<GetPassengerDTO> UpdateAsync(int passengerId, CreateAndUpdatePassengerDTO dto)
        {
            var existingPassenger = await _context.Passengers.FindAsync(passengerId);
            if (existingPassenger == null)
            {
                return null;
            }

            var updatePassenger = dto.ToEntity();
            if (updatePassenger == null)
            {
                return null;
            }

            dto.UpdateEntity(existingPassenger);
            await _context.SaveChangesAsync();

            return existingPassenger.ToDTO();
        }

        /// <summary>
        /// Deletes a passenger record by ID asynchronously.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to delete.</param>
        /// <returns>
        /// A message indicating the result of the delete operation, or null.
        /// </returns>
        public async Task<string> DeleteAsync(int passengerId)
        {
            var passenger = await _context.Passengers.FindAsync(passengerId);
            if (passenger == null)
            {
                return null;
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            return $"Passenger with ID {passengerId} deleted successfully.";
        }
    }
}