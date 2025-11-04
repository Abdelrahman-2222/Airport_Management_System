using Airplane_UI.Entities.AirlineCore;

namespace Airplane_API.DTOs.AirlineCore.AirportDTOs
{
    /// <summary>
    /// Represents a (DTO) for an airport.
    /// </summary>
    public class GetAirportDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the airport.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the airport.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the International Air Transport Association (IATA) airport code.
        /// </summary>
        public string IATA_Code { get; set; }
    }
}
