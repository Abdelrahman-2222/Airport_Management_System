using Airplane_UI.DTOs.GateAssignments.GateDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface IGateService
    {
        // CRUD operations for Gate entity
        // GETALL
        Task<IList<GetGateDTO>> GetAllAsync();
        // GET All Details
        Task<IList<GetAllDetailsGateDTO>> GetDetailsAsync();
        // GET by Id
        Task<GetGateDTO> GetByIdAsync(int gateId);
        // CREATE
        Task<GetAllDetailsGateDTO> CreateAsync(CreateAndUpdateGateDTO gateDto);
        // UPDATE
        Task<GetGateDTO> UpdateAsync(int gateId, CreateAndUpdateGateDTO gateDto);
        // DELETE
        Task<string> DeleteAsync(int gateId);
    }
}
