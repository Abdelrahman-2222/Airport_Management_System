namespace Airplane_API.Entities.Base
{
    /// <summary>
    /// Represents an entity that includes Id, name and IATA code properties 
    /// for all derived entities.
    /// </summary>
    public class CodeBaseEntity : NamedBaseEntity
    {
        /// <summary>
        /// Gets or sets the IATA code of the entity.
        /// </summary>
        public string IATA_Code { get; set; }
    }
}
