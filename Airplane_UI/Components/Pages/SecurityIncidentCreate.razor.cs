using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityIncidentCreate
    {
        [Inject]
        private IAirportStaffService AirportStaffService { get; set; }

        private CreateSecurityIncidentDto incidentModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;
        private IList<GetAirportStaffDto> staffOptions = new List<GetAirportStaffDto>();
        private string staffLoadError = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                staffOptions = await AirportStaffService.GetAllAsync();
            }
            catch (Exception ex)
            {
                staffLoadError = $"Failed to load staff: {ex.Message}";
            }
        }

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



