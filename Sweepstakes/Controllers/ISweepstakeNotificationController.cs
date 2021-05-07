using Sweepstakes.Entities;

namespace Sweepstakes.Controllers
{
    public interface ISweepstakeNotificationController
    {
        void Notify(Sweepstake sweepstake);
    }
}
