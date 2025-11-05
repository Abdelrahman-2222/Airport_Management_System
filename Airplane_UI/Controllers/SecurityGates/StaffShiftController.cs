using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    ///
    /// API controller responsible for handling Staff Shift business logic.
    ///
    [ApiController]
    [Route("api/[controller]")]
    public class StaffShiftController : ControllerBase
    {
        private readonly IStaffShiftService _staffShiftService;

        /// <summary>  
        /// Initializes a new instance of the <see cref="StaffShiftController"/> class.  
        /// </summary>  
        /// <param name="staffShiftService">The staff shift service dependency.</param>  
        public StaffShiftController(IStaffShiftService staffShiftService)
        {
            _staffShiftService = staffShiftService;
        }

        /// <summary>  
        /// Retrieves all staff shifts.  
        /// </summary>  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var shifts = await _staffShiftService.GetAllAsync();
            return Ok(shifts);
        }

        /// <summary>  
        /// Retrieves a specific staff shift by its ID.  
        /// </summary>  
        /// <param name="id">The unique identifier of the staff shift.</param>  
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shift = await _staffShiftService.GetByIdAsync(id);
            if (shift == null) return NotFound("Shift not found.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(shift);
        }

        /// <summary>  
        /// Creates a new staff shift.  
        /// </summary>  
        /// <param name="createDto">The data transfer object containing staff shift details.</param>  
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStaffShiftDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdShift = await _staffShiftService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = createdShift.Id }, createdShift);
        }

        /// <summary>  
        /// Updates an existing staff shift.  
        /// </summary>  
        /// <param name="id">The unique identifier of the staff shift to update.</param>  
        /// <param name="updateDto">The data transfer object containing updated staff shift details.</param>  
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStaffShiftDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedShift = await _staffShiftService.UpdateAsync(id, updateDto);
            if (updatedShift == null) return NotFound("Update not successful.");

            return Ok(updatedShift);
        }

        /// <summary>  
        /// Deletes a staff shift by its ID.  
        /// </summary>  
        /// <param name="id">The unique identifier of the staff shift to delete.</param>  
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _staffShiftService.DeleteAsync(id);
            if (result.Contains("not found")) return NotFound("Delete not successful.");

            return Ok("Delete is done.");
        }
    }

}