using Airplane_UI.DTOs.SecurityGates.AirportStaff;

namespace Airplane_UI.Components.Pages
{
    public partial class AirportStaff
    {
        private IList<GetAirportStaffDto> AirportStaffs = new List<GetAirportStaffDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadAirportStaffsAsync();
        }

        private async Task LoadAirportStaffsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                AirportStaffs = await AirportStaffService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading airport staff: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/airport-staff/details/{id}");
        }
    }
}



