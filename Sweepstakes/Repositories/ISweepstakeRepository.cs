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
    }
}
