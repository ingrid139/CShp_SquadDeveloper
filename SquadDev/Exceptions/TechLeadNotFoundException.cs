using System;
using System.Collections.Generic;
using System.Text;

namespace SquadDev.Exceptions
{
    public class TechLeadNotFoundException : Exception
    {
        public TechLeadNotFoundException()
        {
        }

        public TechLeadNotFoundException(string message)
            : base(message)
        {
        }

        public TechLeadNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
