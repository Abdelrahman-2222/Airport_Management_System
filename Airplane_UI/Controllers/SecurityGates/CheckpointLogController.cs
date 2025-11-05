using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.CheckpointLog;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    /// <summary>
    /// API Controller for managing checkpoint logs including CRUD operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CheckpointLogController : ControllerBase
    {
        private readonly ICheckpointLogService _service;

        /// <summary>
        /// Initializes a new instance of <see cref="CheckpointLogController"/>.
        /// </summary>
        /// <param name="service">The checkpoint log service.</param>
        public CheckpointLogController(ICheckpointLogService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all checkpoint logs.
        /// </summary>
        /// <returns>A list of all checkpoint logs.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GetCheckpointLogDto>>> GetAll()
        {
            var logs = await _service.GetAllAsync();
            return Ok(logs);
        }

        /// <summary>
        /// Retrieves a checkpoint log by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log.</param>
        /// <returns>The checkpoint log if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCheckpointLogDto>> GetById(int id)
        {
            var log = await _service.GetByIdAsync(id);
            if (log == null)
                return NotFound($"CheckpointLog {id} not found");

            return Ok(log);
        }

        /// <summary>
        /// Creates a new checkpoint log.
        /// </summary>
        /// <param name="dto">The data required to create a checkpoint log.</param>
        /// <returns>The newly created checkpoint log.</returns>
        [HttpPost]
        public async Task<ActionResult<GetCheckpointLogDto>> Create([FromBody] CreateCheckpointLogDto dto)
        {
            var newLog = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newLog.Id }, newLog);
        }

        /// <summary>
        /// Updates an existing checkpoint log's reported wait time.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log to update.</param>
        /// <param name="dto">The updated wait time data.</param>
        /// <returns>The updated checkpoint log if successful, otherwise NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCheckpointLogDto>> Update(int id, [FromBody] UpdateCheckpointLogDto dto)
        {
            var updatedLog = await _service.UpdateAsync(id, dto);
            if (updatedLog == null)
                return NotFound($"CheckpointLog {id} not found");

            return Ok(updatedLog);
        }

        /// <summary>
        /// Deletes a checkpoint log by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the checkpoint log to delete.</param>
        /// <returns>A message indicating the result of the deletion.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.Contains("not found"))
                return NotFound(result);

            return Ok(result);
        }
    }
}
