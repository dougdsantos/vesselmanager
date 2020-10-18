using System.Collections.Generic;
using System.Threading.Tasks;
using VesselManager.Domain.DTO;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces.Services
{
    public interface IEquipmentService
    {
        Task<EquipmentRequestReturn> InsertEquipment(string vesselCode, Equipment equipment);
        Task<List<Equipment>> GetAllActiveEquipmentsByVessel(string vesselCode);
        Task<EquipmentRequestReturn> DesactiveEquipments(string vesselCode, List<Equipment> equipments);
    }
}
