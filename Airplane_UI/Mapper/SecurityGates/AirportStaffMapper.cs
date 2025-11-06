using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping functions between AirportStaff entities
    /// and their corresponding Data Transfer Objects (DTOs).
    /// </summary>
    public static class AirportStaffMapper
    {
        /// <summary>
        /// Converts an AirportStaff entity to a GetAirportStaffDto.
        /// </summary>
        /// <param name="staff">The AirportStaff entity to convert.</param>
        /// <returns>
        /// A GetAirportStaffDto object containing mapped data.
        /// </returns>
        public static GetAirportStaffDto ToDto(AirportStaff staff)
        {
            return new GetAirportStaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role
            };
        }

        /// <summary>
        /// Converts a CreateAirportStaffDto to an AirportStaff entity.
        /// </summary>
        /// <param name="dto">The CreateAirportStaffDto containing data to create the entity.</param>
        /// <returns>
        /// A new AirportStaff entity populated with data from the DTO.
        /// </returns>
        public static AirportStaff ToEntity(CreateAirportStaffDto dto)
        {
            return new AirportStaff
            {
                Name = dto.Name,
                Role = dto.Role
            };
        }

        /// <summary>
        /// Updates an existing AirportStaff entity using data from an UpdateAirportStaffDto.
        /// </summary>
        /// <param name="dto">The DTO containing updated staff information.</param>
        /// <param name="entity">The existing AirportStaff entity to update.</param>
        public static void UpdateEntity(this UpdateAirportStaffDto dto, AirportStaff entity)
        {
            if (entity == null || dto == null) return;

            entity.Name = dto.Name;
            entity.Role = dto.Role;
        }
    }
}
