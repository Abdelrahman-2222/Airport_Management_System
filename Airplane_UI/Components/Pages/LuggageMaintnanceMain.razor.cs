namespace Airplane_UI.Components.Pages;

public partial class LuggageMaintnanceMain
{
    private readonly string[] _entities = new[]
    {
        "BaggageClaim",
        "CateringFacilities",
        "CateringOrder",
        "LostAndFound",
        "MaintenanceLog",
        "MaintenanceTask"
    };
    private void OnEntityClick(string entity)
    {
        if (entity == "BaggageClaim")
            NavigationManager.NavigateTo("/baggagcelaim");
        else if (entity == "CateringFacilities")
            NavigationManager.NavigateTo("/cateringfacilities");
        else if (entity == "CateringOrder")
            NavigationManager.NavigateTo("/cateringorder");
        else if (entity == "LostAndFound")
            NavigationManager.NavigateTo("/lostandfound");
        else if (entity == "MaintenanceLog")
            NavigationManager.NavigateTo("/maintenancelog");
        else if (entity == "MaintenanceTask")
            NavigationManager.NavigateTo("/maintenancetask");
    }
}
