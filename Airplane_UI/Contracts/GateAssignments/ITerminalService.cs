
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface ITerminalService
    {
        // CRUD operations for Gate entity
        // GETALL
        Task<IList<GetTerminalDTO>> GetAllAsync();
        // GET All Details
        Task<IList<GetAllDetailsTerminalDTO>> GetDetailsAsync();
        // GET by Id
        Task<GetTerminalDTO> GetByIdAsync(int terminalId);
        // CREATE
        Task<GetAllDetailsTerminalDTO> CreateAsync(CreateAndUpdateTerminalDTO terminalDto);
        // UPDATE
        Task<GetTerminalDTO> UpdateAsync(int terminalId, CreateAndUpdateTerminalDTO terminalDto);
        // DELETE
        Task<string> DeleteAsync(int terminalId);
    }
}
