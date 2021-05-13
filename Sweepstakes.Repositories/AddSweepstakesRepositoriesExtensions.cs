using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sweepstakes.Repositories;
using System;

namespace Sweepstakes
{
    public static class AddSweepstakesRepositoriesExtensions
    {
        /// <summary>
        /// Adds the repositories implementation.
        /// </summary>
        public static IServiceCollection AddSweepstakesRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDBRepository(configuration);

            return services;
        }
    }
}
