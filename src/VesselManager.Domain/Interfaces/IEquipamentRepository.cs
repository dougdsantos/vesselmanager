using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces
{
    public interface IEquipamentRepository : IRepository<Equipament>
    {
        Task<Equipament> InsertEquipamentAsync(Equipament equipament);
    }
}
