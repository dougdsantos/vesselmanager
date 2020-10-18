using System.Collections.Generic;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.DTO
{
    public class EquipmentRequestReturn : BaseRequestReturn
    {
        public List<string> equipments { get; set; } = new List<string>();
    }
}
