using Airplane_UI.DTOs.SecurityGates.CheckpointLog;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class CheckpointLogDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetCheckpointLogDto? logDetails;

        private UpdateCheckpointLogDto editModel = new();

        private int waitHours = 0;
        private int waitMinutes = 0;
        private int waitSeconds = 0;

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                logDetails = await CheckpointLogService.GetByIdAsync(id);
                if (logDetails != null)
                {
                    waitHours = logDetails.ReportedWaitTime.Hours;
                    waitMinutes = logDetails.ReportedWaitTime.Minutes;
                    waitSeconds = logDetails.ReportedWaitTime.Seconds;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading checkpoint log details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (logDetails != null)
            {
                editModel = new UpdateCheckpointLogDto
                {
                    ReportedWaitTime = logDetails.ReportedWaitTime
                };
                waitHours = logDetails.ReportedWaitTime.Hours;
                waitMinutes = logDetails.ReportedWaitTime.Minutes;
                waitSeconds = logDetails.ReportedWaitTime.Seconds;
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
            isSaving = true;

            try
            {
                editModel.ReportedWaitTime = new TimeSpan(waitHours, waitMinutes, waitSeconds);
                var updatedLog = await CheckpointLogService.UpdateAsync(id, editModel);

                if (updatedLog != null)
                {
                    logDetails = updatedLog;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating checkpoint log: {ex.Message}");
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
                await CheckpointLogService.DeleteAsync(id);
                Navigation.NavigateTo("/checkpoint-log");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting checkpoint log: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}

