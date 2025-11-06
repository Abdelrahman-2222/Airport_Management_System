using Airplane_UI.DTOs.SecurityGates.AirportStaff;

namespace Airplane_UI.Components.Pages
{
    public partial class AirportStaffCreate
    {
        private CreateAirportStaffDto staffModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await AirportStaffService.CreateAsync(staffModel);
                Navigation.NavigateTo("/airport-staff");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating airport staff: {ex.Message}");
                errorMessage = "An error occurred while creating the airport staff. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/airport-staff");
        }
    }
}



