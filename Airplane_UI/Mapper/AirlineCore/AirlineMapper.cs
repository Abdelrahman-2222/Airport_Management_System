using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Airplane_UI.Entities.AirlineCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    /// <summary>
    /// This static class contains mapping methods to convert between entity and DTO representations.
    /// </summary>
    public static class AirlineMapper
    {
        /// <summary>
        /// Converts an airline entity into a GetAirportDTO.
        /// </summary>
        /// <param name="airport">The airline entity to convert.</param>
        /// <returns>
        /// A GetAirlineDTO containing the mapped data from the provided entity.
        /// </returns>
        public static GetAirlineDTO ToDto(this Airline airline)
        {
            return new GetAirlineDTO
            {
                Id = airline.Id,
                Name = airline.Name,
                IATA_Code = airline.IATA_Code
            };
        }

        /// <summary>
        /// Converts a GetAirportDTO into an airline entity.
        /// </summary>
        /// <param name="airlineDto">The data transfer object representing an airline.</param>
        /// <returns>
        /// An Airline entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Airline ToEntity(this GetAirlineDTO airlineDTO)
        {
            return new Airline
            {
                Id = airlineDTO.Id,
                Name = airlineDTO.Name,
                IATA_Code = airlineDTO.IATA_Code
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateAirlineDTO into an Airline entity.
        /// </summary>
        /// <param name="dto">dto used for creating or updating an airline.</param>
        /// <returns>
        /// An Airline entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Airline ToEntity(this CreateAndUpdateAirlineDTO dto)
        {
            return new Airline
            {
                Name = dto.Name,
                IATA_Code = dto.IATA_Code
            };
        }
    }
}
