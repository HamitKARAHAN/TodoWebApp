using Example.TodoWebApp.Data.Domains;
using System.Linq.Expressions;

namespace Example.TodoWebApp.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Find(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity, T unchanged);
        IQueryable<T> GetQuery();
    }
}
