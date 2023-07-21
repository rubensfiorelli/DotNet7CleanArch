using Microsoft.EntityFrameworkCore;
using TravelNet.Data.DataContext;
using TravelNet.Domain.Entities;
using TravelNet.Domain.Interfaces;

namespace TravelNet.Data.RepositoyGeneric
{
    public class BaseRpository<T> : IRepositoryGeneric<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _values;

        public BaseRpository(ApplicationDbContext context)
        {
            _context = context;
            _values = context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var seek = await _values.SingleOrDefaultAsync(s => s.Id.Equals(id));
                if (seek is null)
                    return false;

                _values.Remove(seek);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;

        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _values.Add(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _values.SingleOrDefaultAsync(s => s.Id.Equals(id));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var seek = await _values.SingleOrDefaultAsync(s => s.Id.Equals(item.Id));
                if (seek is null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = seek.CreateAt;

                _context.Entry(seek).CurrentValues.SetValues(seek);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return item;
        }
    }
}
