using Airplane_UI.Enums;

namespace Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;

public class GetLostAndFoundDTO
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
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
    public string Status { get; set; }
}
