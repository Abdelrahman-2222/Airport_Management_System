using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Airplane_UI.Services.SecurityGates;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    /// <summary>
    /// Handles HTTP requests related to Airport Staff management.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AirportStaffController : ControllerBase
    {
        private readonly AirportStaffService _service;

        /// <summary>
        /// Initializes a new instance of <see cref="AirportStaffController"/>.
        /// </summary>
        /// <param name="service">The service responsible for airport staff operations.</param>
        public AirportStaffController(AirportStaffService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all airport staff members.
        /// </summary>
        /// <returns>A list of airport staff records.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _service.GetAllAsync();
            return Ok(staff);
        }

        /// <summary>
        /// Retrieves an airport staff member by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the staff member.</param>
        /// <returns>The staff record if found; otherwise, a 404 response.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _service.GetByIdAsync(id);
            if (staff == null)
                return NotFound($"Staff member with ID {id} not found.");

            return Ok(staff);
        }

        /// <summary>
        /// Creates a new airport staff record.
        /// </summary>
        /// <param name="createDto">The data used to create the new staff member.</param>
        /// <returns>The created staff record with its generated ID.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAirportStaffDto createDto)
        {
            if (createDto == null)
                return BadRequest("Invalid staff data.");

            var created = await _service.CreateAsync(createDto);
            if (created == null)
                return BadRequest("Failed to create staff member.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing airport staff record.
        /// </summary>
        /// <param name="id">The ID of the staff member to update.</param>
        /// <param name="updateDto">The updated staff data.</param>
        /// <returns>The updated staff record if found; otherwise, a 404 response.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAirportStaffDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("Invalid update data.");

            var updated = await _service.UpdateAsync(id, updateDto);
            if (updated == null)
                return NotFound($"Staff member with ID {id} not found.");

            return Ok(updated);
        }

        /// <summary>
        /// Deletes an airport staff member by their unique ID.
        /// </summary>
        /// <param name="id">The ID of the staff member to delete.</param>
        /// <returns>No content if deletion is successful; otherwise, a 404 response.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"Staff member with ID {id} not found.");

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
