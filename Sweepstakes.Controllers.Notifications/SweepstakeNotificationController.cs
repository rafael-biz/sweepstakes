using Microsoft.Extensions.Logging;
using Sweepstakes.Entities;
using System;

namespace Sweepstakes.Controllers.Notifications
{
    public class SweepstakeNotificationController : ISweepstakeNotificationController
    {
        private readonly ILogger<SweepstakeNotificationController> logger;

        public SweepstakeNotificationController(ILogger<SweepstakeNotificationController> logger)
        {
            this.logger = logger;
        }

        public void Notify(Sweepstake sweepstake)
        {
            // This is just a mock. 

            logger.LogInformation($@"A notification email has been sent for { sweepstake.Name } sweepstake.");
        }
    }
}
