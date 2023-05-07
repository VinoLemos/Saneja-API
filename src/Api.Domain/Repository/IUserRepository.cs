using Api.Domain.Entities;

public interface IUserRepository<T> where T : User
{
    Task<T> InsertAsync(T item);
    Task<T> SelectAsync(Guid id);
    Task<IEnumerable<T>> SelectAsync();
    Task<bool> ExistsAsync(Guid id);
    Task<T> UpdateAsync(T item);
    Task<bool> DeleteAsync(Guid id);
}
