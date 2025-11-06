using Airplane_UI.DTOs.SecurityGates.StaffShift;

namespace Airplane_UI.Components.Pages
{
    public partial class StaffShift
    {
        private IList<GetStaffShiftDto> StaffShifts = new List<GetStaffShiftDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadStaffShiftsAsync();
        }

        private async Task LoadStaffShiftsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                StaffShifts = await StaffShiftService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading staff shifts: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/staff-shift/details/{id}");
        }
    }
}



