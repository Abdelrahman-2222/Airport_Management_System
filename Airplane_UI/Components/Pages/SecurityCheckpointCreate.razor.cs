using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityCheckpointCreate
    {
        private CreateSecurityCheckpointDto checkpointModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await SecurityCheckpointService.CreateAsync(checkpointModel);
                Navigation.NavigateTo("/security-checkpoint");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating security checkpoint: {ex.Message}");
                errorMessage = "An error occurred while creating the security checkpoint. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/security-checkpoint");
        }
    }
}

