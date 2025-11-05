using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    ///
    /// Handles HTTP requests related to Security Checkpoints management.
    ///
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityCheckpointController : ControllerBase
    {
        private readonly ISecurityCheckpointService _service;

        /// <summary>  
        /// Initializes a new instance of <see cref="SecurityCheckpointController"/>.  
        /// </summary>  
        /// <param name="service">The service responsible for checkpoint operations.</param>  
        public SecurityCheckpointController(ISecurityCheckpointService service)
        {
            _service = service;
        }

        /// <summary>  
        /// Retrieves all security checkpoints.  
        /// </summary>  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var checkpoints = await _service.GetAllAsync();
            return Ok(checkpoints);
        }

        /// <summary>  
        /// Retrieves a security checkpoint by its unique ID.  
        /// </summary>  
        /// <param name="id">The checkpoint ID.</param>  
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var checkpoint = await _service.GetByIdAsync(id);
            if (checkpoint == null) return NotFound($"Checkpoint with ID {id} not found.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(checkpoint);
        }

        /// <summary>  
        /// Retrieves detailed checkpoint information including logs and assignments.  
        /// </summary>  
        /// <param name="id">The checkpoint ID.</param>  
        [HttpGet("{id:int}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var details = await _service.GetDetailsAsync(id);
            if (details == null) return NotFound($"Details for checkpoint ID {id} not found.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(details);
        }

        /// <summary>  
        /// Retrieves all checkpoints in a specific terminal.  
        /// </summary>  
        /// <param name="terminalId">The terminal ID to filter by.</param>  
        [HttpGet("by-terminal/{terminalId:int}")]
        public async Task<IActionResult> GetByTerminal(int terminalId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var checkpoints = await _service.GetByTerminalAsync(terminalId);
            return Ok(checkpoints);
        }

        /// <summary>  
        /// Retrieves all checkpoints by operational status.  
        /// </summary>  
        /// <param name="status">The operational status to filter by.</param>  
        [HttpGet("by-status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var checkpoints = await _service.GetByStatusAsync(status);
            return Ok(checkpoints);
        }

        /// <summary>  
        /// Creates a new security checkpoint.  
        /// </summary>  
        /// <param name="createDto">The checkpoint data.</param>  
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSecurityCheckpointDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateAsync(createDto);
            if (created == null) return BadRequest("Failed to create checkpoint. Terminal not found or name already exists.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>  
        /// Updates an existing checkpoint.  
        /// </summary>  
        /// <param name="id">The checkpoint ID.</param>  
        /// <param name="updateDto">The updated checkpoint data.</param>  
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSecurityCheckpointDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, updateDto);
            if (updated == null) return NotFound($"Checkpoint with ID {id} not found.");

            return Ok(updated);
        }

        /// <summary>  
        /// Deletes a checkpoint by its ID.  
        /// </summary>  
        /// <param name="id">The checkpoint ID.</param>  
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound($"Checkpoint with ID {id} not found.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.DeleteAsync(id);
            return Ok("Delete is Done");
        }

        /// <summary>  
        /// Updates the status of a checkpoint.  
        /// </summary>  
        /// <param name="id">The checkpoint ID.</param>  
        /// <param name="status">The new operational status.</param>  
        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound($"Checkpoint with ID {id} not found.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.UpdateStatusAsync(id, status);
            return Ok($"Checkpoint {id} status updated to {status}.");
        }
    }

}