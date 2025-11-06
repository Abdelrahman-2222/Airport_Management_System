using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.Services.AirlineCore;

namespace Airplane_UI.Components.Pages
{
    public partial class CateringFacilities
    {
        private IList<GetCateringFacilitiesDTO> Facilities = new List<GetCateringFacilitiesDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadFacilitiesAsync();
        }

        private async Task LoadFacilitiesAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                Facilities = await CateringFacilitiesService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading cateringfacilities: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }
        private void NavigateToDetails(int cateringfacilitiesId)
        {
            Navigation.NavigateTo($"/cateringfacilities/details/{cateringfacilitiesId}");
        }
    }
}
