using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityCheckpointDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetSecurityCheckpointDto? checkpointDetails;

        private UpdateSecurityCheckpointDto editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                checkpointDetails = await SecurityCheckpointService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading security checkpoint details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (checkpointDetails != null)
            {
                editModel = new UpdateSecurityCheckpointDto
                {
                    Name = checkpointDetails.Name,
                    Status = checkpointDetails.Status
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
                var updatedCheckpoint = await SecurityCheckpointService.UpdateAsync(id, editModel);

                if (updatedCheckpoint != null)
                {
                    checkpointDetails = updatedCheckpoint;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating security checkpoint: {ex.Message}");
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
                await SecurityCheckpointService.DeleteAsync(id);
                Navigation.NavigateTo("/security-checkpoint");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting security checkpoint: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}

