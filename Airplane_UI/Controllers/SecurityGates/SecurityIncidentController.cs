using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.SecurityIncident;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    /// <summary>
    /// API controller for managing Security Incidents.
    /// Provides CRUD operations for security incidents.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityIncidentController : ControllerBase
    {
        private readonly ISecurityIncidentService _service;

        /// <summary>
        /// Initializes a new instance of <see cref="SecurityIncidentController"/>.
        /// </summary>
        /// <param name="service">Service for managing security incidents.</param>
        public SecurityIncidentController(ISecurityIncidentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all security incidents.
        /// </summary>
        /// <returns>List of security incidents.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GetSecurityIncidentDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a security incident by its ID.
        /// </summary>
        /// <param name="id">The incident ID.</param>
        /// <returns>The requested incident or 404 if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetSecurityIncidentDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound($"Incident {id} not found");
            return Ok(result);
        }

        /// <summary>
        /// Creates a new security incident.
        /// </summary>
        /// <param name="dto">Incident creation data.</param>
        /// <returns>The created incident or 400 if invalid.</returns>
        [HttpPost]
        public async Task<ActionResult<GetSecurityIncidentDto>> Create([FromBody] CreateSecurityIncidentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing security incident.
        /// </summary>
        /// <param name="id">Incident ID.</param>
        /// <param name="dto">Updated incident data.</param>
        /// <returns>The updated incident or 404 if not found.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetSecurityIncidentDto>> Update(int id, [FromBody] UpdateSecurityIncidentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound($"Incident {id} not found");

            return Ok(updated);
        }

        /// <summary>
        /// Deletes a security incident by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the security incident to delete.</param>
        /// <returns>A message indicating the result of the deletion.</returns>

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Security incident with ID {id} not found.");

            await _service.DeleteAsync(id);

            return Ok($"Security incident with ID {id} deleted successfully.");
        }
    }
}
