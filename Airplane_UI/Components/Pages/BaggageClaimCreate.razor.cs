using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Services.LuggageMaintnance;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airplane_UI.Components.Pages;

public partial class BaggageClaimCreate
{
    private CreateAndUpdateBaggageClaimDto baggageClaimModel = new();

    private bool isSaving = false;
    private string errorMessage = string.Empty;

    private async Task HandleCreateAsync()
    {
        isSaving = true;
        errorMessage = string.Empty;

        try
        {
            await BaggageClaimService.CreateAsync(baggageClaimModel);

            Navigation.NavigateTo("/baggagcelaim");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating baggagcelaim: {ex.Message}");

            errorMessage = "An error occurred while creating the baggagcelaim. Please try again.";
        }
        finally
        {
            isSaving = false;
        }
    }

    private void GoBack()
    {
        Navigation.NavigateTo("/baggagcelaim");
    }
}
