using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.AircraftDTOs;
using Airplane_UI.DTOs.AirlineCore.AirlineDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    /// <summary>
    /// API controller responsible for handling airline-related operations.
    /// Provides endpoints for creating, retrieving, updating, and deleting airline records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        
        private readonly IAirlineService _service;

        /// <summary>
        /// Initializes a new instance of the AirlineController class.
        /// </summary>
        /// <param name="service">The service responsible for airline data management.</param>
        public AirlineController(IAirlineService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all airlinerecords.
        /// </summary>
        /// <returns>
        /// Returns 200 OK if successful.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var airlines = await _service.GetAllAsync();
            return Ok(airlines);
        }

        /// <summary>
        /// Retrieves a specific airline by its unique identifier.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to retrieve.</param>
        /// <returns>
        /// Returns 200 OK if found; otherwise, may return 404 Not Found.
        /// </returns>
        [HttpGet("{airlineId}")]
        public async Task<ActionResult<GetAirlineDTO>> GetById(int airlineId)
        {
            var airline = await _service.GetByIdAsync(airlineId);
            if (airline == null)
            {
                return NotFound();
            }
            return Ok(airline);
        }

        /// <summary>
        /// Creates a new airline record.
        /// </summary>
        /// <param name="dto">The dto containing the airline details to create.</param>
        /// <returns>
        /// Returns 200 OK if creation is successful.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<GetAirlineDTO>> Create([FromBody] CreateAndUpdateAirlineDTO dto)
        {
            var createdAirline = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { airlineId = createdAirline.Id }, createdAirline);
        }

        /// <summary>
        /// Updates an existing airline record.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to update.</param>
        /// <param name="dto">The dto containing updated airline information.</param>
        /// <returns>
        /// Returns 200 OK if the update succeeds, or null if the airline was not found.
        /// </returns>
        [HttpPut("{airlineId}")]
        public async Task<ActionResult<GetAirlineDTO>> Update(int airlineId, [FromBody] CreateAndUpdateAirlineDTO dto)
        {
            var updatedAirline = await _service.UpdateAsync(airlineId, dto);
            if(updatedAirline == null)
            {
                return NotFound();
            }
            return Ok(updatedAirline);
        }

        /// <summary>
        /// Deletes an existing airline record by its unique identifier.
        /// </summary>
        /// <param name="airlineId">The unique identifier of the airline to delete.</param>
        /// <returns>
        /// Returns 200 OK if deletion succeeds, or 400 Bad Request if it fails.
        /// </returns>
        [HttpDelete("{airlineId}")]
        public async Task<ActionResult> Delete(int airlineId)
        {
            var result = await _service.DeleteAsync(airlineId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
