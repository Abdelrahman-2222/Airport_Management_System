using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class AirlineCreate
    {
        // The object that will be bound to the form inputs
        private CreateAndUpdateAirlineDTO airlineModel = new();

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
                await AirlineService.CreateAsync(airlineModel);

                // Navigate back to the airline list page
                Navigation.NavigateTo("/airline");
            }
            catch (Exception ex)
            {
                // Log the full error for debugging
                Console.WriteLine($"Error creating airline: {ex.Message}");

                // Show a user-friendly error
                errorMessage = "An error occurred while creating the airline. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/airline");
        }
    }
}
