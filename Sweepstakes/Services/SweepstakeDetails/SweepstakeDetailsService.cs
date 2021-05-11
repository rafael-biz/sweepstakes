using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes.Services.SweepstakeDetails
{
    public sealed class SweepstakeDetailsService
    {
        private readonly ISweepstakeRepository repository;

        public SweepstakeDetailsService(ISweepstakeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Returns a sweepstake details.
        /// </summary>
        public SweepstakeDetailsDTO Get(string sweepstakeId)
        {
            Sweepstake sweepstake = repository.Get(sweepstakeId);

            return new SweepstakeDetailsDTO()
            {
                Id = sweepstake.Id,
                Name = sweepstake.Name,
                Description = sweepstake.Description,
                DrawDate = sweepstake.DrawDate,
                DrawnDate = sweepstake.DrawnDate,
                Entrants = sweepstake.Entrants?.Select(e => new EntrantDetailsDTO()
                {
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone
                }).ToList(),
                Winner = sweepstake.Winner == null ? null : new EntrantDetailsDTO()
                {
                    Name = sweepstake.Winner.Name,
                    Email = sweepstake.Winner.Email,
                    Phone = sweepstake.Winner.Phone
                }
            };
        }
    }
}
