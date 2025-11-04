using Airplane_UI.Entities.Base;

namespace Airplane_UI.Entities.AirlineCore
{
    /// <summary>
    /// Represents an airport entity within the system.
    /// This entity implements the IBaseEntity, INamedBaseEntity,and ICodeBaseEntity interfaces, which define the basic entity structure 
    /// including an identifier, a name, and a code.
    /// </summary>
    public class Airport : IBaseEntity, INamedBaseEntity, ICodeBaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the airport.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the official name of the airport.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the International Air Transport Association (IATA) code of the airport.
        /// </summary>
        public string IATA_Code { get; set; }
    }
}
