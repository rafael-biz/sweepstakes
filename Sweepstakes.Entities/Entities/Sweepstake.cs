using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Entities
{
    public sealed class Sweepstake
    {
        /// <summary>
        /// An unique identifier.
        /// </summary>
        public string Id { get; set; }

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
