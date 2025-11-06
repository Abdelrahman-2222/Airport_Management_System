using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;

namespace Airplane_UI.Components.Pages;

public partial class BaggageClaim
{
    private IList<GetBaggageClaimDto> baggageClaims = new List<GetBaggageClaimDto>();
    private bool _loading = false;
    private string _errorMessage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadBaggageClaimsAsync();
    }

    private async Task LoadBaggageClaimsAsync()
    {
        try
        {
            _loading = true;
            _errorMessage = string.Empty;
            baggageClaims = await BaggageClaimService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _errorMessage = $"Error loading baggage claim: {ex.Message}";
        }
        finally
        {
            _loading = false;
        }
    }
    private void NavigateToDetails(int baggagcelaimId)
    {
        Navigation.NavigateTo($"/baggagcelaim/details/{baggagcelaimId}");
    }
}
