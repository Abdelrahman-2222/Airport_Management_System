using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.AirportStaff;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates;
/// <summary>
/// Handles HTTP requests related to Airport Staff management.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AirportStaffController : ControllerBase
{
    private readonly IAirportStaffService _service;

    /// <summary>  
    /// Initializes a new instance of <see cref="AirportStaffController"/>.  
    /// </summary>  
    /// <param name="service">The service responsible for airport staff operations.</param>  
    public AirportStaffController(IAirportStaffService service)
    {
        _service = service;
    }

    /// <summary>  
    /// Retrieves all airport staff members.  
    /// </summary>  
    /// <returns>A list of airport staff records.</returns>  
    [HttpGet]
    public async Task<ActionResult<IList<GetAirportStaffDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(result);
    }

    /// <summary>  
    /// Retrieves an airport staff member by their unique identifier.  
    /// </summary>  
    /// <param name="id">The ID of the staff member.</param>  
    /// <returns>The staff record if found; otherwise, a 404 response.</returns>  
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetAirportStaffDto>> GetByIdAsync(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
            return NotFound($"Staff member with ID {id} not found.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    /// <summary>  
    /// Creates a new airport staff record.  
    /// </summary>  
    /// <param name="dto">The data used to create the new staff member.</param>  
    /// <returns>The created staff record with its generated ID.</returns>  
    [HttpPost]
    public async Task<ActionResult<GetAirportStaffDto>> Create([FromBody] CreateAirportStaffDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _service.CreateAsync(dto);
        if (created == null)
            return BadRequest("Failed to create staff member.");

        return Created();
    }

    /// <summary>  
    /// Updates an existing airport staff record.  
    /// </summary>  
    /// <param name="id">The ID of the staff member to update.</param>  
    /// <param name="dto">The updated staff data.</param>  
    /// <returns>The updated staff record if found; otherwise, a 404 response.</returns>  
    [HttpPut("{id:int}")]
    public async Task<ActionResult<GetAirportStaffDto>> Update(int id, [FromBody] UpdateAirportStaffDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound($"Staff member with ID {id} not found.");

        return Ok(updated);
    }

    /// <summary>  
    /// Deletes an airport staff member by their unique ID.  
    /// </summary>  
    /// <param name="id">The ID of the staff member to delete.</param>  
    /// <returns>A confirmation message if deletion is successful; otherwise, an error response.</returns>  
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound($"Staff member with ID {id} not found.");

        await _service.DeleteAsync(id);

        return Ok($"Staff member with ID {id} deleted successfully.");
    }

}
