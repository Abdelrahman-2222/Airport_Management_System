using Airplane_API.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplane_API.Entities.LuggageMaintnance;
/// <summary>
/// Represents catering facilities that provide food services, including provider details and related catering orders.
/// </summary>
public class CateringFacilities : NamedBaseEntity
{
    /// <summary>
    /// Initializes a new instance of the CateringFacilities class and sets up the CateringOrders collection.
    /// </summary>
    public CateringFacilities()
    {
        CateringOrders = new HashSet<CateringOrder>();
    }
    /// <summary>
    /// The name of the catering service provider.
    /// </summary>
    public string ProviderName { get; set; }
    /// <summary>
    /// The name property mapped to ProviderName, not stored in the database.
    /// </summary>
    [NotMapped]
    public override string Name
    { 
        get => ProviderName; 
        set => ProviderName = value; 
    }
    /// <summary>
    /// Contact information for the catering service provider.
    /// </summary>
    public string ContactInfo { get; set; }
    /// <summary>
    /// Collection of catering orders associated with this catering facility.
    /// </summary>
    public virtual ICollection<CateringOrder> CateringOrders { get; set; }
}
