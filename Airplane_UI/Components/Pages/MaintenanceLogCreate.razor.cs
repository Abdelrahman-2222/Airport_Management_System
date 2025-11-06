using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceLogCreate
    {
        private CreateAndUpdateMaintenanceLogDTO maintenanceLogModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await MaintenanceLogService.CreateAsync(maintenanceLogModel);

                Navigation.NavigateTo("/maintenancelog");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating maintenancelog: {ex.Message}");

                errorMessage = "An error occurred while creating the maintenancelog. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/maintenancelog");
        }
    }
}
