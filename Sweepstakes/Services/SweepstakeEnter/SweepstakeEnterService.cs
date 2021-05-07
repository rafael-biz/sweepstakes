using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Services.SweepstakeEnter
{
    public sealed class SweepstakeEnterService
    {
        private readonly ISweepstakeRepository repository;

        public SweepstakeEnterService(ISweepstakeRepository repository)
        {
            this.repository = repository;
        }

        public void AddEntrant(string sweepstakeId, EntrantDTO dto)
        {
            Sweepstake entrance = repository.Get(sweepstakeId);

            entrance.Entrants.Add(new Entrant()
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            });

            repository.Update(entrance);
        }
    }
}
