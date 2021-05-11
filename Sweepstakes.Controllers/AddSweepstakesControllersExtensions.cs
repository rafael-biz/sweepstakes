using Microsoft.Extensions.DependencyInjection;
using Sweepstakes.Controllers;
using Sweepstakes.Controllers.Draws;
using Sweepstakes.Controllers.Notifications;

namespace Sweepstakes
{
    public static class AddSweepstakesControllersExtensions
    {
        /// <summary>
        /// Adds mocks to the service collection instead of actual implementations.
        /// </summary>
        public static IServiceCollection AddSweepstakesControllers(this IServiceCollection services)
        {
            services.AddTransient<ISweepstakeNotificationController, SweepstakeNotificationController>();

            services.AddHostedService<DrawsController>();

            return services;
        }
    }
}
