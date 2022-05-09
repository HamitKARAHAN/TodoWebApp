using Example.TodoWebApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Data.UnitofWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChanges();
    }
}
