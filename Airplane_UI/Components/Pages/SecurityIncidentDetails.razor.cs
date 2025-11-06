using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityIncidentDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetSecurityIncidentDto? incidentDetails;

        private UpdateSecurityIncidentDto editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                incidentDetails = await SecurityIncidentService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading security incident details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task StartEdit()
        {
            if (incidentDetails != null)
            {
                editModel = new UpdateSecurityIncidentDto
                {
                    AssignedStaffID = incidentDetails.AssignedStaffID,
                    ReportDetails = incidentDetails.ReportDetails,
                    Severity = incidentDetails.Severity
                };
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

        private async Task SaveAsync()
        {
            if (editModel == null) return;

            isSaving = true;

            try
            {
                var updatedIncident = await SecurityIncidentService.UpdateAsync(id, editModel);

                if (updatedIncident != null)
                {
                    incidentDetails = updatedIncident;
                }

                isEditing = false;
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating security incident: {ex.Message}");
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
                await SecurityIncidentService.DeleteAsync(id);
                Navigation.NavigateTo("/security-incident");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting security incident: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}

