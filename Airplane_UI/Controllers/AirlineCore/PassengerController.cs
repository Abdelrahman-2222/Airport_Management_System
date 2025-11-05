using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.FlightDTOs;
using Airplane_UI.DTOs.AirlineCore.PassengerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _service;

        public PassengerController(IPassengerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all passenger records.
        /// </summary>
        /// <returns> Returns 200 OK if successful. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific passenger by its unique identifier.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to retrieve.</param>
        /// <returns> Returns 200 OK if found; otherwise, may return 404 Not Found.</returns>
        [HttpGet("{passengerId}")]
        public async Task<IActionResult> GetByIdAsync(int passengerId)
        {
            var result = await _service.GetByIdAsync(passengerId);

            return Ok(result);
        }

        /// <summary>
        /// Creates a new passenger record.
        /// </summary>
        /// <param name="dto">The dto containing the passenger details to create.</param>
        /// <returns> Returns 200 OK if creation is successful. </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAndUpdatePassengerDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing passenger record.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to update.</param>
        /// <param name="dto">The dto containing updated passenger information.</param>
        /// <returns> Returns 200 OK if the update succeeds, or null if the passenger was not found.</returns>
        [HttpPut("{passengerId}")]
        public async Task<IActionResult> UpdateAsync(int passengerId, [FromBody] CreateAndUpdatePassengerDTO dto)
        {
            var result = await _service.UpdateAsync(passengerId, dto);

            return Ok(result);
        }

        /// <summary>
        /// Deletes an existing passenger record by its unique identifier.
        /// </summary>
        /// <param name="passengerId">The unique identifier of the passenger to delete.</param>
        /// <returns> Returns 200 OK if deletion succeeds, or 400 Bad Request if it fails.</returns>
        [HttpDelete("{passengerId}")]
        public async Task<IActionResult> DeleteAsync(int passengerId)
        {
            var isDeleted = await _service.DeleteAsync(passengerId);

            return isDeleted == null ? BadRequest() : Ok(isDeleted);
        }
    }
}
