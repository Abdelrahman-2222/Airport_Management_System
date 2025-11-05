using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.DTOs.SecurityGates.CustomsDesk;
using Airplane_UI.Services.SecurityGates;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.SecurityGates
{
    ///<summary>
    /// API controller responsible for managing Customs Desks operations.
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomsDeskController : ControllerBase
    {
        private readonly ICustomsDeskService _customsDeskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomsDeskController"/>.
        /// </summary>
        /// <param name="customsDeskService">Injected service for Customs Desk operations.</param>
        public CustomsDeskController(ICustomsDeskService customsDeskService)
        {
            _customsDeskService = customsDeskService;
        }

//        /// <summary>
//        /// Retrieves all Customs Desks.
//        /// </summary>
//        [HttpGet("all")]
//        public async Task<IActionResult> GetAll()
//        {
//            var desks = await _customsDeskService.GetAllAsync();
//            return Ok(desks);
//        }

//        /// <summary>
//        /// Retrieves a specific Customs Desk by ID.
//        /// </summary>
//        /// <param name="id">The unique desk ID.</param>
//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var desk = await _customsDeskService.GetByIdAsync(id);
//            if (desk == null) return NotFound("Customs Desk not found.");
//            return Ok(desk);
//        }

//        /// <summary>
//        /// Retrieves detailed information about a Customs Desk including assigned staff shifts.
//        /// </summary>
//        /// <param name="id">The desk ID.</param>
//        [HttpGet("details/{id:int}")]
//        public async Task<IActionResult> GetDetails(int id)
//        {
//            var details = await _customsDeskService.GetDetailsAsync(id);
//            if (details == null) return NotFound("Details not found.");
//            return Ok(details);
//        }

//        /// <summary>
//        /// Retrieves all desks belonging to a specific terminal.
//        /// </summary>
//        /// <param name="terminalId">The terminal ID.</param>
//        [HttpGet("terminal/{terminalId:int}")]
//        public async Task<IActionResult> GetByTerminal(int terminalId)
//        {
//            var desks = await _customsDeskService.GetByTerminalAsync(terminalId);
//            return Ok(desks);
//        }

//        /// <summary>
//        /// Retrieves all desks filtered by operational status.
//        /// </summary>
//        /// <param name="status">The status to filter by (e.g., Active/Inactive).</param>
//        [HttpGet("status/{status}")]
//        public async Task<IActionResult> GetByStatus(string status)
//        {
//            var desks = await _customsDeskService.GetByStatusAsync(status);
//            return Ok(desks);
//        }

//        /// <summary>
//        /// Creates a new Customs Desk.
//        /// </summary>
//        /// <param name="createDto">The desk creation DTO.</param>
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateCustomsDeskDto createDto)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);

//            var result = await _customsDeskService.CreateAsync(createDto);
//            if (result == null) return BadRequest("Desk could not be created. Check terminal or duplication.");

//            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
//        }

//        /// <summary>
//        /// Updates an existing Customs Desk.
//        /// </summary>
//        /// <param name="id">The desk ID.</param>
//        /// <param name="updateDto">The updated data.</param>
//        [HttpPut("{id:int}")]
//        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomsDeskDto updateDto)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);

//            var result = await _customsDeskService.UpdateAsync(id, updateDto);
//            if (result == null) return NotFound("Desk not found.");

//            return Ok(result);
//        }

//        /// <summary>
//        /// Deletes a Customs Desk by ID.
//        /// </summary>
//        /// <param name="id">The desk ID.</param>
//        [HttpDelete("{id:int}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _customsDeskService.DeleteAsync(id);
//            return NoContent();
//        }

//        /// <summary>
//        /// Updates the operational status of a Customs Desk.
//        /// </summary>
//        /// <param name="id">The desk ID.</param>
//        /// <param name="status">The new status.</param>
//        [HttpPatch("{id:int}/status")]
//        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
//        {
//            await _customsDeskService.UpdateStatusAsync(id, status);
//            return NoContent();
//        }
//    }

//}