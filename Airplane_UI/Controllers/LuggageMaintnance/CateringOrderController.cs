using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.CateringOrderDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateringOrderController : ControllerBase
    {
        private readonly ICateringOrderService _service;

        public CateringOrderController(ICateringOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<GetCateringOrderDTO>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
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
}
