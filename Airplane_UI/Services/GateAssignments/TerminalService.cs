using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.GateDTOs;
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class TerminalService : ITerminalService
    {
        private readonly AirplaneManagementSystemContext _context;

        public TerminalService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IList<GetTerminalDTO>> GetAllAsync()
        {
            var terminals = await _context.Terminals.Select(t => new GetTerminalDTO
            {
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
            return terminals;
        }

        public async Task<GetTerminalDTO> GetByIdAsync(int terminalId)
        {
            if (terminalId <= 0) return null;
            var terminal = await _context.Terminals
                .Where(t => t.Id == terminalId)
                .Select(t => new GetTerminalDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .SingleOrDefaultAsync();
            return terminal;
        }

        public async Task<IList<GetAllDetailsTerminalDTO>> GetDetailsAsync()
        {
            var terminals = await _context.Terminals
                .Select(t => new GetAllDetailsTerminalDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    Gates = t.Gates.Select(g => new GetGateDTO
                    {
                        Id = g.Id,
                        GateNumber = g.GateNumber,
                        Status = g.Status.ToString(),
                        TerminalName = g.Terminal.Name
                    }).ToList(),
                    BaggageClaims = t.BaggageClaims
                        .Select(bc => new GetBaggageClaimDto
                        {
                            CarouselNumber = bc.CarouselNumber,
                            Status = bc.Status.ToString(),
                            TerminalName = t.Name
                        }).ToList(),
                    CustomsDesks = t.CustomsDesks.Select(cd => new GetCustomsDeskDto
                    {
                        Id = cd.Id,
                        DeskNumber = cd.DeskNumber
                    }).ToList(),
                    SecurityCheckpoints = t.SecurityCheckpoints.Select(sc => new GetSecurityCheckpointDto
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        Status = sc.Status,
                    }).ToList()
                })
                .ToListAsync();
            return terminals;
        }
        public async Task<GetTerminalDTO> CreateAsync(CreateAndUpdateTerminalDTO terminalDto)
        {
            var terminal = new Terminal
            {
                Name = terminalDto.Name
            };

            await _context.Terminals.AddAsync(terminal);
            await _context.SaveChangesAsync();

            var result = await _context.Terminals
                .Where(t => t.Id == terminal.Id)
                .Select(t => new GetTerminalDTO
                {
                    Id = t.Id,
                    Name = t.Name
                }).SingleOrDefaultAsync();

            return result;
        }
        public async Task<GetTerminalDTO> UpdateAsync(int terminalId, CreateAndUpdateTerminalDTO terminalDto)
        {
            var terminal = await _context.Terminals.FindAsync(terminalId);
            if (terminal == null) return null;
            terminal.Name = terminalDto.Name;
            await _context.SaveChangesAsync();
            return new GetTerminalDTO
            {
                Id = terminal.Id,
                Name = terminal.Name
            };
        }
        public async Task<string> DeleteAsync(int terminalId)
        {
            var terminal = await _context.Terminals.FindAsync(terminalId);
            if (terminal == null) return $"Terminal with Id {terminalId} not found.";
            _context.Terminals.Remove(terminal);
            await _context.SaveChangesAsync();
            return $"Terminal with Id {terminalId} deleted successfully.";
        }
    }
}
