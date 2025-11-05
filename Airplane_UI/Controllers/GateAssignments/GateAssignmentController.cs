using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.GateAssignmentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateAssignmentController : ControllerBase
    {
        private readonly IGateAssignmentService _service;
        public GateAssignmentController(IGateAssignmentService service)
        {
            _service = service;
        }
        // GetAll
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var gateAssignments = await _service.GetAllAsync();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gateAssignments);
        }
        // GetDetails
        [HttpGet("getDetails")]
        public async Task<ActionResult> GetDetails()
        {
            var gateAssignments = await _service.GetDetailsAsync();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gateAssignments);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var gateAssignment = await _service.GetByIdAsync(id);
            if (gateAssignment is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gateAssignment);
        }
        // Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAndUpdateGateAssignmentDTO createGateAssignmentDTO)
        {
            var createdGateAssignment = await _service.CreateAsync(createGateAssignmentDTO);
            if (createdGateAssignment is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return CreatedAtAction(nameof(GetById), new { id = createdGateAssignment.Id }, createdGateAssignment);
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateAndUpdateGateAssignmentDTO updateGateAssignmentDTO)
        {
            if (updateGateAssignmentDTO is null) return BadRequest(ModelState);
            var updatedGateAssignment = await _service.UpdateAsync(id, updateGateAssignmentDTO);
            if (updatedGateAssignment is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(updatedGateAssignment);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(result);
        }
    }
}
