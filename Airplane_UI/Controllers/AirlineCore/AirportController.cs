using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.AirportDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    /// <summary>
    /// API controller responsible for handling airport-related operations.
    /// Provides endpoints for creating, retrieving, updating, and deleting airport records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _service;

        /// <summary>
        /// Initializes a new instance of the AirportController class.
        /// </summary>
        /// <param name="service">The service responsible for airport data management.</param>
        public AirportController(IAirportService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all airport records.
        /// </summary>
        /// <returns>
        /// Returns 200 OK if successful.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var airports = await _service.GetAllAsync();
            return Ok(airports);
        }

        /// <summary>
        /// Retrieves a specific airport by its unique identifier.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to retrieve.</param>
        /// <returns>
        /// Returns 200 OK if found; otherwise, may return 404 Not Found.
        /// </returns>
        [HttpGet("{airportId}")]
        public async Task<ActionResult> GetById(int airportId)
        {
            var airport = await _service.GetyByIdAsync(airportId);
            return Ok(airport);
        }

        /// <summary>
        /// Creates a new airport record.
        /// </summary>
        /// <param name="dto">The data transfer object containing the airport details to create.</param>
        /// <returns>
        /// Returns 200 OK if creation is successful.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAndUpdateAirportDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

        /// <summary>
        /// Updates an existing airport record.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to update.</param>
        /// <param name="dto">The data transfer object containing updated airport information.</param>
        /// <returns>
        /// Returns 200 OK if the update succeeds, or null if the airport was not found.
        /// </returns>
        [HttpPut("{airportId}")]
        public async Task<ActionResult> Update(int airportId, [FromBody] CreateAndUpdateAirportDTO dto)
        {
            var isUpdated = await _service.UpdateAsync(airportId, dto);
            return isUpdated == null ? null : Ok(isUpdated);
        }

        /// <summary>
        /// Deletes an existing airport record by its unique identifier.
        /// </summary>
        /// <param name="airportId">The unique identifier of the airport to delete.</param>
        /// <returns>
        /// Returns 200 OK if deletion succeeds, or <c>400 Bad Request</c> if it fails.
        /// </returns>
        [HttpDelete("{airportId}")]
        public async Task<ActionResult> Delete(int airportId)
        {
            var isDeleted = await _service.DeleteAsync(airportId);
            return isDeleted == null ? BadRequest() : Ok(isDeleted);
        }
    }
}
