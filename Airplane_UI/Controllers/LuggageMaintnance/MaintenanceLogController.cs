using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;
/// <summary>
/// Controller responsible for managing maintenance log operations such as
/// retrieving, creating, updating, and deleting maintenance log records.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MaintenanceLogController : ControllerBase
{
    /// <summary>
    /// The service responsible for handling business logic and data operations related to maintenance logs.
    /// </summary>
    private readonly IMaintenanceLogService _service;
    /// <summary>
    /// Initializes a new instance of the MaintenanceLogController class.
    /// </summary>
    /// <param name="service">The maintenance log service used for performing CRUD operations.</param>
    public MaintenanceLogController(IMaintenanceLogService service)
    {
        _service = service;
    }
    /// <summary>
    /// Retrieves all maintenance log entries.
    /// </summary>
    /// <returns>
    /// A list of GetMaintenanceLogDTO objects representing all maintenance logs in the system.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetMaintenanceLogDTO>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    /// <summary>
    /// Retrieves a specific maintenance log entry by its unique identifier.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the maintenance log entry to retrieve.</param>
    /// <returns>
    /// A GetMaintenanceLogDTO object containing the details of the requested maintenance log.
    /// </returns>
    [HttpGet("{maintenanceLogId}")]
    public async Task<ActionResult<GetMaintenanceLogDTO>> GetById(int maintenanceLogId)
    {
        var result = await _service.GetByIdAsync(maintenanceLogId);
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
    /// Creates a new maintenance log entry.
    /// </summary>
    /// <param name="dto">The data transfer object containing information to create a new maintenance log.</param>
    /// <returns>
    /// The created GetMaintenanceLogDTO object.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetMaintenanceLogDTO>> Create([FromBody] CreateAndUpdateMaintenanceLogDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created();
    }
    /// <summary>
    /// Updates an existing maintenance log entry.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the maintenance log to update.</param>
    /// <param name="dto">The data transfer object containing updated maintenance log details.</param>
    /// <returns>
    /// The updated GetMaintenanceLogDTO object.
    /// </returns>
    [HttpPut("{maintenanceLogId}")]
    public async Task<ActionResult<GetMaintenanceLogDTO>> Update(int maintenanceLogId, [FromBody] CreateAndUpdateMaintenanceLogDTO dto)
    {
        var isUpdated = await _service.UpdateAsync(maintenanceLogId, dto);
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
    /// Deletes a maintenance log entry by its unique identifier.
    /// </summary>
    /// <param name="maintenanceLogId">The unique identifier of the maintenance log to delete.</param>
    /// <returns>
    /// A message indicating whether the deletion was successful.
    /// </returns>
    [HttpDelete("{maintenanceLogId}")]
    public async Task<ActionResult<string>> Delete(int maintenanceLogId)
    {
        var isDeleted = await _service.DeleteAsync(maintenanceLogId);
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
