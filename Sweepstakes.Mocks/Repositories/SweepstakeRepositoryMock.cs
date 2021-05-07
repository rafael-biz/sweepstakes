using Sweepstakes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sweepstakes.Repositories
{
    public sealed class SweepstakeRepositoryMock : ISweepstakeRepository
    {
        private readonly Dictionary<string, Sweepstake> data = new Dictionary<string, Sweepstake>();

        public void Insert(Sweepstake sweepstake)
        {
            data.Add(sweepstake.Id, sweepstake.Clone());
        }

        public IEnumerable<Sweepstake> GetAll()
        {
            foreach (var sweepstake in data.Values.OrderByDescending(s => s.DrawDate))
            {
                yield return sweepstake.Clone();
            }
        }

        public Sweepstake Get(string sweepstakeId)
        {
            if (!data.ContainsKey(sweepstakeId))
                return null;

            return data[sweepstakeId].Clone();
        }

        public void Update(Sweepstake sweepstake)
        {
            data[sweepstake.Id] = sweepstake.Clone();
        }
    }
}
