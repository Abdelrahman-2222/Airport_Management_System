using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class AirportStaffDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetAirportStaffDto? staffDetails;

        private UpdateAirportStaffDto editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                staffDetails = await AirportStaffService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airport staff details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (staffDetails != null)
            {
                editModel = new UpdateAirportStaffDto
                {
                    Name = staffDetails.Name,
                    Role = staffDetails.Role
                };
                isEditing = true;
            }
        }

        private void CancelEdit()
        {
            isEditing = false;
            editModel = new();
        }

        private async Task SaveAsync()
        {
            if (editModel == null) return;

            isSaving = true;

            try
            {
                var updatedStaff = await AirportStaffService.UpdateAsync(id, editModel);

                if (updatedStaff != null)
                {
                    staffDetails = updatedStaff;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating airport staff: {ex.Message}");
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
                await AirportStaffService.DeleteAsync(id);
                Navigation.NavigateTo("/airport-staff");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting airport staff: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}



