using System;
using System.Threading.Tasks;
using VesselManager.Domain.DTO;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Domain.Interfaces.Services;

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
        public async Task<EquipamentRequestReturn> InsertEquipament(string vesselCode, Equipament equipament)
        {
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode);
            equipament.vessel = vessel;

            equipament.status = true;
            var result = new EquipamentRequestReturn();

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
