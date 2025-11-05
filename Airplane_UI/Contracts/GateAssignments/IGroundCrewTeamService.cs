
using Airplane_UI.DTOs.GateAssignments.GroundCrewTeamDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface IGroundCrewTeamService
    {
        // CRUD operations for GateAssignment entity
        // GETALL
        Task<IList<GetGroundCrewTeamDTO>> GetAllAsync();
        // GET by Id
        Task<GetGroundCrewTeamDTO> GetByIdAsync(int groundCrewTeamId);
        // CREATE
        Task<GetGroundCrewTeamDTO> CreateAsync(CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto);
        // UPDATE
        Task<GetGroundCrewTeamDTO> UpdateAsync(int groundCrewTeamId, CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto);
        // DELETE
        Task<string> DeleteAsync(int groundCrewTeamId);
    }
}
