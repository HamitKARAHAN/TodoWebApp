using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Bussiness.Services;
using Example.TodoWebApp.Data.Context;
using Example.TodoWebApp.Data.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security=true;");
            });
        }
    }
}
