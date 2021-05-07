using Sweepstakes.Controllers;
using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;

namespace Sweepstakes.Services.SweepstakeDraw
{
    public sealed class SweepstakeDrawService
    {
        private static readonly Random random = new Random();

        private readonly ISweepstakeRepository repository;

        private readonly ISweepstakeNotificationController notificationController;

        public SweepstakeDrawService(ISweepstakeRepository repository, ISweepstakeNotificationController notificationController)
        {
            this.repository = repository;
            this.notificationController = notificationController;
        }

        /// <summary>
        /// Draw a winner.
        /// </summary>
        public Entrant Draw(string sweepstakeId)
        {
            Sweepstake sweepstake = repository.Get(sweepstakeId);

            int index = random.Next(sweepstake.Entrants.Count);

            Entrant winner = sweepstake.Entrants[index];

            sweepstake.Winner = winner;

            repository.Update(sweepstake);

            notificationController.Notify(sweepstake);

            return winner;
        }
    }
}
