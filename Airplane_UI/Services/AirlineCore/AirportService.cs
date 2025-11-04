using Airplane_API.Contracts.AirlineCore;
using Airplane_API.DTOs.AirlineCore.AirportDTOs;
using Airplane_UI.Data;
using Airplane_UI.Entities.AirlineCore;
using Airplane_UI.Mapper.AirlineCore;
using Microsoft.EntityFrameworkCore;

namespace Airplane_UI.Services.AirlineCore
{
    public class AirportService : IAirportService
    {
        private readonly AirplaneManagementSystemContext _context;

        public AirportService(AirplaneManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<IList<GetAirportDTO>> GetAllAsync()
        {
            var airports = await _context.Airports.Select(a=>a.ToDto()).ToListAsync();
            return airports;
        }

        public async Task<GetAirportDTO> GetyByIdAsync(int id)
        {
            var airport = await _context.Airports.Where(a => a.Id == id).Select(a => a.ToDto()).SingleOrDefaultAsync();

            if (airport == null) return null;
            return airport;
        }
        public async Task<GetAirportDTO> CreateAsync(CreateAndUpdateAirportDTO dto)
        {
            var airport = dto.ToEntity();

            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return airport.ToDto();
        }

        public async Task<GetAirportDTO> UpdateAsync(int id, CreateAndUpdateAirportDTO dto)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null) return null;

            dto.ToEntity();

            _context.Airports.Update(airport);
            await _context.SaveChangesAsync();
            return airport.ToDto();
        }

        public async Task<string> DeleteAsync(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null) return null;

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return $"Airport with ID {id} deleted successfully.";
        }
    }
}
