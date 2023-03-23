using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Udemy.ToDoNTier.Business.Interfaces;
using Udemy.ToDoNTier.Business.Mappings.AutoMapper;
using Udemy.ToDoNTier.Business.Services;
using Udemy.ToDoNTier.Business.ValidationRules;
using Udemy.ToDoNTier.DataAccess.Context;
using Udemy.ToDoNTier.DataAccess.UnitOfWork;
using Udemy.ToDoNTier.Dtos.WorkDtos;

namespace Udemy.ToDoNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=TodoApp; User=INNOVA\ydogan; Trusted_Connection=True;");
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>,WorkCreateValidatorDto>();
            services.AddTransient<IValidator<WorkUpdateDto>,WorkUpdateValidatorDto>();
        }
    }
}
