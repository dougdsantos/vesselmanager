using System.Threading.Tasks;
using VesselManager.Domain.Entities;

namespace VesselManager.Domain.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        Task<T> InsertAsync(T item);
    }
}
