
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceLogDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetMaintenanceLogDTO? maintenanceLogDetails;

        private GetMaintenanceLogDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                maintenanceLogDetails = await MaintenanceLogService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airline details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (maintenanceLogDetails != null)
            {
                editModel = new GetMaintenanceLogDTO
                {
                    Id = maintenanceLogDetails.Id,
                    Status = maintenanceLogDetails.Status,
                    Date = maintenanceLogDetails.Date,
                    Description = maintenanceLogDetails.Description,
                    Aircraft = maintenanceLogDetails.Aircraft,
                    MaintenanceTask = maintenanceLogDetails.MaintenanceTask
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
                var updateDto = new CreateAndUpdateMaintenanceLogDTO
                {
                    Description = editModel.Description,
                    Date = editModel.Date,
                    Status = editModel.Status,
                };

                var updatedAirline = await MaintenanceLogService.UpdateAsync(id, updateDto);

                if (updatedAirline != null)
                {
                    maintenanceLogDetails = updatedAirline;
                }
                else
                {
                    maintenanceLogDetails = editModel;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating airline: {ex.Message}");
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
                await MaintenanceLogService.DeleteAsync(id);
                Navigation.NavigateTo("/airlines");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting maintenanceLog: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
