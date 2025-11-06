using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class StaffShiftCreate
    {
        [Inject]
        private IAirportStaffService AirportStaffService { get; set; }

        [Inject]
        private ISecurityCheckpointService SecurityCheckpointService { get; set; }

        [Inject]
        private ICustomsDeskService CustomsDeskService { get; set; }

        private CreateStaffShiftDto shiftModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;
        private IList<GetAirportStaffDto> staffOptions = new List<GetAirportStaffDto>();
        private IList<GetSecurityCheckpointDto> checkpointOptions = new List<GetSecurityCheckpointDto>();
        private IList<GetCustomsDeskDto> customsDeskOptions = new List<GetCustomsDeskDto>();
        private string staffLoadError = string.Empty;
        private string checkpointLoadError = string.Empty;
        private string customsDeskLoadError = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                staffOptions = await AirportStaffService.GetAllAsync();
            }
            catch (Exception ex)
            {
                staffLoadError = $"Failed to load staff: {ex.Message}";
            }

            try
            {
                checkpointOptions = await SecurityCheckpointService.GetAllAsync();
            }
            catch (Exception ex)
            {
                checkpointLoadError = $"Failed to load checkpoints: {ex.Message}";
            }

            try
            {
                customsDeskOptions = await CustomsDeskService.GetAllAsync();
            }
            catch (Exception ex)
            {
                customsDeskLoadError = $"Failed to load customs desks: {ex.Message}";
            }
        }

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



