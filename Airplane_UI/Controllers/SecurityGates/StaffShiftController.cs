using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates;

[Route("api/[controller]")]
[ApiController]
public class StaffShiftController : ControllerBase
{
    /// <summary>
    /// API controller responsible for handle Staff Shift business logic.
    /// </summary>
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
    /// <returns>A list of staff shifts.</returns>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var shifts = await _staffShiftService.GetAllAsync();
        return Ok(shifts);
    }

    /// <summary>
    /// Retrieves a specific staff shift by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift.</param>
    /// <returns>The staff shift if found; otherwise, a not found response.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetStaffShiftDto>> GetById(int id)
    {
        var shift = await _staffShiftService.GetByIdAsync(id);
        if (shift == null)
            return NotFound("Shift not found");
        return Ok(shift);
    }

    /// <summary>
    /// Creates a new staff shift.
    /// </summary>
    /// <param name="createDto">The data transfer object containing staff shift details.</param>
    /// <returns>A response indicating the creation result.</returns>
    [HttpPost]
    public async Task<ActionResult<GetStaffShiftDto>> Create([FromBody] CreateStaffShiftDto createDto)
    {
        var createdShift = await _staffShiftService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdShift.Id }, createdShift);
    }

    /// <summary>
    /// Updates an existing staff shift.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift to update.</param>
    /// <param name="updateDto">The data transfer object containing updated staff shift details.</param>
    /// <returns>A response indicating whether the update was successful.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GetStaffShiftDto>> Update(int id, [FromBody] UpdateStaffShiftDto updateDto)
    {
        var updatedShift = await _staffShiftService.UpdateAsync(id, updateDto);
        if (updatedShift == null)
            return NotFound("Update not successful");
        return Ok("Update is done");
    }

    /// <summary>
    /// Deletes a staff shift by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift to delete.</param>
    /// <returns>A response indicating whether the deletion was successful.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _staffShiftService.DeleteAsync(id);
        if (result.Contains("not found"))
            return NotFound("Delete not successful");
        return Ok("Delete is done");
    }

}