using System.Collections.Generic;

namespace VesselManager.Domain.Entities
{
    public class Vessel : Base
    {
        public string code { get; set; }
        public List<Equipament> equipaments { get; set; }
    }
}
