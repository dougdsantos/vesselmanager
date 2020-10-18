using System;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.DTO
{
    public class VesselRequestReturn : BaseRequestReturn
    {
        public string code { get; set; }

        public VesselRequestReturn ByVessel(Vessel vessel)
        {
            if (vessel.Id == Guid.Empty)
            {
                status = "Error";
                message = "Vessel not registred.";
            }
            else
            {
                status = "Ok";
                message = "Vessel registred.";
            }
            code = vessel.code;

            return this;
        }
    }
}
