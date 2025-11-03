namespace Airplane_API.Entities.Base
{
    /// <summary>
    /// Represents an entity that includes a name and unique identifier 
    /// for all derived entities.
    /// </summary>
    public class NamedBaseEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name { get; set; }
    }
}
