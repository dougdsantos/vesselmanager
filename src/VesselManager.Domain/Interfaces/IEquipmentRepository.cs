using System.Collections.Generic;
using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<Equipment> InsertEquipmentAsync(Equipment Equipment);
        Task<bool> SearchForVessel(Equipment Equipment);
        Task<List<Equipment>> InsertEquipmentAsync(List<Equipment> Equipment);
        Task<List<Equipment>> GetEquipmentsByVesselCode(string code);
        Task<List<Equipment>> Update(string vessel, List<Equipment> Equipment);
    }
}
