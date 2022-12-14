using System.Linq.Expressions;

namespace Projeto_SaneJa.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> predicate);
        T GetByEmail(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetByCpf(Expression<Func<T, bool>> predicate);
        T GetByRgi(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}