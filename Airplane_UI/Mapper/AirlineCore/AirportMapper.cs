using Airplane_API.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.Entities.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    public static class AirportMapper
    {
        
        public static GetAirportDTO ToDto(this Airport airport)
        {
            return new GetAirportDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                IATA_Code = airport.IATA_Code
            };
        }

        public static Airport ToEntity(this GetAirportDTO airportDto)
        {
            return new Airport
            {
                Id = airportDto.Id,
                Name = airportDto.Name,
                IATA_Code = airportDto.IATA_Code
            };
        }

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
