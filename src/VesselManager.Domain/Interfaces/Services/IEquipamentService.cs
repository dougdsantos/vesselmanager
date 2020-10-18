using System.Threading.Tasks;
using VesselManager.Domain.DTO;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces.Services
{
    public interface IEquipamentService
    {
        Task<EquipamentRequestReturn> InsertEquipament(string vesselCode, Equipament equipament);
    }
}
