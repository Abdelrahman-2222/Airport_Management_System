namespace Airplane_UI.Components.Pages
{
    public partial class SecurityMain
    {
        private readonly string[] _entities = new[]
        {
            "Security Checkpoint",
            "Checkpoint Log",
            "Airport Staff",
            "Security Incident",
            "Customs Desk",
            "Staff Shift"
        };

        private void OnEntityClick(string entity)
        {
            if (entity == "Security Checkpoint")
                NavigationManager.NavigateTo("/security-checkpoint");
            else if (entity == "Checkpoint Log")
                NavigationManager.NavigateTo("/checkpoint-log");
            else if (entity == "Airport Staff")
                NavigationManager.NavigateTo("/airport-staff");
            else if (entity == "Security Incident")
                NavigationManager.NavigateTo("/security-incident");
            else if (entity == "Customs Desk")
                NavigationManager.NavigateTo("/customs-desk");
            else if (entity == "Staff Shift")
                NavigationManager.NavigateTo("/staff-shift");
        }
    }
}


