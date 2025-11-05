using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class Airline
    {
        private IList<GetAirlineDTO> Airlines = new List<GetAirlineDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadAirlinesAsync();
        }

        private async Task LoadAirlinesAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                Airlines = await AirlineService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading airlines: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }
        private void NavigateToDetails(int airlineId)
        {
            Navigation.NavigateTo($"/airline/details/{airlineId}");
        }
    }
}
