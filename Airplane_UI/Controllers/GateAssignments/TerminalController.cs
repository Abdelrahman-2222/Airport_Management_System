using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.TerminalDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _service;
        public TerminalController(ITerminalService service)
        {
            _service = service;
        }
        // GetAll
        [HttpGet]
        public async Task<ActionResult<GetTerminalDTO>> GetAll()
        {
            var terminals = await _service.GetAllAsync();
            return Ok(terminals);
        }
        // Get details
        [HttpGet("getDetails")]
        public async Task<ActionResult<GetAllDetailsTerminalDTO>> GetDetails()
        {
            var terminals = await _service.GetDetailsAsync();
            return Ok(terminals);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTerminalDTO>> GetById(int id)
        {
            var terminal = await _service.GetByIdAsync(id);
            if (terminal is null) return NotFound();
            return Ok(terminal);
        }
        // Create
        [HttpPost]
        public async Task<ActionResult<GetAllDetailsTerminalDTO>> Create([FromBody] CreateAndUpdateTerminalDTO createTerminalDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdTerminal = await _service.CreateAsync(createTerminalDTO);
            if (createdTerminal is null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = createdTerminal.Id }, createdTerminal);
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<GetTerminalDTO>> Update(int id, [FromBody] CreateAndUpdateTerminalDTO updateTerminalDTO)
        {
            if (updateTerminalDTO is null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedTerminal = await _service.UpdateAsync(id, updateTerminalDTO);
            if (updatedTerminal is null) return NotFound();
            return Ok(updatedTerminal);
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
