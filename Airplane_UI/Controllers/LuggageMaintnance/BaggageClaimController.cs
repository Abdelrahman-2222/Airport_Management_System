using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;

/// <summary>
/// API controller for managing baggage claim operations such as retrieving,
/// creating, updating, and deleting baggage claim records.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BaggageClaimController : ControllerBase
{
    /// <summary>
    /// The service responsible for handling baggage claim business logic.
    /// </summary>
    private readonly IBaggageClaimService _service;
    /// <summary>
    /// Initializes a new instance of the BaggageClaimController class.
    /// </summary>
    /// <param name="service">The baggage claim service to handle data operations.</param>
    public BaggageClaimController(IBaggageClaimService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all baggage claim records.
    /// </summary>
    /// <returns>A list of all baggage claim records.</returns>
    [HttpGet]
    public async Task<ActionResult<GetBaggageClaimDto>> GetAll()
    {
        var baggage = await _service.GetAllAsync();
        return Ok(baggage);
    }
    /// <summary>
    /// Retrieves a baggage claim record by its unique identifier.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim.</param>
    /// <returns>The baggage claim record if found; otherwise, a BadRequest result.</returns>
    [HttpGet("{baggageId}")]
    public async Task<ActionResult<GetBaggageClaimDto>> GetById(int baggageId)
    {
        var baggage = await _service.GetByIdAsync(baggageId);
        if (baggage == null)
            return BadRequest("Invalid Id");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(baggage);
    }
    /// <summary>
    /// Creates a new baggage claim record.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the baggage claim to create.</param>
    /// <returns>The created baggage claim record.</returns>
    [HttpPost]
    public async Task<ActionResult<GetBaggageClaimDto>> Create([FromBody] CreateAndUpdateBaggageClaimDto dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing baggage claim record.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim to update.</param>
    /// <param name="dto">The data transfer object containing updated baggage claim details.</param>
    /// <returns>No content if successful; otherwise, a BadRequest result.</returns>
    [HttpPut("{baggageId}")]
    public async Task<ActionResult<GetBaggageClaimDto>> Update(int baggageId, [FromBody] CreateAndUpdateBaggageClaimDto dto)
    {
        var isUpdated = await _service.UpdateAsync(baggageId, dto);
        if (isUpdated == null)
            return NotFound("Update not successfully");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(isUpdated);
    }
    /// <summary>
    /// Deletes a baggage claim record by its unique identifier.
    /// </summary>
    /// <param name="baggageId">The unique identifier of the baggage claim to delete.</param>
    /// <returns>No content if successful; otherwise, a BadRequest result.</returns>
    [HttpDelete("{baggageId}")]
    public async Task<ActionResult<string>> Delete(int baggageId)
    {
        var isDeleted = await _service.DeleteAsync(baggageId);
        if (isDeleted == null)
            return NotFound("Delete not successfully");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok("Delete is Done");
    }
}
