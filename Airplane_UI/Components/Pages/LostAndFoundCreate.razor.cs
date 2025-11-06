
using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class LostAndFoundCreate
    {
        private CreateAndUpdateLostandFoundDTO lostAndFoundModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await LostAndFoundService.CreateAsync(lostAndFoundModel);

                Navigation.NavigateTo("/lostandfound");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating lostandfound: {ex.Message}");

                errorMessage = "An error occurred while creating the lostandfound. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/lostandfound");
        }
    }
}
