using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class CateringFacilitiesDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetCateringFacilitiesDTO? facilitiesDetails;

        private GetCateringFacilitiesDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                facilitiesDetails = await FacilitiesService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading cateringfacilities details: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private void StartEdit()
        {
            if (facilitiesDetails != null)
            {
                editModel = new GetCateringFacilitiesDTO
                {
                    Id = facilitiesDetails.Id,
                    Name = facilitiesDetails.Name,
                    ContactInfo = facilitiesDetails.ContactInfo,
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
                var updateDto = new CreateAndUpdateCateringFacilitiesDTO
                {
                    Name = editModel.Name,
                    ContactInfo = editModel.ContactInfo,
                };

                var updatedAirline = await FacilitiesService.UpdateAsync(id, updateDto);

                if (updatedAirline != null)
                {
                    facilitiesDetails = updatedAirline;
                }
                else
                {
                    facilitiesDetails = editModel;
                }

                isEditing = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating cateringfacilities: {ex.Message}");
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
                await FacilitiesService.DeleteAsync(id);
                Navigation.NavigateTo("/cateringfacilities");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting cateringfacilities: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
