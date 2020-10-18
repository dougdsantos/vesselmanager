using System.Threading.Tasks;
using VesselManager.Domain.DTO;
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
        public async Task<VesselRequestReturn> Insert(Vessel vessel)
        {
            vessel.code = vessel.code.ToUpper();
            var result = await _repository.InsertAsync(vessel);
            return result == null ?
            new VesselRequestReturn().ByVessel(vessel) :
            new VesselRequestReturn().ByVessel(result);
        }
    }
}
