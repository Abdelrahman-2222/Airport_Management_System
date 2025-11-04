using Airplane_UI.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    /// <summary>
    /// This static class contains mapping methods to convert between entity and DTO representations.
    /// </summary>
    public static class AirportMapper
    {
        /// <summary>
        /// Converts an Airport entity into a GetAirportDTO.
        /// </summary>
        /// <param name="airport">The airport entity to convert.</param>
        /// <returns>
        /// A GetAirportDTO containing the mapped data from the provided entity.
        /// </returns>
        public static GetAirportDTO ToDto(this Airport airport)
        {
            return new GetAirportDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                IATA_Code = airport.IATA_Code
            };
        }

        /// <summary>
        /// Converts a GetAirportDTO into an Airport entity.
        /// </summary>
        /// <param name="airportDto">The data transfer object representing an airport.</param>
        /// <returns>
        /// An Airport entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Airport ToEntity(this GetAirportDTO airportDto)
        {
            return new Airport
            {
                Id = airportDto.Id,
                Name = airportDto.Name,
                IATA_Code = airportDto.IATA_Code
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateAirportDTO into an Airport entity.
        /// </summary>
        /// <param name="dto">The data transfer object used for creating or updating an airport.</param>
        /// <returns>
        /// An Airport entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Airport ToEntity(this CreateAndUpdateAirportDTO dto)
        {
            return new Airport
            {
                Name = dto.Name,
                IATA_Code = dto.IATA_Code
            };
        }
    }
}
