using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class AirlineDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetAirlineDTO? airlineDetails;

        // This model will be bound to the inputs when editing
        private GetAirlineDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                airlineDetails = await AirlineService.GetByIdAsync(id);
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
            if (airlineDetails != null)
            {
                // Clone the details into the edit model to avoid changing the original data
                editModel = new GetAirlineDTO
                {
                    Id = airlineDetails.Id,
                    Name = airlineDetails.Name,
                    IATA_Code = airlineDetails.IATA_Code
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
                var updateDto = new CreateAndUpdateAirlineDTO
                {
                    Name = editModel.Name,
                    IATA_Code = editModel.IATA_Code
                };

                // 2. Call the service with the populated DTO
                var updatedAirline = await AirlineService.UpdateAsync(id, updateDto);

                // 3. Update the main display object with the confirmed data from the server
                if (updatedAirline != null)
                {
                    airlineDetails = updatedAirline;
                }
                else
                {
                    airlineDetails = editModel;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating airline: {ex.Message}");
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
                await AirlineService.DeleteAsync(id);
                Navigation.NavigateTo("/airlines"); // Navigate back to airlines list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting airline: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
