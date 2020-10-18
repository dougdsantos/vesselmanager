using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Infra.Context;
using System.Linq;

namespace VesselManager.Infra.Repository
{
    public class EquipamentRepository : Repository<Equipament>, IEquipamentRepository
    {
        private DbSet<Equipament> _dataset;

        public EquipamentRepository(BdContext context) : base(context)
        {
            _dataset = context.Set<Equipament>();
        }
        public async Task<Equipament> InsertEquipamentAsync(Equipament equipament)
        {
            _dataset.Add(equipament);
            await _context.SaveChangesAsync();
            return equipament;
        }

        public async Task<bool> SearchForVessel(Equipament equipament)
        {
            var result = await _dataset.FirstOrDefaultAsync(e => e.code == equipament.code);
            return result == null;
        }
    }
}
