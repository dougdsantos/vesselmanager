using System.Collections.Generic;

namespace VesselManager.Domain.Entities
{
    public class Vessel : Base
    {
        public List<Equipament> equipaments { get; set; }
    }
}
