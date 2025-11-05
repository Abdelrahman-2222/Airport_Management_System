using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;
/// <summary>
/// Controller responsible for handling HTTP requests related to catering orders.
/// Provides endpoints for creating, retrieving, updating, and deleting catering order records.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CateringOrderController : ControllerBase
{
    /// <summary>
    /// The service responsible for business logic and data operations related to catering orders.
    /// </summary>
    private readonly ICateringOrderService _service;
    /// <summary>
    /// Initializes a new instance of the CateringOrderController class.
    /// </summary>
    /// <param name="service">The catering order service used to handle catering order operations.</param>
    public CateringOrderController(ICateringOrderService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all catering orders.
    /// </summary>
    /// <returns>
    /// A list of GetCateringOrderDTO objects representing all existing catering orders.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetCateringOrderDTO>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    /// <summary>
    /// Retrieves a specific catering order by its unique identifier.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order.</param>
    /// <returns>
    /// The GetCateringOrderDTO object representing the catering order.
    /// </returns>
    [HttpGet("{cateringOrderId}")]
    public async Task<ActionResult<GetCateringOrderDTO>> GetById(int cateringOrderId)
    {
        var result = await _service.GetByIdAsync(cateringOrderId);
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
    /// Creates a new catering order.
    /// </summary>
    /// <param name="dto">The data transfer object containing information for creating a catering order.</param>
    /// <returns>
    /// The created GetCateringOrderDTO object.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetCateringOrderDTO>> Create([FromBody] CreateAndUpdateCateringOrderDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing catering order.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order to update.</param>
    /// <param name="dto">The data transfer object containing the updated catering order details.</param>
    /// <returns>
    /// The updated GetCateringOrderDTO object.
    /// </returns>
    [HttpPut("{cateringOrderId}")]
    public async Task<ActionResult<GetCateringOrderDTO>> Update(int cateringOrderId, [FromBody] CreateAndUpdateCateringOrderDTO dto)
    {
        var isUpdated = await _service.UpdateAsync(cateringOrderId, dto);
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
    /// Deletes a catering order by its unique identifier.
    /// </summary>
    /// <param name="cateringOrderId">The unique identifier of the catering order to delete.</param>
    /// <returns>
    /// A confirmation message indicating the result of the deletion process.
    /// </returns>
    [HttpDelete("{cateringOrderId}")]
    public async Task<ActionResult<string>> Delete(int cateringOrderId)
    {
        var isDeleted = await _service.DeleteAsync(cateringOrderId);
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
