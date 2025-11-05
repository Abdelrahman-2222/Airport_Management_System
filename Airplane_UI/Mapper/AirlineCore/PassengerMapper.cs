using Airplane_UI.DTOs.AirlineCore.PassengerDTOs;
using Airplane_UI.Entities.AirlineCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    /// <summary>
    /// Provides mapping extensions for converting between Passenger entities and Passenger DTOs.
    /// </summary>
    public static class PassengerMapper
    {
        /// <summary>
        /// Converts a Passenger entity to a GetPassengerDTO object.
        /// </summary>
        /// <param name="passenger">The Passenger entity to convert.</param>
        /// <returns> A GetPassengerDTO object representing the Passenger entity, or null if the input is null.</returns>
        public static GetPassengerDTO ToDTO(this Passenger passenger)
        {
            if (passenger == null) return null;

            return new GetPassengerDTO
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                PassportNumber = passenger.PassportNumber
            };
        }

        /// <summary>
        /// Converts a GetPassengerDTO object to a Passenger entity.
        /// </summary>
        /// <param name="dto">The GetPassengerDTO object to convert.</param>
        /// <returns> A Passenger entity representing the DTO, or null if the input is null.</returns>
        public static Passenger ToEntity(this GetPassengerDTO dto)
        {
            if (dto == null) return null;

            return new Passenger
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PassportNumber = dto.PassportNumber
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdatePassengerDTO object to a Passenger entity.
        /// </summary>
        /// <param name="dto">The CreateAndUpdatePassengerDTO object containing passenger details.</param>
        /// <returns> A new Passenger entity initialized with data from the DTO, or null if the input is null.</returns>
        public static Passenger ToEntity(this CreateAndUpdatePassengerDTO dto)
        {
            if (dto == null) return null;

            return new Passenger
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PassportNumber = dto.PassportNumber
            };
        }
    }
}
