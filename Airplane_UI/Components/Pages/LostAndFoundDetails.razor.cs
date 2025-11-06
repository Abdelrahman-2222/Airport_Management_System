using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
using Airplane_UI.Enums;
using Microsoft.AspNetCore.Components;

namespace Airplane_UI.Components.Pages
{
    public partial class LostAndFoundDetails
    {
        [Parameter]
        public int id { get; set; }

        private GetLostAndFoundDTO? lostandfoundsDetails;

        private GetLostAndFoundDTO editModel = new();

        private bool isLoading = true;
        private bool isEditing = false;
        private bool isSaving = false;
        private bool showDeleteConfirmation = false;
        private bool isDeleting = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                lostandfoundsDetails = await LostAndFoundService.GetByIdAsync(id);
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
            if (lostandfoundsDetails != null)
            {
                editModel = new GetLostAndFoundDTO
                {
                    Id = lostandfoundsDetails.Id,
                    ItemDescription = lostandfoundsDetails.ItemDescription,
                    DateFound = lostandfoundsDetails.DateFound,
                    Status = lostandfoundsDetails.Status
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
                var updateDto = new CreateAndUpdateLostandFoundDTO
                {
                    DateFound = DateTime.Now,
                    ItemDescription = editModel.ItemDescription,
                    Status = Enum.Parse<LostAndFoundStatus>(editModel.Status)
                };

                var updatedAirline = await LostAndFoundService.UpdateAsync(id, updateDto);

                if (updatedAirline != null)
                {
                    lostandfoundsDetails = updatedAirline;
                }
                else
                {
                    lostandfoundsDetails = editModel;
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
                await LostAndFoundService.DeleteAsync(id);
                Navigation.NavigateTo("/lostandfound");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting lostandfound: {ex.Message}");
            }
            finally
            {
                isDeleting = false;
                showDeleteConfirmation = false;
            }
        }
    }
}
