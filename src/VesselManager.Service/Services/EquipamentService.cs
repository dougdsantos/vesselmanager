using System.Threading.Tasks;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Domain.Interfaces.Services;

namespace VesselManager.Service.Services
{
    public class EquipamentService : IEquipamentService
    {
        private IRepository<Vessel> _vesselRepository;
        private IEquipamentRepository _equipamentRepository;

        public EquipamentService(
            IRepository<Vessel> vesselRepository,
            IEquipamentRepository equipamentRepository)
        {
            _vesselRepository = vesselRepository;
            _equipamentRepository = equipamentRepository;
        }
        public async Task<Equipament> InsertEquipament(Equipament equipament)
        {
            var vessel = await _vesselRepository.GetFromCode(equipament.vessel.code);
            equipament.vessel = vessel;

            return await _equipamentRepository.InsertEquipamentAsync(equipament);
        }
    }
}
