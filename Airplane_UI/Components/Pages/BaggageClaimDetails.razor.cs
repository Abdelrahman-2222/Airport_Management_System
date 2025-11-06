using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Enums;
using Airplane_UI.Services.AirlineCore;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages;

public partial class BaggageClaimDetails
{
    [Parameter]
    public int id { get; set; }

    private GetBaggageClaimDto? baggageClaimDetails;

    private GetBaggageClaimDto editModel = new();

    private bool isLoading = true;
    private bool isEditing = false;
    private bool isSaving = false;
    private bool showDeleteConfirmation = false;
    private bool isDeleting = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            baggageClaimDetails = await BaggageClaimService.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading baggageClaim Details: {ex.Message}");
        }
        finally
        {
            isLoading = false;
        }
    }

    private void StartEdit()
    {
        if (baggageClaimDetails != null)
        {
            editModel = new GetBaggageClaimDto
            {
                Id = baggageClaimDetails.Id,
                CarouselNumber = baggageClaimDetails.CarouselNumber,
                Status = baggageClaimDetails.Status,
                TerminalName = baggageClaimDetails.TerminalName,
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
            var updateDto = new CreateAndUpdateBaggageClaimDto
            {
                CarouselNumber = editModel.CarouselNumber,
                Status = Enum.Parse<BaggageClaimStatus>(editModel.Status),
                //TerminalId = editModel.TerminalName
            };

            var updatedAirline = await BaggageClaimService.UpdateAsync(id, updateDto);

            if (updatedAirline != null)
            {
                baggageClaimDetails = updatedAirline;
            }
            else
            {
                baggageClaimDetails = editModel;
            }

            isEditing = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating BaggageClaim: {ex.Message}");
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
            await BaggageClaimService.DeleteAsync(id);
            Navigation.NavigateTo("/baggagcelaim"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting baggagcelaim: {ex.Message}");
        }
        finally
        {
            isDeleting = false;
            showDeleteConfirmation = false;
        }
    }
}
