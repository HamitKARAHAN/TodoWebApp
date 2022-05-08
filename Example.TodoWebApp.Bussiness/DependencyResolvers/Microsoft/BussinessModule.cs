using Example.TodoWebApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Bussiness.DependencyResolvers.Microsoft
{
    public static class BussinessModule
    {
        public static void AddBussinessModule(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(options =>
            {
                options.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security=true;");
            });
        }
    }
}
