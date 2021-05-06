using Sweepstakes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Repositories
{
    public interface ISweepstakeRepository
    {
        void Insert(Sweepstake sweepstake);
    }
}
