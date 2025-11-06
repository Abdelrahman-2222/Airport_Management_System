
using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class AircraftCreate
    {
        // The object that will be bound to the form inputs
        private CreateAndUpdateAircraftDTO aircraftModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        /// <summary>
        /// This method is called when the form is submitted AND is valid.
        /// </summary>
        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                // Call the service with the data from the form
                await AircraftService.CreateAsync(aircraftModel);

                // Navigate back to the aircraft list page
                Navigation.NavigateTo("/aircraft");
            }
            catch (Exception ex)
            {
                // Log the full error for debugging
                Console.WriteLine($"Error creating aircraft: {ex.Message}");

                // Show a user-friendly error
                errorMessage = "An error occurred while creating the aircraft. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/aircraft");
        }
    }
}
