using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    /// <summary>
    /// Defines the contract for managing terminal-related operations.
    /// Provides asynchronous methods for retrieving, creating, updating, and deleting terminal data.
    /// </summary>
    public interface ITerminalService
    {
        /// <summary>
        /// Retrieves all terminals from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetTerminalDTO objects.
        /// </returns>
        Task<IList<GetTerminalDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all terminals with their full details from the system.
        /// </summary>
        /// <returns>
        /// The task result contains a collection of GetAllDetailsTerminalDTO objects.
        /// </returns>
        Task<IList<GetAllDetailsTerminalDTO>> GetDetailsAsync();

        /// <summary>
        /// Retrieves a specific terminal by its unique identifier.
        /// </summary>
        /// <param name="terminalId">The unique identifier of the terminal to retrieve.</param>
        /// <returns>
        /// The task result contains the GetTerminalDTO if found; otherwise, null.
        /// </returns>
        Task<GetTerminalDTO> GetByIdAsync(int terminalId);

        /// <summary>
        /// Creates a new terminal record in the system.
        /// </summary>
        /// <param name="terminalDto">The DTO containing details of the terminal to create.</param>
        /// <returns>
        /// The task result contains the created GetTerminalDTO object.
        /// </returns>
        Task<GetTerminalDTO> CreateAsync(CreateAndUpdateTerminalDTO terminalDto);

        /// <summary>
        /// Updates an existing terminal record identified by its unique identifier.
        /// </summary>
        /// <param name="terminalId">The unique identifier of the terminal to update.</param>
        /// <param name="terminalDto">The DTO containing updated terminal details.</param>
        /// <returns>
        /// The task result contains the updated GetTerminalDTO object.
        /// </returns>
        Task<GetTerminalDTO> UpdateAsync(int terminalId, CreateAndUpdateTerminalDTO terminalDto);

        /// <summary>
        /// Deletes an existing terminal record from the system.
        /// </summary>
        /// <param name="terminalId">The unique identifier of the terminal to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a string indicating success or failure.
        /// </returns>
        Task<string> DeleteAsync(int terminalId);
    }
}