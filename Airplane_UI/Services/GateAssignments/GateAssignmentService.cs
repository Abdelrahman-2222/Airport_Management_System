using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class GateAssignmentService : IGateAssignmentService
    {
        private readonly AirplaneManagementSystemContext _context;
        public GateAssignmentService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<IList<GetGateAssignmentDTO>> GetAllAsync()
        {
            var result = await _context.GateAssignments.Select(ga => new GetGateAssignmentDTO
            {
                Id = ga.Id,
                StartTime = ga.StartTime,
                EndTime = ga.EndTime
            }).ToListAsync();

            return result;
        }
        public async Task<IList<GetAllDetailsGateAssignmentDTO>> GetDetailsAsync()
        {
            var result = await _context.GateAssignments.Select(ga => new GetAllDetailsGateAssignmentDTO
            {
                Id = ga.Id,
                StartTime = ga.StartTime,
                EndTime = ga.EndTime,
                GateNumber = ga.Gate.GateNumber,
                TerminalName = ga.Gate.Terminal.Name,
                FlightNumber = ga.Flight.FlightNumber
            }).ToListAsync();
            return result;
        }
        public async Task<GetGateAssignmentDTO> GetByIdAsync(int gateAssignmentId)
        {
            var gateAssignment = await _context.GateAssignments
                .Where(ga => ga.Id == gateAssignmentId)
                .Select(ga => new GetGateAssignmentDTO
                {
                    Id = ga.Id,
                    StartTime = ga.StartTime,
                    EndTime = ga.EndTime
                }).SingleOrDefaultAsync();
            return gateAssignment;
        }
        public async Task<GetAllDetailsGateAssignmentDTO> CreateAsync(CreateAndUpdateGateAssignmentDTO gateAssignmentDto)
        {
            var newGateAssignment = new GateAssignment
            {
                FlightId = gateAssignmentDto.FlightId,
                GateId = gateAssignmentDto.GateId,
                StartTime = gateAssignmentDto.StartTime,
                EndTime = gateAssignmentDto.EndTime
            };
            await _context.GateAssignments.AddAsync(newGateAssignment);
            await _context.SaveChangesAsync();
            var result = await _context.GateAssignments
                .Where(ga => ga.Id == newGateAssignment.Id)
                .Select(ga => new GetAllDetailsGateAssignmentDTO
                {
                    Id = ga.Id,
                    StartTime = ga.StartTime,
                    EndTime = ga.EndTime,
                    GateNumber = ga.Gate.GateNumber,
                    TerminalName = ga.Gate.Terminal.Name,
                    FlightNumber = ga.Flight.FlightNumber
                }).SingleOrDefaultAsync();
            return result;
        }

        public async Task<GetGateAssignmentDTO> UpdateAsync(int gateAssignmentId, CreateAndUpdateGateAssignmentDTO gateAssignmentDto)
        {
            var existingGateAssignment = await _context.GateAssignments.FindAsync(gateAssignmentId);
            if (existingGateAssignment == null)
            {
                return null;
            }
            existingGateAssignment.FlightId = gateAssignmentDto.FlightId;
            existingGateAssignment.GateId = gateAssignmentDto.GateId;
            existingGateAssignment.StartTime = gateAssignmentDto.StartTime;
            existingGateAssignment.EndTime = gateAssignmentDto.EndTime;
            await _context.SaveChangesAsync();
            var result = await _context.GateAssignments
                .Where(ga => ga.Id == existingGateAssignment.Id)
                .Select(ga => new GetGateAssignmentDTO
                {
                    Id = ga.Id,
                    StartTime = ga.StartTime,
                    EndTime = ga.EndTime
                }).SingleOrDefaultAsync();
            return result;
        }

        public async Task<string> DeleteAsync(int gateAssignmentId)
        {
            var gateAssignment = await _context.GateAssignments.FindAsync(gateAssignmentId);
            if (gateAssignment == null) return $"Gate Assignment with Id {gateAssignmentId} not found.";
            _context.GateAssignments.Remove(gateAssignment);
            await _context.SaveChangesAsync();
            return $"Gate Assignment with Id {gateAssignmentId} deleted successfully.";
        }
    }
}
