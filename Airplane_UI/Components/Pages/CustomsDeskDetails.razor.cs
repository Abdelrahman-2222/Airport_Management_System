using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class CustomsDeskDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetCustomsDeskDto? deskDetails;

        private UpdateCustomsDeskDto editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                deskDetails = await CustomsDeskService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customs desk details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (deskDetails != null)
            {
                editModel = new UpdateCustomsDeskDto
                {
                    DeskNumber = deskDetails.DeskNumber,
                    Status = deskDetails.Status
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
                var updatedDesk = await CustomsDeskService.UpdateAsync(id, editModel);

                if (updatedDesk != null)
                {
                    deskDetails = updatedDesk;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating customs desk: {ex.Message}");
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
                await CustomsDeskService.DeleteAsync(id);
                Navigation.NavigateTo("/customs-desk");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customs desk: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}



