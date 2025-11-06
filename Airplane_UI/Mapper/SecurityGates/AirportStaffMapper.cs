using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.Entities.SecurityGates;

namespace Airplane_UI.Mappers.SecurityGates
{
    /// <summary>
    /// Provides mapping functions between <see cref="AirportStaff"/> entities
    /// and their corresponding Data Transfer Objects (DTOs).
    /// </summary>
    public static class AirportStaffMapper
    {
        /// <summary>
        /// Converts an <see cref="AirportStaff"/> entity to a <see cref="GetAirportStaffDto"/>.
        /// </summary>
        /// <param name="staff">The AirportStaff entity to convert.</param>
        /// <returns>A corresponding GetAirportStaffDto object.</returns>
        public static GetAirportStaffDto ToGetDto(AirportStaff staff)
        {
            return new GetAirportStaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role
            };
        }

        /// <summary>
        /// Converts a <see cref="CreateAirportStaffDto"/> to an <see cref="AirportStaff"/> entity.
        /// </summary>
        /// <param name="dto">The CreateAirportStaffDto to convert.</param>
        /// <returns>A new AirportStaff entity.</returns>
        public static AirportStaff ToEntity(CreateAirportStaffDto dto)
        {
            return new AirportStaff
            {
                Name = dto.Name,
                Role = dto.Role
            };
        }

        /// <summary>
        /// Updates an existing <see cref="AirportStaff"/> entity using data from an <see cref="UpdateAirportStaffDto"/>.
        /// </summary>
        /// <param name="staff">The entity to update.</param>
        /// <param name="dto">The DTO containing updated values.</param>
        public static void UpdateEntity(AirportStaff staff, UpdateAirportStaffDto dto)
        {
            staff.Name = dto.Name;
            staff.Role = dto.Role;
        }
    }
}
