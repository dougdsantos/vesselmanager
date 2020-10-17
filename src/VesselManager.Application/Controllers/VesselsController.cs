using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces.Services;

namespace VesselManager.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> InsertVessel([FromBody] Vessel body, [FromServices] IVesselService vesselService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await vesselService.Insert(body));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
