
using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;

namespace Airplane_UI.Contracts.GateAssignments
{
    public interface IRunwayScheduleService
    {
        // CRUD operations for RunwaySchedule entity
        // GETALL
        Task<IList<GetRunwayScheduleDTO>> GetAllAsync();
        // GET All Details
        Task<IList<GetAllDetailsRunwayScheduleDTO>> GetDetailsAsync();
        // GET by Id
        Task<GetRunwayScheduleDTO> GetByIdAsync(int runwayScheduleId);
        // CREATE
        Task<GetAllDetailsRunwayScheduleDTO> CreateAsync(CreateAndUpdateRunwayScheduleDTO runwayScheduleDto);
        // UPDATE
        Task<GetRunwayScheduleDTO> UpdateAsync(int runwayScheduleId, CreateAndUpdateRunwayScheduleDTO runwayScheduleDto);
        // DELETE
        Task<string> DeleteAsync(int runwayScheduleId);
    }
}
