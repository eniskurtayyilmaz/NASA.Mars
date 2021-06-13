using System;

namespace NASA.Mars.Shared.Exceptions
{
    public class InvalidDimensionConvertException : Exception
    {
        public InvalidDimensionConvertException(string dimensions) : base(String.Format("Invalid Dimension Convert: {0}", dimensions))
        {

        }
    }
}