using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces
{
    public interface IVesselRepository : IRepository<Vessel>
    {
        Task<Vessel> GetVesselByCode(string code);
    }
}
