using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Entities
{
    public sealed class Entrant
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
