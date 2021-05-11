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
        /// Draw local date and time with timezone offset or adjusted in UTC time.
        /// </summary>
        public DateTime DrawDate { get; set; }
    }
}
