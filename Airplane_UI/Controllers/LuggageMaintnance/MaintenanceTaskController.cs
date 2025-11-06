using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;
/// <summary>
/// Controller responsible for managing maintenance task operations such as
/// retrieving, creating, updating, and deleting maintenance tasks.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MaintenanceTaskController : ControllerBase
{
    /// <summary>
    /// The service responsible for handling business logic and data operations related to maintenance tasks.
    /// </summary>
    private readonly IMaintenanceTaskService _service;
    /// <summary>
    /// Initializes a new instance of the MaintenanceTaskController class.
    /// </summary>
    /// <param name="service">The maintenance task service used for performing CRUD operations.</param>
    public MaintenanceTaskController(IMaintenanceTaskService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all maintenance tasks.
    /// </summary>
    /// <returns>
    /// A list of GetMaintenanceTaskDTO objects representing all maintenance tasks in the system.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetMaintenanceTaskDTO>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    /// <summary>
    /// Retrieves a specific maintenance task by its unique identifier.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task to retrieve.</param>
    /// <returns>
    /// A GetMaintenanceTaskDTO object containing the details of the requested maintenance task.
    /// </returns>
    [HttpGet("{maintenanceTaskId}")]
    public async Task<ActionResult<GetMaintenanceTaskDTO>> GetById(int maintenanceTaskId)
    {
        var result = await _service.GetByIdAsync(maintenanceTaskId);
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
    /// Creates a new maintenance task.
    /// </summary>
    /// <param name="dto">The data transfer object containing information to create a new maintenance task.</param>
    /// <returns>
    /// The created GetMaintenanceTaskDTO object.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetMaintenanceTaskDTO>> Create([FromBody] CreateAndUpdateMaintenanceTaskDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing maintenance task.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task to update.</param>
    /// <param name="dto">The data transfer object containing updated maintenance task details.</param>
    /// <returns>
    /// The updated GetMaintenanceTaskDTO object.
    /// </returns>
    [HttpPut("{maintenanceTaskId}")]
    public async Task<ActionResult<GetMaintenanceTaskDTO>> Update(int maintenanceTaskId, [FromBody] CreateAndUpdateMaintenanceTaskDTO dto)
    {
        var isUpdated = await _service.UpdateAsync(maintenanceTaskId, dto);
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
    /// Deletes a maintenance task by its unique identifier.
    /// </summary>
    /// <param name="maintenanceTaskId">The unique identifier of the maintenance task to delete.</param>
    /// <returns>
    /// A message indicating whether the deletion was successful.
    /// </returns>
    [HttpDelete("{maintenanceTaskId}")]
    public async Task<ActionResult<string>> Delete(int maintenanceTaskId)
    {
        var isDeleted = await _service.DeleteAsync(maintenanceTaskId);
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
