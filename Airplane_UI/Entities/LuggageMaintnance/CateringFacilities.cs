using Airplane_API.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_API.Entities.LuggageMaintnance;
/// <summary>
/// Represents catering facilities that provide food services, including provider details and related catering orders.
/// </summary>
public class CateringFacilities : INamedBaseEntity , IBaseEntity
{
    /// <summary>
    /// Initializes a new instance of the CateringFacilities class and sets up the CateringOrders collection.
    /// </summary>

    public int Id { get; set; }
    /// <summary>
    /// The name of the catering service provider.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Contact information for the catering service provider.
    /// </summary>
    public string ContactInfo { get; set; }
    /// <summary>
    /// Collection of catering orders associated with this catering facility.
    /// </summary>
    public virtual ICollection<CateringOrder> CateringOrders { get; set; } = new HashSet<CateringOrder>();
}
