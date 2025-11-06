using Airplane_UI.DTOs.AirlineCore.FlightDTOs;
using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;
using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Enums;

namespace Airplane_UI.Mapper.AirlineCore
{
    // <summary>
    /// This static class contains mapping methods to convert between entity and DTO representations.
    /// </summary>
    public static class FlightMapper
    {
        /// <summary>
        /// Converts an Flight entity into a GetFlightDTO.
        /// </summary>
        /// <param name="flight">The flight entity to convert.</param>
        /// <returns> A GetFlightDTO containing the mapped data from the provided entity.</returns>
        public static GetFlightDTO ToDTO(this Flight flight)
        {
            if (flight == null) return null;
            return new GetFlightDTO
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                ScheduledDeparture = flight.ScheduledDeparture,
                ScheduledArrival = flight.ScheduledArrival,
                Status = flight.Status.ToString(),
                AirlineId = flight.AirlineId,
                AircraftId = flight.AircraftId,
                OriginAirportId = flight.OriginAirportId,
                DestinationAirportId = flight.DestinationAirportId
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateFlightDTO into a Flight entity.
        /// </summary>
        /// <param name="dto">The dto used for creating or updating a flight.</param>
        /// <returns> A Flight entity containing the mapped data from the provided DTO.</returns>
        public static Flight ToEntity(this CreateAndUpdateFlightDTO dto)
        {
            if (dto == null) return null;
            return new Flight
            {
                FlightNumber = dto.FlightNumber,
                ScheduledDeparture = dto.ScheduledDeparture,
                ScheduledArrival = dto.ScheduledArrival,
                Status = Enum.Parse<FlightStatus>(dto.Status),
                AirlineId = dto.AirlineId,
                AircraftId = dto.AircraftId,
                OriginAirportId = dto.OriginAirportId,
                DestinationAirportId = dto.DestinationAirportId
            };
        }

        /// <summary>
        /// Converts a CreateAndUpdateFlightDTO into a Flight entity.
        /// </summary>
        /// <param name="dto">The CreateAndUpdateFlightDTO containing data for creation or update.</param>
        /// <param name="entity">The Flight entity to convert.</param>
        public static void UpdateEntity(this CreateAndUpdateFlightDTO dto, Flight entity)
        {
            if (entity == null || dto == null) return;

            entity.FlightNumber = dto.FlightNumber;
            entity.ScheduledDeparture = dto.ScheduledDeparture;
            entity.ScheduledArrival = dto.ScheduledArrival;
            entity.Status = Enum.Parse<FlightStatus>(dto.Status);
            entity.AirlineId = dto.AirlineId;
            entity.AircraftId = dto.AircraftId;
            entity.OriginAirportId = dto.OriginAirportId;
            entity.DestinationAirportId = dto.DestinationAirportId;
        }
    }
}
