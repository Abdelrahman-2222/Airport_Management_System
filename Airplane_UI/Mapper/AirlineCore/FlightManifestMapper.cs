using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;
using Airplane_UI.Entities.AirlineCore;

namespace Airplane_UI.Mapper.AirlineCore
{
    /// <summary>
    /// Provides mapping methods for converting between FlightManifest entities and their corresponding DTOs.
    /// </summary>
    public static class FlightManifestMapper
    {
        /// <summary>
        /// Converts a FlightManifest entity to a GetFlightManifestDTO.
        /// </summary>
        /// <param name="flightManifest">The flight manifest entity to convert.</param>
        /// <returns> A GetFlightManifestDTO object that represents the provided flight manifest entity or null if the input is null. </returns>
        public static GetFlightManifestDTO ToDTO(this FlightManifest flightManifest)
        {
            if (flightManifest == null) return null;

            return new GetFlightManifestDTO
            {
                Id = flightManifest.Id,
                SeatNumber = flightManifest.SeatNumber,
                FlightId = flightManifest.FlightId,
                PassengerId = flightManifest.PassengerId
            };
        }

        /// <summary>
        /// Converts a GetFlightManifestDTO object to a FlightManifest entity.
        /// </summary>
        /// <param name="dto">The DTO object to convert.</param>
        /// <returns> A FlightManifest entity that represents the provided DTO or null if the input is null.</returns>
        public static FlightManifest ToEntity(this GetFlightManifestDTO dto)
        {
            if (dto == null) return null;

            return new FlightManifest
            {
                Id = dto.Id,
                SeatNumber = dto.SeatNumber,
                FlightId = dto.FlightId,
                PassengerId = dto.PassengerId
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateFlightManifestDTO object to a new FlightManifest entity.
        /// </summary>
        /// <param name="dto">The DTO containing the flight manifest data.</param>
        /// <returns> A FlightManifest entity initialized with values from the provided DTO or null if the input is null.</returns>
        public static FlightManifest ToEntity(this CreateAndUpdateFlightManifestDTO dto)
        {
            if (dto == null) return null;

            return new FlightManifest
            {
                SeatNumber = dto.SeatNumber,
                FlightId = dto.FlightId,
                PassengerId = dto.PassengerId
            };
        }
    }
}
