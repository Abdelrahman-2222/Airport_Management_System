using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.GateDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IGateService _service;
        public GateController(IGateService service)
        {
            _service = service;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<GetGateDTO>> GetAll()
        {
            var gates = await _service.GetAllAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gates);
        }
        // GetDetails
        [HttpGet("getDetails")]
        public async Task<ActionResult<GetAllDetailsGateDTO>> GetDetails()
        {
            var gate = await _service.GetDetailsAsync();
            if(gate is null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gate);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<GetGateDTO>> GetById(int id)
        {
            var gate = await _service.GetByIdAsync(id);
            if(gate is null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(gate);
        }
        // Create
        [HttpPost]
        public async Task<ActionResult<GetAllDetailsGateDTO>> Create([FromBody] CreateAndUpdateGateDTO createGateDTO)
        {
            var createdGate = await _service.CreateAsync(createGateDTO);
            if(createdGate is null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return CreatedAtAction(nameof(createdGate), new { id = createdGate.Id }, createdGate);
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAllDetailsGateDTO>> Update(int id, [FromBody] CreateAndUpdateGateDTO updateGateDTO)
        {
            if(updateGateDTO is null) return BadRequest(ModelState);
            var updatedGate = await _service.UpdateAsync(id, updateGateDTO);
            if(updatedGate is null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(updatedGate);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if(result is null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(result);
        }
    }
}
