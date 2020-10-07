using System;

namespace SquadDev.Exceptions
{
    public class DevNotFoundException :  Exception
    {
        public DevNotFoundException()
        {
        }

        public DevNotFoundException(string message)
            : base(message)
        {
        }

        public DevNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
