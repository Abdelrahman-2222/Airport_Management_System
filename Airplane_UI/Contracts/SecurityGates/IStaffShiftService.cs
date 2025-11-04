using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.DTOs.SecurityGates.StaffShift;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines basic CRUD operations for managing staff shifts.
    /// </summary>
        public interface IStaffShiftService
        {
            /// <summary>
            /// Retrieves all staff shifts.
            /// </summary>
            /// <returns>A list of all shifts.</returns>
            Task<List<GetStaffShiftDto>> GetAllAsync();

            /// <summary>
            /// Retrieves a specific staff shift by ID.
            /// </summary>
            /// <param name="id">The unique ID of the shift.</param>
            /// <returns>The corresponding shift if found.</returns>
            Task<GetStaffShiftDto> GetByIdAsync(int id);

            /// <summary>
            /// Creates a new staff shift.
            /// </summary>
            /// <param name="createDto">The data to create the shift.</param>
            /// <returns>The created shift.</returns>
            Task<GetStaffShiftDto> CreateAsync(CreateStaffShiftDto createDto);

            /// <summary>
            /// Updates an existing staff shift.
            /// </summary>
            /// <param name="id">The ID of the shift to update.</param>
            /// <param name="updateDto">The updated data.</param>
            /// <returns>The updated shift.</returns>
            Task<GetStaffShiftDto> UpdateAsync(int id, UpdateStaffShiftDto updateDto);

            /// <summary>
            /// Deletes a staff shift.
            /// </summary>
            /// <param name="id">The ID of the shift to delete.</param>
            /// <returns>A task representing the asynchronous operation.</returns>
            Task<string> DeleteAsync(int id);
        }
}