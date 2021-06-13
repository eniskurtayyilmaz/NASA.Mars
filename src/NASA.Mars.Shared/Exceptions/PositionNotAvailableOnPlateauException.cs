using System;

namespace NASA.Mars.Shared.Exceptions
{
    public class PositionNotAvailableOnPlateauException : Exception
    {
        public PositionNotAvailableOnPlateauException(string message) : base(message)
        {
        }
    }
}