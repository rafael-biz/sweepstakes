using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Services.SweepstakeCreate
{
    public sealed class SweepstakeCreateDTO
    {
        /// <summary>
        /// Sweepstake's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sweepstake's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Draw date.
        /// </summary>
        public DateTime DrawDate { get; set; }
    }
}
