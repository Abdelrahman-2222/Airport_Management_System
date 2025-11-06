using Airplane_UI.DTOs.SecurityGates.StaffShift;

namespace Airplane_UI.Components.Pages
{
    public partial class StaffShiftCreate
    {
        private CreateStaffShiftDto shiftModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await StaffShiftService.CreateAsync(shiftModel);
                Navigation.NavigateTo("/staff-shift");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating staff shift: {ex.Message}");
                errorMessage = "An error occurred while creating the staff shift. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/staff-shift");
        }
    }
}



