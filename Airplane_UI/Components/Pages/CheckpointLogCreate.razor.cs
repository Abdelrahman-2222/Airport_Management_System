using Airplane_UI.DTOs.SecurityGates.CheckpointLog;

namespace Airplane_UI.Components.Pages
{
    public partial class CheckpointLogCreate
    {
        private CreateCheckpointLogDto logModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private int hours = 0;
        private int minutes = 0;
        private int seconds = 0;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                // Update the wait time from the form inputs
                logModel.ReportedWaitTime = new TimeSpan(hours, minutes, seconds);
                
                await CheckpointLogService.CreateAsync(logModel);
                Navigation.NavigateTo("/checkpoint-log");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating checkpoint log: {ex.Message}");
                errorMessage = "An error occurred while creating the checkpoint log. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/checkpoint-log");
        }
    }
}

