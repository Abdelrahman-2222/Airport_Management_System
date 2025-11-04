using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.MaintenanceLogDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceLogController : ControllerBase
    {
        private readonly IMaintenanceLogService _service;

        public MaintenanceLogController(IMaintenanceLogService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<GetMaintenanceLogDTO>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
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
}
