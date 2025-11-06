using Airplane_UI.DTOs.SecurityGates.SecurityIncident;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityIncident
    {
        private IList<GetSecurityIncidentDto> SecurityIncidents = new List<GetSecurityIncidentDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadSecurityIncidentsAsync();
        }

        private async Task LoadSecurityIncidentsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                SecurityIncidents = await SecurityIncidentService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading security incidents: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/security-incident/details/{id}");
        }
    }
}



