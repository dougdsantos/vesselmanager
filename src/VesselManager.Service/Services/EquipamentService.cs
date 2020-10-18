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
    public class EquipamentService : IEquipamentService
    {
        private IVesselRepository _vesselRepository;
        private IEquipamentRepository _equipamentRepository;

        public EquipamentService(
            IVesselRepository vesselRepository,
            IEquipamentRepository equipamentRepository)
        {
            _vesselRepository = vesselRepository;
            _equipamentRepository = equipamentRepository;
        }

        public async Task<EquipamentRequestReturn> DesactiveEquipaments(string vesselCode, List<Equipament> equipaments)
        {
            var result = new EquipamentRequestReturn();
            var equipamentsInVessel = await _equipamentRepository.GetEquipamentsByVesselCode(vesselCode.ToUpper());
            var currentCodes = (from e in equipamentsInVessel select e.code).ToList();

            var codesInList = (from e in equipaments select currentCodes.Contains(e.code)).ToList();
            if (codesInList.Contains(false))
            {
                result.status = "Error";
                result.message = "Vessel don't have the specific equipaments.";
                return result;
            }

            var itens = equipamentsInVessel.Where(c => equipaments.Any(u => u.code == c.code)).ToList();
            itens = itens.Select(c => { c.status = false; return c; }).ToList();
            var rs = await _equipamentRepository.Update(vesselCode, itens);
            return result;
        }

        public async Task<List<Equipament>> GetAllActiveEquipamentsByVessel(string vesselCode)
        {
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode.ToUpper());
            if (vessel == null)
            {
                return null;
            }

            var equipamentsInVessel = await _equipamentRepository.GetEquipamentsByVesselCode(vesselCode);
            return equipamentsInVessel.Where(e => e.status == true).ToList();
        }

        public async Task<EquipamentRequestReturn> InsertEquipament(string vesselCode, Equipament equipament)
        {
            var result = new EquipamentRequestReturn();
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode);
            if (vessel == null)
            {
                result.status = "Error";
                result.message = "Vessel not Registred";
                result.equipaments.Add(equipament.code);
                return result;
            }
            equipament.vessel = vessel;

            equipament.status = true;

            if (await _equipamentRepository.SearchForVessel(equipament))
            {
                var nEquipament = await _equipamentRepository.InsertEquipamentAsync(equipament);

                result.status = "Ok";
                result.message = "Equipament Registred";
                result.equipaments.Add(nEquipament.code);
                return result;
            }

            result.status = "Error";
            result.message = "Equipament not Registred";
            result.equipaments.Add(equipament.code);
            return result;
        }
    }
}
