using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class AircraftDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetAircraftDTO? aircraftDetails;

        // This model will be bound to the inputs when editing
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
                aircraftDetails = await AircraftService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airline details: {ex.Message}");
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
                // Clone the details into the edit model to avoid changing the original data
                editModel = new GetAircraftDTO
                {
                    Id = aircraftDetails.Id,
                    TailNumber = aircraftDetails.TailNumber,
                    Model = aircraftDetails.Model
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
                // 1. Create the DTO to send to the service
                var updateDto = new CreateAndUpdateAircraftDTO
                {
                    TailNumber = editModel.TailNumber,
                    Model = editModel.Model
                };

                // 2. Call the service with the populated DTO
                var updatedAircraft = await AircraftService.UpdateAsync(id, updateDto);

                // 3. Update the main display object with the confirmed data from the server
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
                await AircraftService.DeleteAsync(id);
                Navigation.NavigateTo("/aircrafts"); // Navigate back to aircrafts list
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
