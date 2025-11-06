using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class StaffShiftDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetStaffShiftDto? shiftDetails;

        private UpdateStaffShiftDto editModel = new();

        private DateTime startTime;
        private DateTime endTime;

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                shiftDetails = await StaffShiftService.GetByIdAsync(id);
                if (shiftDetails != null)
                {
                    startTime = shiftDetails.StartTime;
                    endTime = shiftDetails.EndTime;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading staff shift details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task StartEdit()
        {
            if (shiftDetails != null)
            {
                editModel = new UpdateStaffShiftDto
                {
                    AssignedCheckpointID = shiftDetails.AssignedCheckpointID,
                    AssignedDeskID = shiftDetails.AssignedDeskID,
                    StartTime = shiftDetails.StartTime,
                    EndTime = shiftDetails.EndTime
                };
                startTime = shiftDetails.StartTime;
                endTime = shiftDetails.EndTime;
                isEditing = true;
                await InvokeAsync(StateHasChanged);
            }
        }

        private async Task CancelEdit()
        {
            isEditing = false;
            editModel = new();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnStartTimeChanged(DateTime value)
        {
            startTime = value;
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnEndTimeChanged(DateTime value)
        {
            endTime = value;
            await InvokeAsync(StateHasChanged);
        }

        private async Task SaveAsync()
        {
            if (editModel == null) return;

            isSaving = true;

            try
            {
                editModel.StartTime = startTime;
                editModel.EndTime = endTime;

                var updatedShift = await StaffShiftService.UpdateAsync(id, editModel);

                if (updatedShift != null)
                {
                    shiftDetails = updatedShift;
                    startTime = updatedShift.StartTime;
                    endTime = updatedShift.EndTime;
                }

                isEditing = false;
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating staff shift: {ex.Message}");
            }
            finally
            {
                isSaving = false;
            }
        }

        private void ShowDeleteConfirmation()
        {
            showDeleteConfirmation = true;
        }

        private void CancelDelete()
        {
            showDeleteConfirmation = false;
        }

        private async Task DeleteAsync()
        {
            isDeleting = true;
            try
            {
                await StaffShiftService.DeleteAsync(id);
                Navigation.NavigateTo("/staff-shift");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting staff shift: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}

