using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.DTOs.AirlineCore.FlightManifestDTOS;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.AirlineCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightManifestController : ControllerBase
    {
        private readonly IFlightManifestService _service;

        /// <summary>
        /// Initializes a new instance of the flightManifest Controller class.
        /// </summary>
        /// <param name="service">The service responsible for flightManifest data management.</param>
        public FlightManifestController(IFlightManifestService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all flightManifest records.
        /// </summary>
        /// <returns> Returns 200 OK if successful. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific flightManifest by its unique identifier.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flightManifest to retrieve.</param>
        /// <returns> Returns 200 OK if found; otherwise, may return 404 Not Found.</returns>
        [HttpGet("{flightManifestId}")]
        public async Task<IActionResult> GetById(int flightManifestId)
        {
            var result = await _service.GetByIdAsync(flightManifestId);

            return Ok(result);
        }

        /// <summary>
        /// Creates a new flightManifest record.
        /// </summary>
        /// <param name="dto">The dto containing the flightManifest details to create.</param>
        /// <returns> Returns 200 OK if creation is successful. </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAndUpdateFlightManifestDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing flightManifest record.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flightManifest to update.</param>
        /// <param name="dto">The dto containing updated flightManifest information.</param>
        /// <returns> Returns 200 OK if the update succeeds, or null if the flightManifest was not found.</returns>
        [HttpPut("{flightManifestId}")]
        public async Task<IActionResult> UpdateAsync(int flightManifestId, [FromBody] CreateAndUpdateFlightManifestDTO dto)
        {
            var result = await _service.UpdateAsync(flightManifestId, dto);

            return Ok(result);
        }

        /// <summary>
        /// Deletes an existing flightManifest record by its unique identifier.
        /// </summary>
        /// <param name="flightManifestId">The unique identifier of the flightManifest to delete.</param>
        /// <returns> Returns 200 OK if deletion succeeds, or 400 Bad Request if it fails.</returns>
        [HttpDelete("{flightManifestId}")]
        public async Task<IActionResult> DeleteAsync(int flightManifestId)
        {
            var isDeleted = await _service.DeleteAsync(flightManifestId);

            return isDeleted == null ? BadRequest() : Ok(isDeleted);
        }
    }
}
