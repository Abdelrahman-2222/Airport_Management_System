using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceTaskDTO;
using Airplane_UI.DTOs.LuggageMaintnance.MaintinanceTaskDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance;

[Route("api/[controller]")]
[ApiController]
public class MaintenanceTaskController : ControllerBase
{
    private readonly IMaintenanceTaskService _service;

    public MaintenanceTaskController(IMaintenanceTaskService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<GetMaintenanceTaskDTO>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
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
