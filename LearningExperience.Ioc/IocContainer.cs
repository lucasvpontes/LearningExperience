using LearningExperience.Repository;
using LearningExperience.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningExperience.Ioc
{
    public static class IocContainer
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>))
                .AddScoped(typeof(IAdvisorRepository), typeof(AdvisorRepository))
                .AddScoped(typeof(IPatientRepository), typeof(PatientRepository))
                .AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IAdvisorService, AdvisorService>()
                .AddTransient<IPatientService, PatientService>()
                .AddTransient<IUserService, UserService>();
        }

    }
}
