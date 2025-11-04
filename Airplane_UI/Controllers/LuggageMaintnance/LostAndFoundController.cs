using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.DTOs.LuggageMaintnance.LostAndFoundDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;
/// <summary>
/// API controller responsible for managing Lost and Found operations such as retrieving, 
/// creating, updating, and deleting Lost and Found records.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LostAndFoundController : ControllerBase
{
    /// <summary>
    /// The service used to handle Lost and Found business logic.
    /// </summary>
    private readonly ILostAndFoundService _service;
    /// <summary>
    /// Initializes a new instance of the LostAndFoundController class.
    /// </summary>
    /// <param name="service">The Lost and Found service dependency.</param>
    public LostAndFoundController(ILostAndFoundService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all Lost and Found records.
    /// </summary>
    /// <returns>A list of Lost and Found records.</returns>
    [HttpGet]
    public async Task<ActionResult<GetLostAndFoundDTO>> GetAll()
    {
        var getLostAndFound = await _service.GetAllAsync();
        return Ok(getLostAndFound);
    }
    /// <summary>
    /// Retrieves a specific Lost and Found record by its ID.
    /// </summary>
    /// <param name="lostAndFoundId">The unique identifier of the Lost and Found record.</param>
    /// <returns>The Lost and Found record if found; otherwise, a bad request response.</returns>
    [HttpGet("{lostAndFoundId}")]
    public async Task<ActionResult<GetLostAndFoundDTO>> GetById(int lostAndFoundId)
    {
        var getLostAndFound = await _service.GetByIdAsync(lostAndFoundId);
        if (getLostAndFound == null)
            return BadRequest("Invalid Id");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(getLostAndFound);
    }
    /// <summary>
    /// Creates a new Lost and Found record.
    /// </summary>
    /// <param name="dto">The data transfer object containing Lost and Found details.</param>
    /// <returns>A response indicating the creation result.</returns>
    [HttpPost]
    public async Task<ActionResult<GetLostAndFoundDTO>> Create([FromBody] CreateAndUpdateLostandFoundDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing Lost and Found record.
    /// </summary>
    /// <param name="lostAndFoundId">The unique identifier of the Lost and Found record to update.</param>
    /// <param name="dto">The data transfer object containing updated Lost and Found details.</param>
    /// <returns>A response indicating whether the update was successful.</returns>
    [HttpPut("{lostAndFoundId}")]
    public async Task<ActionResult<GetLostAndFoundDTO>> Update(int lostAndFoundId, [FromBody] CreateAndUpdateLostandFoundDTO dto)
    {
        var isUpdated = await _service.UpdateAsync(lostAndFoundId, dto);
        if (isUpdated == null)
            return NotFound("Update not successfully");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok("Update is Done");
    }
    /// <summary>
    /// Deletes a Lost and Found record by its ID.
    /// </summary>
    /// <param name="lostAndFoundId">The unique identifier of the Lost and Found record to delete.</param>
    /// <returns>A response indicating whether the deletion was successful.</returns>
    [HttpDelete("{lostAndFoundId}")]
    public async Task<ActionResult> Delete(int lostAndFoundId)
    {
        var isDeleted = await _service.DeleteAsync(lostAndFoundId);
        if (isDeleted == null)
            return NotFound("Delete not successfully");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok("Delete is Done");
    }

}
