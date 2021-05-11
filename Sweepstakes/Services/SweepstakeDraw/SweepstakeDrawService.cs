using Sweepstakes.Controllers;
using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;
using System.Collections.Generic;

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
        /// Returns all sweepstakes that need to be drawn.
        /// </summary>
        public IEnumerable<Sweepstake> GetPenddingDraws()
        {
            var sweepstakes = repository.GetAll();

            foreach (var sweepstake in sweepstakes)
            {
                if (sweepstake.DrawnDate == null)
                {
                    yield return sweepstake;
                }
            }
        }

        /// <summary>
        /// Draws a winner.
        /// </summary>
        /// <returns>
        /// Returns null if there is no entrants.
        /// </returns>
        public Entrant Draw(string sweepstakeId)
        {
            Sweepstake sweepstake = repository.Get(sweepstakeId);

            if (sweepstake.Entrants.Count > 0)
            {
                int index = random.Next(sweepstake.Entrants.Count);

                Entrant winner = sweepstake.Entrants[index];

                sweepstake.Winner = winner;
            }

            sweepstake.DrawnDate = DateTime.Now;

            repository.Update(sweepstake);

            notificationController.Notify(sweepstake);

            return sweepstake.Winner;
        }
    }
}
