using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Bussiness.Services;
using Example.TodoWebApp.Data.Context;
using Example.TodoWebApp.Data.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.TodoWebApp.Bussiness.DependencyResolvers.Microsoft
{
    public static class BussinessModule
    {
        public static void AddBussinessModule(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddDbContext<TodoContext>(options =>
            {
                options.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security=true;");
            });
        }
    }
}
