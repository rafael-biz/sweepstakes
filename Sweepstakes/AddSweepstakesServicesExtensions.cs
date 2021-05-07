using Microsoft.Extensions.DependencyInjection;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeDetails;
using Sweepstakes.Services.SweepstakeDraw;
using Sweepstakes.Services.SweepstakeEnter;
using Sweepstakes.Services.SweepstakeList;

namespace Sweepstakes
{
    public static class AddSweepstakesServicesExtensions
    {
        /// <summary>
        /// Adds business services to the service collection.
        /// </summary>
        public static IServiceCollection AddSweepstakesServices(this IServiceCollection services)
        {
            services.AddTransient<SweepstakeCreateService>();

            services.AddTransient<SweepstakeDetailsService>();

            services.AddTransient<SweepstakeDrawService>();

            services.AddTransient<SweepstakeEnterService>();

            services.AddTransient<SweepstakeListService>();

            return services;
        }
    }
}
