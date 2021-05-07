using System;
using System.Collections.Generic;

namespace Sweepstakes.Services.SweepstakeDetails
{
    public sealed class SweepstakeDetailsDTO
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

        /// <summary>
        /// List of entrants.
        /// </summary>
        public List<EntrantDetailsDTO> Entrants { get; set; }
    }
}