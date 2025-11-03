namespace Airplane_UI.Entities.Base
{
    /// <summary>
    /// Represents an entity that includes a name and unique identifier 
    /// for all derived entities.
    /// </summary>
    public interface INamedBaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name { get; set; }
    }
}
