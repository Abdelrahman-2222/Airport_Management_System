using Airplane_UI.DTOs.SecurityGates.CustomsDesk;

namespace Airplane_UI.Contracts.SecurityGates
{
    /// <summary>
    /// Defines a contract for managing customs desks in airport terminals.
    /// </summary>
    public interface ICustomsDeskService
    {
        /// <summary>
        /// Retrieves all customs desks across all terminals.
        /// </summary>
        /// <returns>A collection of customs desk DTOs.</returns>
        Task<List<GetCustomsDeskDto>> GetAllAsync();

        /// <summary>
        /// Retrieves detailed information about a customs desk including assigned staff and shift details.
        /// </summary>
        /// <param name="id">The unique ID of the customs desk.</param>
        /// <returns>A detailed customs desk DTO containing staff shift assignments.</returns>
        Task<GetCustomsDeskDetailsDto?> GetDetailsAsync(int id);

        /// <summary>
        /// Retrieves a customs desk by its unique identifier.
        /// </summary>
        /// <param name="id">The unique ID of the customs desk.</param>
        /// <returns>A customs desk DTO if found; otherwise, null.</returns>
        Task<GetCustomsDeskDto?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all customs desks located in a specific terminal.
        /// </summary>
        /// <param name="terminalId">The ID of the terminal.</param>
        /// <returns>A collection of customs desk DTOs belonging to the specified terminal.</returns>
        Task<List<GetCustomsDeskDto>> GetByTerminalAsync(int terminalId);

        /// <summary>
        /// Retrieves all customs desks with a specific operational status.
        /// </summary>
        /// <param name="status">The operational status to filter desks by (e.g., Active, Closed).</param>
        /// <returns>A collection of customs desk DTOs matching the specified status.</returns>
        Task<List<GetCustomsDeskDto>> GetByStatusAsync(string status);

        /// <summary>
        /// Creates a new customs desk and saves it to the database.
        /// </summary>
        /// <param name="createDto">The DTO containing the data for the new customs desk.</param>
        /// <returns>The created customs desk DTO.</returns>
        Task<GetCustomsDeskDto?> CreateAsync(CreateCustomsDeskDto createDto);

        /// <summary>
        /// Updates an existing customs desk with new information.
        /// </summary>
        /// <param name="id">The ID of the customs desk to update.</param>
        /// <param name="updateDto">The DTO containing updated desk data.</param>
        /// <returns>The updated customs desk DTO.</returns>
        Task<GetCustomsDeskDto?> UpdateAsync(int id, UpdateCustomsDeskDto updateDto);

        /// <summary>
        /// Permanently deletes a customs desk from the database.
        /// </summary>
        /// <param name="id">The ID of the customs desk to delete.</param>
        Task<string> DeleteAsync(int id);

        /// <summary>
        /// Updates the operational status of an existing customs desk.
        /// </summary>
        /// <param name="id">The ID of the customs desk.</param>
        /// <param name="status">The new operational status to assign.</param>
        Task UpdateStatusAsync(int id, string status);
    }
}
