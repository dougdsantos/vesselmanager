using System.Threading.Tasks;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Domain.Interfaces.Services;

namespace VesselManager.Service.Services
{
    public class VesselService : IVesselService
    {
        private IVesselRepository _repository;

        public VesselService(IVesselRepository repository)
        {
            _repository = repository;
        }
        public async Task<Vessel> Get(string code)
        {
            return await _repository.GetVesselByCode(code);
        }

        public async Task<Vessel> Insert(Vessel vessel)
        {
            vessel.code = vessel.code.ToUpper();
            return await _repository.InsertAsync(vessel);
        }
    }
}
