using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;

namespace Sweepstakes.Services.SweepstakeDraw
{
    public sealed class SweepstakeDrawService
    {
        private static readonly Random random = new Random();

        private readonly ISweepstakeRepository repository;

        public SweepstakeDrawService(ISweepstakeRepository repository)
        {
            this.repository = repository;
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

            return winner;
        }
    }
}
