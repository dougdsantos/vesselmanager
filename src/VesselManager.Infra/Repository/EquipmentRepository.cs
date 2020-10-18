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
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        private DbSet<Equipment> _dataset;

        public EquipmentRepository(BdContext context) : base(context)
        {
            _dataset = context.Set<Equipment>();
        }

        public async Task<List<Equipment>> GetEquipmentsByVesselCode(string code)
        {
            var equipaments = await _dataset.Where(e => e.vessel.code == code)
            .Include(e => e.vessel)
            .ToListAsync();
            return equipaments;
        }

        public async Task<Equipment> InsertEquipmentAsync(Equipment equipment)
        {
            _dataset.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<List<Equipment>> InsertEquipmentAsync(List<Equipment> equipment)
        {
            var equipments = (
                from e in equipment
                select new Equipment()
                {
                    Id = Guid.NewGuid(),
                    vessel = e.vessel,
                    code = e.code,
                    name = e.name,
                    location = e.location,
                    status = true
                }).ToList();
            _dataset.AddRange(equipments);
            await _context.SaveChangesAsync();
            return equipments;
        }

        public async Task<bool> SearchForVessel(Equipment equipament)
        {
            var result = await _dataset.FirstOrDefaultAsync(e =>
            e.code == equipament.code &&
            e.vessel.code == equipament.vessel.code);

            return result == null;
        }

        public async Task<List<Equipment>> Update(string vessel, List<Equipment> equipament)
        {
            foreach (var item in equipament)
            {
                _context.Entry(item).CurrentValues.SetValues(item);
            }
            await _context.SaveChangesAsync();
            return equipament;
        }
    }
}
