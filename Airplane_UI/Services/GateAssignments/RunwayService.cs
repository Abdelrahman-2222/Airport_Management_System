using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.RunwayDTOs;
using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class RunwayService : IRunwayService
    {
        private readonly AirplaneManagementSystemContext _context;
        public RunwayService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<IList<GetRunwayDTO>> GetAllAsync()
        {
            var runways = await _context.Runways.Select(r => new GetRunwayDTO
            {
                Id = r.Id,
                Name = r.Name,
                Status = r.Status.ToString(),
            }).ToListAsync();
            return runways;
        }
        public async Task<IList<GetAllDetailsRunwayDTO>> GetDetailsAsync()
        {
            var runways = await _context.Runways.Select(r => new GetAllDetailsRunwayDTO
            {
                Id = r.Id,
                Name = r.Name,
                Status = r.Status.ToString(),
                RunwaySchedules = r.RunwaySchedules
                                    .Select(rs => new GetRunwayScheduleDTO
                                    {
                                        Id = rs.Id,
                                        ScheduledTime = rs.ScheduledTime,
                                        Type = rs.Type.ToString(),
                                    }).ToList()
            }).ToListAsync();
            return runways;
        }
        public async Task<GetRunwayDTO> GetByIdAsync(int runwayId)
        {
            var runway = await _context.Runways
                .Where(r => r.Id == runwayId)
                .Select(r => new GetRunwayDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Status = r.Status.ToString(),
                }).SingleOrDefaultAsync();
            return runway;
        }
        public async Task<GetAllDetailsRunwayDTO> CreateAsync(CreateAndUpdateRunwayDTO runwayDto)
        {
            var runway = new Runway
            {
                Name = runwayDto.Name,
                Status = runwayDto.Status
            };
            await _context.Runways.AddAsync(runway);
            await _context.SaveChangesAsync();
            return new GetAllDetailsRunwayDTO
            {
                Id = runway.Id,
                Name = runway.Name,
                Status = runway.Status.ToString(),
                RunwaySchedules = runway.RunwaySchedules
                                        .Select(rs => new GetRunwayScheduleDTO
                                        {
                                            Id = rs.Id,
                                            ScheduledTime = rs.ScheduledTime,
                                            Type = rs.Type.ToString(),
                                        }).ToList()
            };
        }
        public async Task<GetRunwayDTO> UpdateAsync(int runwayId, CreateAndUpdateRunwayDTO runwayDto)
        {
            var runway = await _context.Runways.FindAsync(runwayId);
            if (runway == null)
            {
                return null;
            }
            runway.Name = runwayDto.Name;
            runway.Status = runwayDto.Status;
            await _context.SaveChangesAsync();
            return new GetRunwayDTO
            {
                Id = runway.Id,
                Name = runway.Name,
                Status = runway.Status.ToString(),
            };
        }
        public async Task<string> DeleteAsync(int runwayId)
        {
            if(runwayId == 0) return "Invalid Runway ID.";
            var runway = await _context.Runways.FindAsync(runwayId);
            if (runway == null)
            {
                return null;
            }
            _context.Runways.Remove(runway);
            await _context.SaveChangesAsync();
            return $"Runway with ID {runwayId} deleted successfully.";
        }
    }
}
