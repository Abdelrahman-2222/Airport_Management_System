using Airplane_UI.DTOs.SecurityGates.StaffShift;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines the contract for managing staff shift-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting staff shift data.
    /// </summary>
    public interface IStaffShiftService
    {
        /// <summary>
        /// Retrieves all staff shifts from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetStaffShiftDto objects.
        /// </returns>
        Task<List<GetStaffShiftDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific staff shift by its unique identifier.
        /// </summary>
        /// <param name="staffShiftId">The unique identifier of the staff shift to retrieve.</param>
        /// <returns>
        /// The task result contains the GetStaffShiftDto if found; otherwise, null.
        /// </returns>
        Task<GetStaffShiftDto> GetByIdAsync(int staffShiftId);

        /// <summary>
        /// Creates a new staff shift record in the system.
        /// </summary>
        /// <param name="createDto">The DTO containing details of the staff shift to create.</param>
        /// <returns>
        /// The task result contains the created GetStaffShiftDto object.
        /// </returns>
        Task<GetStaffShiftDto> CreateAsync(CreateStaffShiftDto createDto);

        /// <summary>
        /// Updates an existing staff shift record identified by its unique identifier.
        /// </summary>
        /// <param name="staffShiftId">The unique identifier of the staff shift to update.</param>
        /// <param name="updateDto">The DTO containing updated staff shift details.</param>
        /// <returns>
        /// The task result contains the updated GetStaffShiftDto object.
        /// </returns>
        Task<GetStaffShiftDto> UpdateAsync(int staffShiftId, UpdateStaffShiftDto updateDto);

        /// <summary>
        /// Deletes an existing staff shift record from the system.
        /// </summary>
        /// <param name="staffShiftId">The unique identifier of the staff shift to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int staffShiftId);
    }
}