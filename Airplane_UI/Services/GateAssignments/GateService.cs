using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;
using Airplane_UI.DTOs.GateAssignments.GateDTOs;
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class GateService
    {
        private readonly AirplaneManagementSystemContext _context;
        public GateService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        // Get All
        public async Task<List<GetGateDTO>> GetAllAsync()
        {
            var gates = await _context.Gates.Select(g => new GetGateDTO
            {
                Id = g.Id,
                GateNumber = g.GateNumber,
                Status = g.Status,
                TerminalName = g.Terminal.Name
            }).ToListAsync();
            return gates;
        }
        // Get Details
        public async Task<List<GetAllDetailsGateDTO>> GetDetailsAsync()
        {
            var gates = await _context.Gates.Select(g => new GetAllDetailsGateDTO
            {
                Id = g.Id,
                GateNumber = g.GateNumber,
                Status = g.Status,
                Terminal = new GetTerminalDTO
                {
                    Id = g.Terminal.Id,
                    Name = g.Terminal.Name,
                },
                GateAssignments = g.GateAssignments
                                    .Select(ga => new GetGateAssignmentDTO
                                    {
                                        Id = ga.Id,
                                        StartTime = ga.StartTime,
                                        EndTime = ga.EndTime
                                    }).ToList()
            }).ToListAsync();
            return gates;
        }
        // Get By Id
        public async Task<GetGateDTO> GetByIdAsync(int gateId)
        {
            var gate = await _context.Gates
                .Where(g => g.Id == gateId)
                .Select(g => new GetGateDTO
                {
                    Id = g.Id,
                    GateNumber = g.GateNumber,
                    Status = g.Status,
                    TerminalName = g.Terminal.Name
                }).SingleOrDefaultAsync();
            return gate;
        }
        // Create
        public async Task<GetAllDetailsGateDTO> CreateAsync(CreateAndUpdateGateDTO gateDto)
        {
            var gate = new Gate
            {
                GateNumber = gateDto.GateNumber,
                Status = gateDto.Status,
                TerminalId = gateDto.TerminalId
            };
            if(gate == null) return null;
            await _context.Gates.AddAsync(gate);
            await _context.SaveChangesAsync();
            var createdGate = await GetDetailsAsync();
            return createdGate.SingleOrDefault(g => g.Id == gate.Id);
        }
        // Update
        public async Task<GetGateDTO> UpdateAsync(int gateId, CreateAndUpdateGateDTO gateDto)
        {
            var gate = await _context.Gates.FindAsync(gateId);
            if (gate == null) return null;
            gate.GateNumber = gateDto.GateNumber;
            gate.Status = gateDto.Status;
            gate.TerminalId = gateDto.TerminalId;
            await _context.SaveChangesAsync();
            var updatedGate = await GetByIdAsync(gateId);
            return updatedGate;
        }
        // Delete
        public async Task<string> DeleteAsync(int gateId)
        {
            var gate = await _context.Gates.FindAsync(gateId);
            if (gate == null) return $"Gate with Id {gateId} not found.";
            _context.Gates.Remove(gate);
            await _context.SaveChangesAsync();
            return $"Gate with Id {gateId} has been deleted successfully.";
        }
    }
}
