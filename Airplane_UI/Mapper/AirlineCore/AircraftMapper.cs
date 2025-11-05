using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.Entities.AirlineCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    /// <summary>
    /// This static class contains mapping methods to convert between entity and DTO representations.
    /// </summary>
    public static class AircraftMapper
    {
        /// <summary>
        /// Converts an aircraft entity into a GetAircraftDTO.
        /// </summary>
        /// <param name="aircraft">The aircraft entity to convert.</param>
        /// <returns>
        /// A GetAircraftDTO containing the mapped data from the provided entity.
        /// </returns>
        public static GetAircraftDTO ToDto(this Aircraft aircraft)
        {
            return new GetAircraftDTO
            {
                Id = aircraft.Id,
                TailNumber = aircraft.TailNumber,
                Model = aircraft.Model,
                AirlineId = aircraft.AirlineId
            };
        }

        /// <summary>
        /// Converts a GetAircraftDTO into an aircraft entity.
        /// </summary>
        /// <param name="aircraftDto">The dto representing an aircraft.</param>
        /// <returns>
        /// An Aircraft entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Aircraft ToEntity(this GetAircraftDTO aircraftDto)
        {
            return new Aircraft
            {
                Id = aircraftDto.Id,
                TailNumber = aircraftDto.TailNumber,
                Model = aircraftDto.Model,
                AirlineId = aircraftDto.AirlineId
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateAircraftDTO into an Aircraft entity.
        /// </summary>
        /// <param name="dto">dto used for creating or updating an aircraft.</param>
        /// <returns>
        /// An Aircraft entity containing the mapped data from the provided DTO.
        /// </returns>
        public static Aircraft ToEntity(this CreateAndUpdateAircraftDTO dto)
        {
            return new Aircraft
            {
                TailNumber = dto.TailNumber,
                Model = dto.Model,
                AirlineId = dto.AirlineId
            };
        }
    }
}
