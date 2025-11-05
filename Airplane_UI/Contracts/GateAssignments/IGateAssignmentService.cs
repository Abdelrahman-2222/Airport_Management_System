using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface IGateAssignmentService
    {
        // CRUD operations for GateAssignment entity
        // GETALL
        Task<IList<GetGateAssignmentDTO>> GetAllAsync();
        // GET by Id
        Task<GetGateAssignmentDTO> GetByIdAsync(int gateAssignmentId);
        // CREATE
        Task<GetAllDetailsGateAssignmentDTO> CreateAsync(CreateAndUpdateGateAssignmentDTO gateAssignmentDto);
        // UPDATE
        Task<GetGateAssignmentDTO> UpdateAsync(int gateAssignmentId, CreateAndUpdateGateAssignmentDTO gateAssignmentDto);
        // DELETE
        Task<string> DeleteAsync(int gateAssignmentId);
    }
}
