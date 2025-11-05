namespace Airplane_UI.DTOs.AirlineCore.AirlineDTOs
{
    /// <summary>
    /// Represents (DTO) for retrieving airline details.
    /// </summary>
    public class GetAirlineDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the airline.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the airline.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the International Air Transport Association (IATA) code of the airline.
        /// </summary>
        public string IATA_Code { get; set; }
    }
}
