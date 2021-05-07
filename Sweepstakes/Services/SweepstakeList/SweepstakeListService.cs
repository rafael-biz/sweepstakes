using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Sweepstakes.Repositories;
using Sweepstakes.Entities;

namespace Sweepstakes.Services.SweepstakeList
{
    public sealed class SweepstakeListService
    {
        private readonly ISweepstakeRepository repository;

        public SweepstakeListService(ISweepstakeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Returns all sweepstakes.
        /// </summary>
        public IEnumerable<SweepstakeListDTO> GetAll()
        {
            IEnumerable<Sweepstake> sweepstakes = repository.GetAll();
            foreach (var sweepstake in sweepstakes)
            {
                yield return new SweepstakeListDTO()
                {
                    Id = sweepstake.Id,
                    Name = sweepstake.Name,
                    Description = sweepstake.Description,
                    DrawDate = sweepstake.DrawDate
                };
            }
        }
    }
}
