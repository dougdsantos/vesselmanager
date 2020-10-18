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
