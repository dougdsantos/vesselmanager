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
            var vessel = await vesselService.Insert(body);
            if (vessel.status == "Error")
            {
                return BadRequest(vessel);
            }
            return Ok(vessel);
        }

        [HttpPost]
        [Route("{code}/equipaments", Name = "InsertEquipamentWithCodeVessel")]
        public async Task<ActionResult> InsertEquipament(string code, [FromBody] Equipament body, [FromServices] IEquipamentService equipamentService)
        {
            var equipament = await equipamentService.InsertEquipament(code, body);

            if (equipament == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Equipment already registered.");
            }

            return Ok(equipament);
        }
    }
}
