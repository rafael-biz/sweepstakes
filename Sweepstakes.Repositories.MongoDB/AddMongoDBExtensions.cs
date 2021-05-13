using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sweepstakes.Repositories;
using Sweepstakes.Repositories.MongoDB;

namespace Sweepstakes
{
    public static class AddMongoDBExtensions
    {
        /// <summary>
        /// Adds MongoDB repositories to the service collection.
        /// </summary>
        public static IServiceCollection AddMongoDBRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));

            services.AddTransient<ISweepstakeRepository, SweepstakeRepository>();

            EntityMapper.Map();

            return services;
        }
    }
}
