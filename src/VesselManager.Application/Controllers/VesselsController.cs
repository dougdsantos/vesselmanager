using System;
using System.Collections.Generic;
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

            if (equipament.status == "Error")
            {
                return BadRequest(equipament);
            }

            return Ok(equipament);
        }

        [HttpGet]
        [Route("{vesselCode}/equipaments", Name = "GetEquipamentsWithVessel")]
        public async Task<ActionResult> GetEquipament(string vesselCode, [FromServices] IEquipamentService equipamentService)
        {
            var equipament = await equipamentService.GetAllActiveEquipamentsByVessel(vesselCode);

            if (equipament == null)
            {
                return BadRequest("Vessel don't have active equipaments");
            }

            return Ok(equipament);
        }

        [HttpPut]
        [Route("{vessel}/equipaments", Name = "UpdateEquipamentsWithVessel")]
        public async Task<ActionResult> UpdateStatus(string vessel, [FromBody] List<Equipament> body, [FromServices] IEquipamentService equipamentService)
        {
            var equipaments = await equipamentService.DesactiveEquipaments(vessel, body);

            if (equipaments.status == "Error")
            {
                return BadRequest(equipaments);
            }

            return Ok(equipaments);
        }
    }
}
