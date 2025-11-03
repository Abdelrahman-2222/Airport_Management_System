namespace Airplane_API.Entities.Base
{
    /// <summary>
    /// Represents the base entity that defines a unique identifier for all derived entities.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }
    }
}
