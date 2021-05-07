using Microsoft.Extensions.DependencyInjection;
using Sweepstakes.Controllers;
using Sweepstakes.Repositories;

namespace Sweepstakes
{
    public static class AddMocksExtensions
    {
        /// <summary>
        /// Adds mocks to the service collection instead of actual implementations.
        /// </summary>
        public static IServiceCollection AddSweepstakesMocks(this IServiceCollection services)
        {
            services.AddSingleton<ISweepstakeNotificationController, SweepstakeNotificationControllerMock>();

            services.AddSingleton<ISweepstakeRepository, SweepstakeRepositoryMock>();

            return services;
        }
    }
}
