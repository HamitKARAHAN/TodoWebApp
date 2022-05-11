using Example.TodoWebApp.Data.Context;
using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.Interfaces;
using Example.TodoWebApp.Data.Repositories;

namespace Example.TodoWebApp.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly TodoContext _context;

        public UnitofWork(
                TodoContext context
            )
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
