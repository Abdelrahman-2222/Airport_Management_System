using Airplane_API.Entities.Base;
using Airplane_API.Enums;

namespace Airplane_API.Entities.LuggageMaintnance;

/// <summary>
/// Represents a lost and found item with its description, date found, and current status.
/// </summary>
public class LostAndFound : BaseEntity
{
    /// <summary>
    /// Description of the lost or found item.
    /// </summary>
    public string ItemDescription { get; set; }

    /// <summary>
    /// The date when the item was found.
    /// </summary>
    public DateTime DateFound { get; set; }

    /// <summary>
    /// The current status of the lost and found item.
    /// </summary>
    public LostAndFoundStatus Status { get; set; }
}
