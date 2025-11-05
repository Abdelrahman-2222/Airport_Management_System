
using Airplane_UI.DTOs.GateAssignments.RunwayDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface IRunwayService
    {
        // CRUD operations for Runway entity
        // GETALL
        Task<IList<GetRunwayDTO>> GetAllAsync();
        // GET All Details
        Task<IList<GetAllDetailsRunwayDTO>> GetDetailsAsync();
        // GET by Id
        Task<GetRunwayDTO> GetByIdAsync(int runwayId);
        // CREATE
        Task<GetAllDetailsRunwayDTO> CreateAsync(CreateAndUpdateRunwayDTO runwayDto);
        // UPDATE
        Task<GetRunwayDTO> UpdateAsync(int runwayId, CreateAndUpdateRunwayDTO runwayDto);
        // DELETE
        Task<string> DeleteAsync(int runwayId);
    }
}
