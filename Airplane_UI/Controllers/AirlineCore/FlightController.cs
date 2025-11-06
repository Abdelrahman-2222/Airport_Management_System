using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.FlightDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _service;

        public FlightController(IFlightService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all flight records.
        /// </summary>
        /// <returns> Returns 200 OK if successful. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result =  await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific flight by its unique identifier.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to retrieve.</param>
        /// <returns> Returns 200 OK if found; otherwise, may return 404 Not Found.</returns>
        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetByIdAsync(int flightId)
        {
            var result = await _service.GetByIdAsync(flightId);
            
            return Ok(result);
        }

        /// <summary>
        /// Creates a new flight record.
        /// </summary>
        /// <param name="dto">The dto containing the flight details to create.</param>
        /// <returns> Returns 200 OK if creation is successful. </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAndUpdateFlightDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing flight record.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to update.</param>
        /// <param name="dto">The dto containing updated flight information.</param>
        /// <returns> Returns 200 OK if the update succeeds, or null if the flight was not found.</returns>
        [HttpPut("{flightId}")]
        public async Task<IActionResult> UpdateAsync(int flightId, [FromBody] CreateAndUpdateFlightDTO dto)
        {
            var result = await _service.UpdateAsync(flightId, dto);
            
            return Ok(result);
        }

        /// <summary>
        /// Deletes an existing flight record by its unique identifier.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight to delete.</param>
        /// <returns> Returns 200 OK if deletion succeeds, or 400 Bad Request if it fails.</returns>
        [HttpDelete("{flightId}")]
        public async Task<IActionResult> DeleteAsync(int flightId)
        {
            var isDeleted = await _service.DeleteAsync(flightId);

            return isDeleted == null ? BadRequest() : Ok(isDeleted);
        }
    }
}
