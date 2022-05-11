using AutoMapper;
using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Bussiness.Mapping;
using Example.TodoWebApp.Bussiness.Services;
using Example.TodoWebApp.Bussiness.Validation;
using Example.TodoWebApp.Data.Context;
using Example.TodoWebApp.Data.UnitofWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example.TodoWebApp.Bussiness.DependencyResolvers.Microsoft
{
    public static class BussinessModule
    {
        public static IServiceCollection AddBussinessModule(this IServiceCollection services)
        {
            services
                .AddDIModule()
                .AddDbModule()
                .AddAutoMapperModule()
                .AddFluentValidationModule();

            return services;
        }

        private static IServiceCollection AddDIModule(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IWorkService, WorkService>();

            return services;
        }

        private static IServiceCollection AddDbModule(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(options =>
            {
                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security=true;");
            });

            return services;
        }

        private static IServiceCollection AddAutoMapperModule(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static IServiceCollection AddFluentValidationModule(this IServiceCollection services)
        {
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
            return services;
        }
    }
}
