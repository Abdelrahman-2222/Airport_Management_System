using Airplane_UI.DTOs.SecurityGates.CheckpointLog;

namespace Airplane_UI.Components.Pages
{
    public partial class CheckpointLog
    {
        private IList<GetCheckpointLogDto> CheckpointLogs = new List<GetCheckpointLogDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadCheckpointLogsAsync();
        }

        private async Task LoadCheckpointLogsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                CheckpointLogs = await CheckpointLogService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading checkpoint logs: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/checkpoint-log/details/{id}");
        }
    }
}



