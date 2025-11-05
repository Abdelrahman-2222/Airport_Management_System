using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class RunwayScheduleService : IRunwayScheduleService
    {
        private readonly AirplaneManagementSystemContext _context;
        public RunwayScheduleService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<IList<GetRunwayScheduleDTO>> GetAllAsync()
        {
            var runwaySchedules = await _context.RunwaySchedules.Select(rs => new GetRunwayScheduleDTO
            {
                Id = rs.Id,
                ScheduledTime = rs.ScheduledTime,
                Type = rs.Type.ToString()
            }).ToListAsync();
            return runwaySchedules;
        }
        public async Task<IList<GetAllDetailsRunwayScheduleDTO>> GetDetailsAsync()
        {
            var runwaySchedules = await _context.RunwaySchedules.Select(rs => new GetAllDetailsRunwayScheduleDTO
            {
                Id = rs.Id,
                ScheduledTime = rs.ScheduledTime,
                Type = rs.Type.ToString(),
                FlightNumber = rs.Flight.FlightNumber,
                RunwayName = rs.Runway.Name
            }).ToListAsync();
            return runwaySchedules;
        }
        public async Task<GetRunwayScheduleDTO> GetByIdAsync(int runwayScheduleId)
        {
            if(runwayScheduleId <= 0) return null;
            var runwaySchedule = await _context.RunwaySchedules
                .Where(rs => rs.Id == runwayScheduleId)
                .Select(rs => new GetRunwayScheduleDTO
                {
                    Id = rs.Id,
                    ScheduledTime = rs.ScheduledTime,
                    Type = rs.Type.ToString()
                }).SingleOrDefaultAsync();
            return runwaySchedule;
        }
        public async Task<GetAllDetailsRunwayScheduleDTO> CreateAsync(CreateAndUpdateRunwayScheduleDTO runwayScheduleDto)
        {
            var runwaySchedule = new RunwaySchedule
            {
                ScheduledTime = runwayScheduleDto.ScheduledTime,
                Type = runwayScheduleDto.Type,
                FlightId = runwayScheduleDto.FlightId,
                RunwayId = runwayScheduleDto.RunwayId
            };

            await _context.RunwaySchedules.AddAsync(runwaySchedule);
            await _context.SaveChangesAsync();

            var result = await _context.RunwaySchedules.Where(rs => rs.Id == runwaySchedule.Id).Select(rs => new GetAllDetailsRunwayScheduleDTO
            {
                Id = rs.Id,
                ScheduledTime = rs.ScheduledTime,
                Type = rs.Type.ToString(),
                FlightNumber = rs.Flight.FlightNumber,
                RunwayName = rs.Runway.Name
            }).SingleOrDefaultAsync();

            return result;
        }
        public async Task<GetRunwayScheduleDTO> UpdateAsync(int runwayScheduleId, CreateAndUpdateRunwayScheduleDTO runwayScheduleDto)
        {
            var runwaySchedule = await _context.RunwaySchedules.FindAsync(runwayScheduleId);
            if (runwaySchedule == null) return null; 
            runwaySchedule.ScheduledTime = runwayScheduleDto.ScheduledTime;
            runwaySchedule.Type = runwayScheduleDto.Type;
            runwaySchedule.FlightId = runwayScheduleDto.FlightId;
            runwaySchedule.RunwayId = runwayScheduleDto.RunwayId;
            await _context.SaveChangesAsync();
            return new GetRunwayScheduleDTO
            {
                Id = runwaySchedule.Id,
                ScheduledTime = runwaySchedule.ScheduledTime,
                Type = runwaySchedule.Type.ToString()
            };
        }
        public async Task<string> DeleteAsync(int runwayScheduleId)
        {
            if(runwayScheduleId <= 0) return null;
            var runwaySchedule = await _context.RunwaySchedules.FindAsync(runwayScheduleId);
            if (runwaySchedule == null) return null;
            _context.RunwaySchedules.Remove(runwaySchedule);
            await _context.SaveChangesAsync();
            return $"Runway Schedule with ID {runwayScheduleId} deleted successfully.";
        }
    }
}
