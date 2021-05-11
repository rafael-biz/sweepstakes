using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sweepstakes.Services.SweepstakeDraw;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweepstakes.Controllers.Draws
{
    /// <summary>
    /// Performs background work to draw the winners of the sweepstakes.
    /// </summary>
    public class DrawsController : BackgroundService
    {
        private readonly ILogger<DrawsController> logger;

        private readonly IServiceScopeFactory serviceScopeFactory;

        public DrawsController(ILogger<DrawsController> logger, IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting the draw service as a background worker.");

            while (!cancellationToken.IsCancellationRequested)
            {
                using (IServiceScope scope = serviceScopeFactory.CreateScope())
                {
                    try
                    {
                        var service = scope.ServiceProvider.GetRequiredService<SweepstakeDrawService>();

                        var sweepstakes = service.GetPenddingDraws();

                        foreach (var sweepstake in sweepstakes)
                        {
                            var winner = service.Draw(sweepstake.Id);

                            logger.LogInformation($@"Congratulations! { winner.Name } is the winner of the { sweepstake.Name } sweepstake.");
                        }
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "An exception occurred when drawing a winner.");
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }
    }
}
