using Airplane_UI.DTOs.SecurityGates.SecurityIncident;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityIncidentCreate
    {
        private CreateSecurityIncidentDto incidentModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await SecurityIncidentService.CreateAsync(incidentModel);
                Navigation.NavigateTo("/security-incident");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating security incident: {ex.Message}");
                errorMessage = "An error occurred while creating the security incident. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/security-incident");
        }
    }
}



