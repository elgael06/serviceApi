
using System.Linq.Expressions;

namespace serviceApi.interfaces
{
    public interface IRepository<T>: IDisposable where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAllById(string id);
        Task<T> GetOneById(string id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
        Task<T> Find(Expression<Func<T, bool>> express );
        IQueryable<T> Query(Expression<Func<T, bool>> where);
    }
}