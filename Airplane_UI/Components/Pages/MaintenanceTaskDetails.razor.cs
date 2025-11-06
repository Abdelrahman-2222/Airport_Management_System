using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class MaintenanceTaskDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetMaintenanceTaskDTO? maintenanceTaskDetails;

        private GetMaintenanceTaskDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                maintenanceTaskDetails = await MaintenanceTaskService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading MaintenanceTask details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (maintenanceTaskDetails != null)
            {
                editModel = new GetMaintenanceTaskDTO
                {
                    Id = maintenanceTaskDetails.Id,
                    Description = maintenanceTaskDetails.Description,
                    MaintenanceLogs = maintenanceTaskDetails.MaintenanceLogs,
                    Name = maintenanceTaskDetails.Name
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
                var updateDto = new CreateAndUpdateMaintenanceTaskDTO
                {
                    Description = editModel.Description,
                    Name = editModel.Name,
                };

                var updatedAircraft = await MaintenanceTaskService.UpdateAsync(id, updateDto);

                if (updatedAircraft != null)
                {
                    maintenanceTaskDetails = updatedAircraft;
                }
                else
                {
                    maintenanceTaskDetails = editModel;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating MaintenanceTask: {ex.Message}");
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
                await MaintenanceTaskService.DeleteAsync(id);
                Navigation.NavigateTo("/maintenancetask");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting MaintenanceTask: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
