using System;

namespace NASA.Mars.Shared.Exceptions
{
    public class InvalidDirectionException : Exception
    {
        public InvalidDirectionException(string direction) : base(String.Format("Invalid Direction: {0}", direction))
        {

        }
    }

}