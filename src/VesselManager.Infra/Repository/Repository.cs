using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Domain.Interfaces;
using VesselManager.Infra.Context;

namespace VesselManager.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly BdContext _context;
        private DbSet<T> _dataset;
        public Repository(BdContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                    _dataset.Add(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
