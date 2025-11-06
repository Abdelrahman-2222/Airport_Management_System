using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
using Airplane_UI.Services.AirlineCore;

namespace Airplane_UI.Components.Pages
{
    public partial class LostAndFound
    {
        private IList<GetLostAndFoundDTO> LostandFound = new List<GetLostAndFoundDTO>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadLostandFoundAsync();
        }

        private async Task LoadLostandFoundAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                LostandFound = await LostAndFoundService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading LostandFound: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }
        private void NavigateToDetails(int lostandfoundId)
        {
            Navigation.NavigateTo($"/lostandfound/details/{lostandfoundId}");
        }
    }
}
