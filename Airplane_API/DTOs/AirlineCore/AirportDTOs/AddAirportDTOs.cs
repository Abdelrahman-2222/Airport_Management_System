namespace Airplane_API.DTOs.AirlineCore.AirportDTOs
{
    /// <summary>
    /// Represents a (DTO) used when creating a new airport record.
    /// </summary>
    public class AddAirportDTOs
    {
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