using Sweepstakes.Entities;
using Sweepstakes.Repositories;

namespace Sweepstakes.Services.SweepstakeEnter
{
    public sealed class SweepstakeEnterService
    {
        private readonly ISweepstakeRepository repository;

        public SweepstakeEnterService(ISweepstakeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Enter on a sweepstake.
        /// </summary>
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
