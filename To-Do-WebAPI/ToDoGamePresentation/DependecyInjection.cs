using AutoMapper;
using ToDoGame.Repository;
using ToDoGame.Service.DependencyInjection;

namespace PersonService
{
    public static class DependecyInjection
    {
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddRepositoryServices();
        }

        public static void AddMappers(this IServiceCollection services)
        {
            var profiles = typeof(DependecyInjection).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            var userProfileServices = typeof(ToDoGame.Service.UserProfileService).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            var missionServiceProfiles = typeof(ToDoGame.Service.MissionService).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            var coreProfiles = typeof(ApplicationDbContext).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            var allProfiles = profiles.Concat(userProfileServices).Concat(coreProfiles);

            services.AddScoped(x =>
            {
                var configuration = new MapperConfiguration(configuration =>
                {
                    foreach (var profile in allProfiles)
                    {
                        configuration.AddProfile(ActivatorUtilities.CreateInstance(x, profile) as Profile);
                    }
                });

#if DEBUG
                configuration.AssertConfigurationIsValid();
#endif
                return configuration.CreateMapper();
            });
        }
    }
}
