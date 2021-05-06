using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;

namespace Sweepstakes.Services.SweepstakeCreate
{
    /// <summary>
    /// Creates a Sweepstake.
    /// </summary>
    public sealed class SweepstakeCreateService
    {
        private readonly ISweepstakeRepository repository;

        public SweepstakeCreateService(ISweepstakeRepository repository)
        {
            this.repository = repository;
        }

        public Sweepstake Create(SweepstakeCreateDTO dto)
        {
            var sweepstake = new Sweepstake()
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = dto.Name,
                Description = dto.Description,
                DrawDate = dto.DrawDate,
            };

            repository.Insert(sweepstake);

            return sweepstake;
        }
    }
}
