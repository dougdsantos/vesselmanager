using System.Collections.Generic;
using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces
{
    public interface IEquipamentRepository : IRepository<Equipament>
    {
        Task<Equipament> InsertEquipamentAsync(Equipament equipament);
        Task<bool> SearchForVessel(Equipament equipament);
        Task<List<Equipament>> InsertEquipamentAsync(List<Equipament> equipament);
    }
}
