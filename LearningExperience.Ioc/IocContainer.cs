using LearningExperience.Repository;
using LearningExperience.Repository.Interfaces;
using LearningExperience.Repository.MongoDB;
using LearningExperience.Services;
using LearningExperience.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

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
                .AddScoped(typeof(IUserRepository), typeof(UserRepository))
                .AddScoped(typeof(IUserProgressRepository), typeof(UserProgressRepository))
                .AddScoped(typeof(IGameLevelImageRepository), typeof(GameLevelImageRepository));
                
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IAdvisorService, AdvisorService>()
                .AddTransient<IPatientService, PatientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IGameLevelService, GameLevelService>();
               
        }
    }
}
