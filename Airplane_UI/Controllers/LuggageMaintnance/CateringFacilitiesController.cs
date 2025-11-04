using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.DTOs.LuggageMaintnance.CateringFacilitiesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.LuggageMaintnance
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateringFacilitiesController : ControllerBase
    {
        private readonly ICateringFacilitiesService _service;

        public CateringFacilitiesController(ICateringFacilitiesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<GetCateringFacilitiesDTO>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
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
}
