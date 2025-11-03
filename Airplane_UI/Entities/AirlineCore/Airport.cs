using Airplane_UI.Entities.Base;

namespace Airplane_UI.Entities.AirlineCore
{
    /// <summary>
    /// Represents an Airport entity within the system
    /// and inherits Id, Name and IATA_Code from CodeBaseEntity
    /// </summary>
    public class Airport : IBaseEntity, INamedBaseEntity, ICodeBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IATA_Code { get; set; }

    }
}
