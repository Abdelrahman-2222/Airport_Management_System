using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.GroundCrewTeamDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroundCrewTeamController : ControllerBase
    {
        private readonly IGroundCrewTeamService _service;
        public GroundCrewTeamController(IGroundCrewTeamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<GetGroundCrewTeamDTO>>> GetAllAsync()
        {
            var groundCrewTeams = await _service.GetAllAsync();
            return Ok(groundCrewTeams);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetGroundCrewTeamDTO>> GetByIdAsync(int id)
        {
            var groundCrewTeam = await _service.GetByIdAsync(id);
            if (groundCrewTeam == null)
            {
                return NotFound();
            }
            return Ok(groundCrewTeam);
        }
        [HttpPost]
        public async Task<ActionResult<GetGroundCrewTeamDTO>> CreateAsync(CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto)
        {
            var createdGroundCrewTeam = await _service.CreateAsync(groundCrewTeamDto);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdGroundCrewTeam.Id }, createdGroundCrewTeam);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<GetGroundCrewTeamDTO>> UpdateAsync(int Id, CreateAndUpdateGroundCrewTeamDTO groundCrewTeamDto)
        {
            var updatedGroundCrewTeam = await _service.UpdateAsync(Id, groundCrewTeamDto);
            if (updatedGroundCrewTeam == null)
            {
                return NotFound();
            }
            return Ok(updatedGroundCrewTeam);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<string>> DeleteAsync(int Id)
        {
            var result = await _service.DeleteAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
