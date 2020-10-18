using System.Collections.Generic;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.DTO
{
    public class EquipamentRequestReturn : BaseRequestReturn
    {
        public List<string> equipaments { get; set; } = new List<string>();
    }
}
