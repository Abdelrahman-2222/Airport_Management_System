using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Airplane_UI.Services.AirlineCore;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class AircraftDetails
    {
        [Parameter]
        public int Id { get; set; }

        private GetAircraftDTO? aircraftDetails;

        private GetAircraftDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                aircraftDetails = await AircraftService.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading aircraft details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (aircraftDetails != null)
            {
                editModel = new GetAircraftDTO
                {
                    Id = aircraftDetails.Id,
                    TailNumber = aircraftDetails.TailNumber,
                    Model = aircraftDetails.Model,
                    AirlineId = aircraftDetails.AirlineId,
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
                var updateDto = new CreateAndUpdateAircraftDTO
                {
                    TailNumber = editModel.TailNumber,
                    Model = editModel.Model,
                };

                var updatedAircraft = await AircraftService.UpdateAsync(Id, updateDto);

                if (updatedAircraft != null)
                {
                    aircraftDetails = updatedAircraft;
                }
                else
                {
                    aircraftDetails = editModel;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating aircraft: {ex.Message}");
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
                await AircraftService.DeleteAsync(Id);
                Navigation.NavigateTo("/aircraft");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting aircraft: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
