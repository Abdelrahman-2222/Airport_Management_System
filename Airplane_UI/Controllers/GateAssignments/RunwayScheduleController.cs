using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.RunwayScheduleDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunwayScheduleController : ControllerBase
    {
        private readonly IRunwayScheduleService _service;
        public RunwayScheduleController(IRunwayScheduleService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<GetRunwayScheduleDTO>> GetAllAsync()
        {
            var runwaySchedules = await _service.GetAllAsync();
            return Ok(runwaySchedules);
        }
        // Get details
        [HttpGet("getDetails")]
        public async Task<ActionResult<GetAllDetailsRunwayScheduleDTO>> GetDetailsAsync()
        {
            var runwaySchedules = await _service.GetDetailsAsync();
            return Ok(runwaySchedules);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRunwayScheduleDTO>> GetByIdAsync(int id)
        {
            var runwaySchedule = await _service.GetByIdAsync(id);
            if (runwaySchedule is null) return NotFound();
            return Ok(runwaySchedule);
        }
        // Create
        [HttpPost]
        public async Task<ActionResult<GetAllDetailsRunwayScheduleDTO>> CreateAsync([FromBody] CreateAndUpdateRunwayScheduleDTO createRunwayScheduleDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdRunwaySchedule = await _service.CreateAsync(createRunwayScheduleDTO);
            if (createdRunwaySchedule is null) return NotFound();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdRunwaySchedule.Id }, createdRunwaySchedule);
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<GetRunwayScheduleDTO>> UpdateAsync(int id, [FromBody] CreateAndUpdateRunwayScheduleDTO updateRunwayScheduleDTO)
        {
            if (updateRunwayScheduleDTO is null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedRunwaySchedule = await _service.UpdateAsync(id, updateRunwayScheduleDTO);
            if (updatedRunwaySchedule is null) return NotFound();
            return Ok(updatedRunwaySchedule);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if(id <= 0) return BadRequest();
            var isDeleted = await _service.DeleteAsync(id);
            if (string.IsNullOrWhiteSpace(isDeleted)) return NotFound();
            return NoContent();
        }

    }
}
