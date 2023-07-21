using TravelNet.Domain.Entities;

namespace TravelNet.Domain.Interfaces.Repositories
{
    public interface IRepositoryGeneric<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<ICollection<T>> List();
    }
}
