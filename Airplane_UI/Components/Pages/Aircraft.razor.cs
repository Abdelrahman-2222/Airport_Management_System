using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;

namespace Airplane_UI.Components.Pages
{
    public partial class Aircraft
    {
        private IList<GetAircraftDTO> Aircrafts = new List<GetAircraftDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadAircraftsAsync();
        }

        private async Task LoadAircraftsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                Aircrafts = await AircraftService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading aircraft: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int aircraftId)
        {
            Navigation.NavigateTo($"/aircraft/details/{aircraftId}");
        }
    }
}
