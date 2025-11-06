
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceTask
    {
        private IList<GetMaintenanceTaskDTO> MaintenanceTasks = new List<GetMaintenanceTaskDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadMaintenanceTaskServiceAsync();
        }

        private async Task LoadMaintenanceTaskServiceAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                MaintenanceTasks = await MaintenanceTaskService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading MaintenanceTasks: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }
        private void NavigateToDetails(int maintenancetaskId)
        {
            Navigation.NavigateTo($"/maintenancetask/details/{maintenancetaskId}");
        }
    }
}
