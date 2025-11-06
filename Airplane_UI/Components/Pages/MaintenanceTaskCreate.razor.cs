
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceTaskCreate
    {
        private CreateAndUpdateMaintenanceTaskDTO maintenanceTaskModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await MaintenanceTaskService.CreateAsync(maintenanceTaskModel);

                Navigation.NavigateTo("/maintenancetask");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating MaintenanceTask: {ex.Message}");

                errorMessage = "An error occurred while creating the MaintenanceTask. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/maintenancetask");
        }
    }
}
