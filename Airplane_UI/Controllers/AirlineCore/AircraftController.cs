using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    /// <summary>
    /// API controller responsible for handling airline-related operations.
    /// Provides endpoints for creating, retrieving, updating, and deleting airline records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _service;

        /// <summary>
        /// Initializes a new instance of the AirlineController class.
        /// </summary>
        /// <param name="service">The service responsible for airline data management.</param>
        public AircraftController(IAircraftService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all aircraftRecords.
        /// </summary>
        /// <returns> Returns 200 OK if successful. </returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var aircrafts = await _service.GetAllAsync();
            return Ok(aircrafts);
        }

        /// <summary>
        /// Retrieves a specific aircraft by its unique identifier.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to retrieve.</param>
        /// <returns> Returns 200 OK if found; otherwise, may return 404 Not Found. </returns>
        [HttpGet("{aircraftId}")]
        public async Task<ActionResult> GetById(int aircraftId)
        {
            var aircraft = await _service.GetByIdAsync(aircraftId);
            return Ok(aircraft);
        }

        /// <summary>
        /// Creates a new aircraft record.
        /// </summary>
        /// <param name="dto">The dto containing the aircraft details to create.</param>
        /// <returns> Returns 200 OK if creation is successful. </returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAndUpdateAircraftDTO dto)
        {
            var createdAircraft = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { aircraftId = createdAircraft.Id }, createdAircraft);
        }

        /// <summary>
        /// Updates an existing aircraft record.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to update.</param>
        /// <param name="dto">The dto containing updated aircraft information.</param>
        /// <returns> Returns 200 OK if the update succeeds, or null if the aircraft was not found.</returns>
        [HttpPut("{aircraftId}")]
        public async Task<ActionResult> Update(int aircraftId, [FromBody] CreateAndUpdateAircraftDTO dto)
        {
            var updatedAircraft = await _service.UpdateAsync(aircraftId, dto);
            return Ok(updatedAircraft);
        }

        /// <summary>
        /// Deletes an existing aircraft record by its unique identifier.
        /// </summary>
        /// <param name="aircraftId">The unique identifier of the aircraft to delete.</param>
        /// <returns> Returns 200 OK if deletion succeeds, or 400 Bad Request if it fails.</returns>
        [HttpDelete("{aircraftId}")]
        public async Task<ActionResult> Delete(int aircraftId)
        {
            var result = await _service.DeleteAsync(aircraftId);
            return Ok(result);
        }
    }
}
