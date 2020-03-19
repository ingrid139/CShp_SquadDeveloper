using System;
using System.Collections.Generic;
using System.Text;

namespace SquadDev.Exceptions
{
    public class SquadNotFoundException : Exception
    {
        public SquadNotFoundException()
        {
        }

        public SquadNotFoundException(string message)
            : base(message)
        {
        }

        public SquadNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
