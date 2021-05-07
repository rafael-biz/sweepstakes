using Sweepstakes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Repositories
{
    public interface ISweepstakeRepository
    {
        /// <summary>
        /// Creates a Sweepstake.
        /// </summary>
        /// <param name="sweepstake"></param>
        void Insert(Sweepstake sweepstake);

        /// <summary>
        /// Returns all sweepstake
        /// </summary>
        /// <returns></returns>
        IEnumerable<Sweepstake> GetAll();

        /// <summary>
        /// Returns a sweepstake. Otherwise, retuns null.
        /// </summary>
        /// <param name="sweepstakeId">
        /// Sweepstake id.
        /// </param>
        Sweepstake Get(string sweepstakeId);

        /// <summary>
        /// Updates a sweepstake.
        /// </summary>
        /// <param name="sweepstake"></param>
        void Update(Sweepstake sweepstake);
    }
}
