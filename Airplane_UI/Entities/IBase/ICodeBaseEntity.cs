namespace Airplane_UI.Entities.Base
{
    /// <summary>
    /// Represents an entity that includes Id, name and IATA code properties 
    /// for all derived entities.
    /// </summary>
    public interface ICodeBaseEntity
    {
        /// <summary>
        /// Gets or sets the IATA code of the entity.
        /// </summary>
        public string IATA_Code { get; set; }
    }
}
