using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces.Services
{
    public interface IEquipamentService
    {
        Task<Equipament> InsertEquipament(Equipament equipament);
    }
}
