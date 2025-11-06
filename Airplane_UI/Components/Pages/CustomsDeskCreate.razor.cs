using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class CustomsDeskCreate
    {
        [Inject]
        private ITerminalService TerminalService { get; set; }

        private CreateCustomsDeskDto deskModel = new();

        private bool isSaving = false;
        private string errorMessage = string.Empty;
        private IList<GetTerminalDTO> terminalOptions = new List<GetTerminalDTO>();
        private string terminalLoadError = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                terminalOptions = await TerminalService.GetAllAsync();
            }
            catch (Exception ex)
            {
                terminalLoadError = $"Failed to load terminals: {ex.Message}";
            }
        }

        private async Task HandleCreateAsync()
        {
            isSaving = true;
            errorMessage = string.Empty;

            try
            {
                await CustomsDeskService.CreateAsync(deskModel);
                Navigation.NavigateTo("/customs-desk");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating customs desk: {ex.Message}");
                errorMessage = "An error occurred while creating the customs desk. Please try again.";
            }
            finally
            {
                isSaving = false;
            }
        }

        private void GoBack()
        {
            Navigation.NavigateTo("/customs-desk");
        }
    }
}



