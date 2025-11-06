using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
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

        /// <summary>
        /// Converts a CreateAndUpdateAircraftDTO into a Aircraft entity.
        /// </summary>
        /// <param name="dto">The CreateAndUpdateAircraftDTO containing data for creation or update.</param>
        /// <param name="entity">The Aircraft entity to convert.</param>
        public static void UpdateEntity(this CreateAndUpdateAircraftDTO dto, Aircraft entity)
        {
            if (entity == null || dto == null) return;

            entity.TailNumber = dto.TailNumber;
            entity.Model = dto.Model;
            entity.AirlineId = dto.AirlineId;
        }
    }
}
