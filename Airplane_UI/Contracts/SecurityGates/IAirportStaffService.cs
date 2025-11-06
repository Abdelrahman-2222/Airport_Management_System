using Airplane_UI.DTOs.SecurityGates.AirportStaff;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines operations for managing Airport Staff members in the airport system.
    /// </summary>
    public interface IAirportStaffService
    {
        /// <summary>
        /// Retrieves all airport staff members available in the system.
        /// </summary>
        /// <returns>A list of all existing airport staff members.</returns>
        Task<List<GetAirportStaffDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific airport staff member by their unique identifier.
        /// </summary>
        /// <param name="airportStaffId">The unique identifier of the staff member.</param>
        /// <returns>The corresponding staff member if found; otherwise, null.</returns>
        Task<GetAirportStaffDto> GetByIdAsync(int airportStaffId);

        /// <summary>
        /// Creates a new airport staff member and adds them to the system.
        /// </summary>
        /// <param name="dto">The data required to create the new staff member.</param>
        /// <returns>The created staff member with its generated ID.</returns>
        Task<GetAirportStaffDto> CreateAsync(CreateAirportStaffDto dto);

        /// <summary>
        /// Updates the information of an existing airport staff member.
        /// </summary>
        /// <param name="airportStaffId">The unique identifier of the staff member to update.</param>
        /// <param name="dto">The updated data for the staff member.</param>
        /// <returns>The updated staff member after modification.</returns>
        Task<GetAirportStaffDto> UpdateAsync(int airportStaffId, UpdateAirportStaffDto dto);

        /// <summary>
        /// Permanently deletes a specific airport staff member from the system.
        /// </summary>
        /// <param name="airportStaffId">The unique identifier of the staff member to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int airportStaffId);
    }
}
