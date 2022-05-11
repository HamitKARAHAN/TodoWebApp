using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.Interfaces;

namespace Example.TodoWebApp.Data.UnitofWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}
