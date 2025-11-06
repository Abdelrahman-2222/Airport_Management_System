
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceLog
    {
        private IList<GetMaintenanceLogDTO> maintenanceLogs = new List<GetMaintenanceLogDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadAirlinesAsync();
        }

        private async Task LoadAirlinesAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                maintenanceLogs = await MaintenanceLogService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading maintenanceLogs: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }
        private void NavigateToDetails(int maintenancelogId)
        {
            Navigation.NavigateTo($"/maintenancelog/details/{maintenancelogId}");
        }
    }
}
