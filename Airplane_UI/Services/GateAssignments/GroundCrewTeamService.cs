using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Data;
using Airplane_UI.DTOs.GateAssignments.GroundCrewTeamDTOs;
using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.GateAssignments
{
    public class GroundCrewTeamService : IGroundCrewTeamService
    {
        private readonly AirplaneManagementSystemContext _context;

        public GroundCrewTeamService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<IList<GetGroundCrewTeamDTO>> GetAllAsync()
        {
            var groundCrewTeams = await _context.GroundCrewTeams.Select(gct => new GetGroundCrewTeamDTO
            {
                Id = gct.Id,
                Name = gct.Name
            }).ToListAsync();
            return groundCrewTeams;
        }
        public async Task<GetGroundCrewTeamDTO> GetByIdAsync(int groundCrewTeamId)
        {
            if (groundCrewTeamId <= 0) return null;

            var groundCrewTeam = await _context.GroundCrewTeams
                .Where(gct => gct.Id == groundCrewTeamId)
                .Select(gct => new GetGroundCrewTeamDTO
                {
                    Id = gct.Id,
                    Name = gct.Name
                }).SingleOrDefaultAsync();

            return groundCrewTeam;
        }
        public async Task<GetGroundCrewTeamDTO> CreateAsync(CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto)
        {
            var groundCrewTeam = new GroundCrewTeam
            {
                Name = groundCrewTeamDto.Name
            };
            await _context.GroundCrewTeams.AddAsync(groundCrewTeam);
            await _context.SaveChangesAsync();
            return new GetGroundCrewTeamDTO
            {
                Id = groundCrewTeam.Id,
                Name = groundCrewTeam.Name
            };
        }
        public async Task<GetGroundCrewTeamDTO> UpdateAsync(int groundCrewTeamId, CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto)
        {
            var groundCrewTeam = await _context.GroundCrewTeams.FindAsync(groundCrewTeamId);
            if (groundCrewTeam == null)
            {
                return null;
            }
            groundCrewTeam.Name = groundCrewTeamDto.Name;
            await _context.SaveChangesAsync();
            return new GetGroundCrewTeamDTO
            {
                Id = groundCrewTeam.Id,
                Name = groundCrewTeam.Name
            };
        }
        public async Task<string> DeleteAsync(int groundCrewTeamId)
        {
            var groundCrewTeam = await _context.GroundCrewTeams.FindAsync(groundCrewTeamId);
            if (groundCrewTeam == null)
            {
                return "Ground crew team not found";
            }
            _context.GroundCrewTeams.Remove(groundCrewTeam);
            await _context.SaveChangesAsync();
            return "Ground crew team deleted successfully";
        }
    }
}
