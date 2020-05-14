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
                .AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IAdvisorService, AdvisorService>()
                .AddTransient<IPatientService, PatientService>();
        }
    }
}
