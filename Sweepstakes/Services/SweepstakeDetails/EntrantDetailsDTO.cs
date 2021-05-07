using System;

namespace Sweepstakes.Services.SweepstakeDetails
{
    public sealed class EntrantDetailsDTO
    {
        /// <summary>
        /// Entrant name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; set; }
    }
}