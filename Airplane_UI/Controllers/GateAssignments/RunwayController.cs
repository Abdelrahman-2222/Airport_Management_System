using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.RunwayDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunwayController : ControllerBase
    {
        private readonly IRunwayService _service;
        public RunwayController(IRunwayService service)
        {
            _service = service;
        }
        // GetAllRunways
        [HttpGet]
        public async Task<ActionResult<GetRunwayDTO>> GetAllRunways()
        {
            var runways = await _service.GetAllAsync();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(runways);
        }
        // GetRunwayDetails
        [HttpGet("getDetails")]
        public async Task<ActionResult<GetAllDetailsRunwayDTO>> GetRunwayDetails()
        {
            var runways = await _service.GetDetailsAsync();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(runways);
        }
        // GetRunwayById
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRunwayDTO>> GetRunwayById(int id)
        {
            var runway = await _service.GetByIdAsync(id);
            if (runway is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(runway);
        }
        // CreateRunway
        [HttpPost]
        public async Task<ActionResult<GetAllDetailsRunwayDTO>> CreateRunway([FromBody] CreateAndUpdateRunwayDTO createRunwayDTO)
        {
            var createdRunway = await _service.CreateAsync(createRunwayDTO);
            if (createdRunway is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return CreatedAtAction(nameof(GetRunwayById), new { id = createdRunway.Id }, createdRunway);
        }
        // UpdateRunway
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAllDetailsRunwayDTO>> UpdateRunway(int id, [FromBody] CreateAndUpdateRunwayDTO updateRunwayDTO)
        {
            if (updateRunwayDTO is null) return BadRequest(ModelState);
            var updatedRunway = await _service.UpdateAsync(id, updateRunwayDTO);
            if (updatedRunway is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(updatedRunway);
        }
        // DeleteRunway
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteRunway(int id)
        {
            var deleteResult = await _service.DeleteAsync(id);
            if (string.IsNullOrWhiteSpace(deleteResult)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(deleteResult);
        }
    }
}
