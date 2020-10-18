using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VesselManager.Domain.DTO;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Domain.Interfaces.Services;
using System.Linq;

namespace VesselManager.Service.Services
{
    public class EquipmentService : IEquipmentService
    {
        private IVesselRepository _vesselRepository;
        private IEquipmentRepository _equipamentRepository;

        public EquipmentService(
            IVesselRepository vesselRepository,
            IEquipmentRepository equipamentRepository)
        {
            _vesselRepository = vesselRepository;
            _equipamentRepository = equipamentRepository;
        }

        public async Task<EquipmentRequestReturn> DesactiveEquipments(string vesselCode, List<Equipment> equipments)
        {
            var result = new EquipmentRequestReturn();
            var equipamentsInVessel = await _equipamentRepository.GetEquipmentsByVesselCode(vesselCode.ToUpper());
            var currentCodes = (from e in equipamentsInVessel select e.code).ToList();

            var codesInList = (from e in equipments select currentCodes.Contains(e.code)).ToList();
            if (codesInList.Contains(false))
            {
                result.status = "Error";
                result.message = "Vessel don't have the specific equipments.";
                return result;
            }

            var itens = equipamentsInVessel.Where(c => equipments.Any(u => u.code == c.code)).ToList();
            itens = itens.Select(c => { c.status = false; return c; }).ToList();
            var rs = await _equipamentRepository.Update(vesselCode, itens);

            result.status = "Ok";
            result.message = "Vessel updated.";
            result.equipments = (from e in rs select e.code).ToList();
            return result;
        }

        public async Task<List<Equipment>> GetAllActiveEquipmentsByVessel(string vesselCode)
        {
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode.ToUpper());
            if (vessel == null)
            {
                return null;
            }

            var equipamentsInVessel = await _equipamentRepository.GetEquipmentsByVesselCode(vesselCode);
            return equipamentsInVessel.Where(e => e.status == true).ToList();
        }

        public async Task<EquipmentRequestReturn> InsertEquipment(string vesselCode, Equipment equipment)
        {
            var result = new EquipmentRequestReturn();
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode);
            if (vessel == null)
            {
                result.status = "Error";
                result.message = "Vessel not registered";
                result.equipments.Add(equipment.code);
                return result;
            }
            equipment.vessel = vessel;

            equipment.status = true;

            if (await _equipamentRepository.SearchForVessel(equipment))
            {
                var nEquipament = await _equipamentRepository.InsertEquipmentAsync(equipment);

                result.status = "Ok";
                result.message = "Equipment registered";
                result.equipments.Add(nEquipament.code);
                return result;
            }

            result.status = "Error";
            result.message = "Equipment not registered";
            result.equipments.Add(equipment.code);
            return result;
        }
    }
}
