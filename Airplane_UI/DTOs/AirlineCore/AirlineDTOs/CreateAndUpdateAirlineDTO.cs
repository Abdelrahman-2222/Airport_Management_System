namespace Airplane_UI.DTOs.AirlineCore.AirlineDTOs
{
    /// <summary>
    /// Represents a (DTO) used when creating a new airline record.
    /// </summary>
    public class CreateAndUpdateAirlineDTO
    {
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
