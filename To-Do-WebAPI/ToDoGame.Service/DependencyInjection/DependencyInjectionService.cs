using Microsoft.Extensions.DependencyInjection;
using ToDoGame.Repository.DependencyInjection;
using ToDoGame.Service.Interfaces;

namespace ToDoGame.Service.DependencyInjection
{
    public static class DependencyInjectionService
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IMissionService, MissionService>();

            services.AddDomainServices();
        }
    }
}
