using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Infra.Context;

namespace VesselManager.Infra.Repository
{
    public class VesselRepository : Repository<Vessel>, IVesselRepository
    {
        private DbSet<Vessel> _dataset;
        public VesselRepository(BdContext context) : base(context)
        {
            _dataset = context.Set<Vessel>();
        }

        public async Task<Vessel> GetVesselByCode(string code)
        {
            var vessel = await _dataset.SingleOrDefaultAsync(v => v.code == code);
            if (vessel == null)
            {
                throw new Exception("Vessel not registred");
            }
            return vessel;
        }
    }
}
