using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class CateringFacilitiesCreate
    {
        private CreateAndUpdateCateringFacilitiesDTO facilitiesModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await CateringFacilitiesService.CreateAsync(facilitiesModel);

                Navigation.NavigateTo("/cateringfacilities");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cateringfacilities: {ex.Message}");

                errorMessage = "An error occurred while creating the cateringfacilities. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/cateringfacilities");
        }
    }
}
