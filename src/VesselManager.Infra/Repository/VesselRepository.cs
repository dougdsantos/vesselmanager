using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Infra.Context;
using System.Linq;

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

            return vessel;
        }
    }
}
