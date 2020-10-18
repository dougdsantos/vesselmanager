using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Infra.Context;
using System.Linq;
using System.Collections.Generic;
using System;

namespace VesselManager.Infra.Repository
{
    public class EquipamentRepository : Repository<Equipament>, IEquipamentRepository
    {
        private DbSet<Equipament> _dataset;

        public EquipamentRepository(BdContext context) : base(context)
        {
            _dataset = context.Set<Equipament>();
        }

        public async Task<List<Equipament>> GetEquipamentsByVesselCode(string code)
        {
            var equipaments = await _dataset.Where(e => e.vessel.code == code).ToListAsync();
            return equipaments;
        }

        public async Task<Equipament> InsertEquipamentAsync(Equipament equipament)
        {
            _dataset.Add(equipament);
            await _context.SaveChangesAsync();
            return equipament;
        }

        public async Task<List<Equipament>> InsertEquipamentAsync(List<Equipament> equipament)
        {
            var equipaments = (
                from e in equipament
                select new Equipament()
                {
                    Id = Guid.NewGuid(),
                    vessel = e.vessel,
                    code = e.code,
                    name = e.name,
                    location = e.location,
                    status = true
                }).ToList();
            _dataset.AddRange(equipaments);
            await _context.SaveChangesAsync();
            return equipaments;
        }

        public async Task<bool> SearchForVessel(Equipament equipament)
        {
            var result = await _dataset.FirstOrDefaultAsync(e =>
            e.code == equipament.code &&
            e.vessel.code == equipament.vessel.code);

            return result == null;
        }
    }
}
