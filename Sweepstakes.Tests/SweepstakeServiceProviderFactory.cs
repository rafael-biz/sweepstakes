using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sweepstakes.Tests
{
    /// <summary>
    /// An IServiceProvider factory for unit tests.
    /// </summary>
    public static class SweepstakeServiceProviderFactory
    {
        /// <summary>
        /// Creates an IServiceProvider containing the business services with the mock of the repositories and controllers. 
        /// </summary>
        public static IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddSweepstakesServices();
            services.AddSweepstakesMocks();

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }
}
