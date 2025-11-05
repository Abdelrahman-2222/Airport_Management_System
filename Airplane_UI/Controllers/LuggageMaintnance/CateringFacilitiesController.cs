using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;
/// <summary>
/// Handles HTTP requests for managing catering facilities.
/// Provides endpoints for creating, retrieving, updating, and deleting catering facility records.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CateringFacilitiesController : ControllerBase
{
    /// <summary>
    /// The service responsible for executing business logic related to catering facilities.
    /// </summary>
    private readonly ICateringFacilitiesService _service;

    /// <summary>
    /// Initializes a new instance of the CateringFacilitiesController class.
    /// </summary>
    /// <param name="service">The catering facilities service used to handle data operations.</param>
    public CateringFacilitiesController(ICateringFacilitiesService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all available catering facilities.
    /// </summary>
    /// <returns>
    /// A list of GetCateringFacilitiesDTO objects representing all catering facilities.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetCateringFacilitiesDTO>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    /// <summary>
    /// Retrieves a specific catering facility by its unique identifier.
    /// </summary>
    /// <param name="cateringFacilitiesId">The unique identifier of the catering facility to retrieve.</param>
    /// <returns>
    /// The GetCateringFacilitiesDTO object representing the catering facility, or a bad request if not found.
    /// </returns>
    [HttpGet("{cateringFacilitiesId}")]
    public async Task<ActionResult<GetCateringFacilitiesDTO>> GetById(int cateringFacilitiesId)
    {
        var result = await _service.GetByIdAsync(cateringFacilitiesId);
        if (result == null)
        {
            return BadRequest("Invalid Id");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(result);
    }
    /// <summary>
    /// Creates a new catering facility record.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the catering facility to create.</param>
    /// <returns>
    /// The created GetCateringFacilitiesDTO object.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetCateringFacilitiesDTO>> Create([FromBody] CreateAndUpdateCateringFacilitiesDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing catering facility record.
    /// </summary>
    /// <param name="cateringFacilitiesId">The unique identifier of the catering facility to update.</param>
    /// <param name="dto">The data transfer object containing updated catering facility information.</param>
    /// <returns>
    /// The updated GetCateringFacilitiesDTO object.
    /// </returns>
    [HttpPut("{cateringFacilitiesId}")]
    public async Task<ActionResult<GetCateringFacilitiesDTO>> Update(int cateringFacilitiesId, [FromBody] CreateAndUpdateCateringFacilitiesDTO dto)
    {
        var isUpdated = await _service.UpdateAsync(cateringFacilitiesId, dto);
        if (isUpdated == null)
        {
            return NotFound("Update not successfully");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(isUpdated);
    }
    /// <summary>
    /// Deletes a catering facility record by its unique identifier.
    /// </summary>
    /// <param name="cateringFacilitiesId">The unique identifier of the catering facility to delete.</param>
    /// <returns>
    /// A confirmation message if the deletion was successful.
    /// </returns>
    [HttpDelete("{cateringFacilitiesId}")]
    public async Task<ActionResult<string>> Delete(int cateringFacilitiesId)
    {
        var isDeleted = await _service.DeleteAsync(cateringFacilitiesId);
        if (isDeleted == null)
        {
            return NotFound("Delete not successfully");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok("Delete is Done");
    }
}
