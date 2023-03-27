using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Repositories;
using ToDoGame.Domain.Validation;

namespace ToDoGame.Repository.DependencyInjection
{
    public static class DependencyInjectionRepository
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IRepository<UserProfile>, Repository<UserProfile>>();
            services.AddScoped<IRepository<Mission>, Repository<Mission>>();
            services.AddScoped<ISpecialRepository<Category>, SpecialRepository<Category>>();
            services.AddScoped<ISpecialRepository<Level>, SpecialRepository<Level>>();
            services.AddScoped<IValidator<UserProfile>, UserProfileValidator>();
            services.AddScoped<IValidator<Mission>, MissionValidator>();



        }

    }
}

