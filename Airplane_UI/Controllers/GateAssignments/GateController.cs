using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.DTOs.GateAssignments.GateDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airplane_UI.Controllers.GateAssignments
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IGateService _service;
        public GateController(IGateService service)
        {
            _service = service;
        }

        // GetAll
        [HttpGet]
        public async Task<ActionResult<GetGateDTO>> GetAll()
        {
            var gates = await _service.GetAllAsync();
            if(!ModelState.IsValid) 
            return Ok(gates);
        }
        // GetDetails
        // GetById
        // Create
        // Update
        // Delete
    }
}
