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
        [Route("{code}/equipments", Name = "InsertEquipmentWithCodeVessel")]
        public async Task<ActionResult> Insertequipment(string code, [FromBody] Equipment body, [FromServices] IEquipmentService equipmentService)
        {
            var equipment = await equipmentService.InsertEquipment(code, body);

            if (equipment.status == "Error")
            {
                return BadRequest(equipment);
            }

            return Ok(equipment);
        }

        [HttpGet]
        [Route("{vesselCode}/equipments", Name = "GetEquipmentsWithVessel")]
        public async Task<ActionResult> Getequipment(string vesselCode, [FromServices] IEquipmentService equipmentService)
        {
            var equipment = await equipmentService.GetAllActiveEquipmentsByVessel(vesselCode);

            if (equipment == null)
            {
                return BadRequest("Vessel don't have active equipments");
            }

            return Ok(equipment);
        }

        [HttpPut]
        [Route("{vessel}/equipments", Name = "UpdateEquipmentsWithVessel")]
        public async Task<ActionResult> UpdateStatus(string vessel, [FromBody] List<Equipment> body, [FromServices] IEquipmentService equipmentService)
        {
            var equipments = await equipmentService.DesactiveEquipments(vessel, body);

            if (equipments.status == "Error")
            {
                return BadRequest(equipments);
            }

            return Ok(equipments);
        }
    }
}
