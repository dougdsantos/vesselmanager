using System.Threading.Tasks;
using VesselManager.Domain.DTO;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces.Services
{
    public interface IVesselService
    {
        Task<VesselRequestReturn> Insert(Vessel vessel);
    }
}
