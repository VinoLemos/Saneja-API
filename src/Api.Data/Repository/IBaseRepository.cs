using Api.Domain.Entities;

namespace Api.Data.Repository
{
    public interface IBaseRepository<T>
    {
        public abstract Task<T> InsertAsync(T item);
        public abstract Task<T> SelectAsync(Guid id);
        public abstract Task<IEnumerable<T>> SelectAsync();
        public abstract void UpdateAsync(T item);
        public abstract Task<bool> DeleteAsync(Guid id);
        public abstract Task<bool> ExistsAsync(Guid id);
    }
}