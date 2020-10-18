using System;
using System.Threading.Tasks;
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
        public async Task<Equipament> InsertEquipament(string vesselCode, Equipament equipament)
        {
            var vessel = await _vesselRepository.GetVesselByCode(vesselCode);
            equipament.vessel = vessel;

            equipament.status = true;

            if (await _equipamentRepository.SearchForVessel(equipament))
            {
                return await _equipamentRepository.InsertEquipamentAsync(equipament);
            }

            return null;
        }
    }
}
