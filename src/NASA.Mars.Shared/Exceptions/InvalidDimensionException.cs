using System;

namespace NASA.Mars.Shared.Exceptions
{
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException(string dimensions) : base(String.Format("Invalid Dimension: {0}", dimensions))
        {

        }
    }
}