using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;

namespace Airplane_UI.Components.Pages
{
    public partial class SecurityCheckpoint
    {
        private IList<GetSecurityCheckpointDto> SecurityCheckpoints = new List<GetSecurityCheckpointDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadSecurityCheckpointsAsync();
        }

        private async Task LoadSecurityCheckpointsAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                SecurityCheckpoints = await SecurityCheckpointService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading security checkpoints: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/security-checkpoint/details/{id}");
        }
    }
}

