using Airplane_UI.DTOs.SecurityGates.CustomsDesk;

namespace Airplane_UI.Components.Pages
{
    public partial class CustomsDesk
    {
        private IList<GetCustomsDeskDto> CustomsDesks = new List<GetCustomsDeskDto>();
        private bool _loading = false;
        private string _errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadCustomsDesksAsync();
        }

        private async Task LoadCustomsDesksAsync()
        {
            try
            {
                _loading = true;
                _errorMessage = string.Empty;
                CustomsDesks = await CustomsDeskService.GetAllAsync();
            }
            catch (Exception ex)
            {
                _errorMessage = $"Error loading customs desks: {ex.Message}";
            }
            finally
            {
                _loading = false;
            }
        }

        private void NavigateToDetails(int id)
        {
            Navigation.NavigateTo($"/customs-desk/details/{id}");
        }
    }
}



