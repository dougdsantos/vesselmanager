using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces.Services
{
    public interface IVesselService
    {
        Task<Vessel> Get(string code);
        Task<Vessel> Insert(Vessel vessel);
    }
}
