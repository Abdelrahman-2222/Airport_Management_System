namespace Airplane_UI.Components.Pages
{
    public partial class AirlineMain
    {
        private readonly string[] _entities = new[]
{
        "Airline",
        "Aircraft",
        "Airport",
        "Flight",
        "FlightManifest",
        "Passenger"
    };
        private void OnEntityClick(string entity)
        {
            if (entity == "Airline")
                NavigationManager.NavigateTo("/airline");
            else if (entity == "Aircraft")
                NavigationManager.NavigateTo("/aircraft");
            else if (entity == "Airport")
                NavigationManager.NavigateTo("/airport");
            else if (entity == "Flight")
                NavigationManager.NavigateTo("/flight");
            else if (entity == "FlightManifest")
                NavigationManager.NavigateTo("/flight-manifest");
            else if (entity == "Passenger")
                NavigationManager.NavigateTo("/passenger");
        }
    }
}
