using System;
using NASA.Mars.Shared.ComplexTypes;
using NASA.Mars.Shared.Exceptions;

namespace NASA.Mars.Domain
{
    public class Directions
    {
        private Direction _direction;

        public Directions(string direction)
        {
            SetDirection(direction);
        }

        public void SetDirection(string direction)
        {
            if (string.IsNullOrEmpty(direction) || string.IsNullOrWhiteSpace(direction))
            {
                throw new ArgumentException("Directions can not be null or empty");
            }

            switch (direction)
            {
                case "N":
                    _direction = Direction.NORTH;
                    break;
                case "W":
                    _direction = Direction.WEST;
                    break;
                case "S":
                    _direction = Direction.SOUTH;
                    break;
                case "E":
                    _direction = Direction.EAST;
                    break;
                default:
                    throw new InvalidDirectionException(direction);
            }
        }
        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        public Direction GetCurrenctDirection()
        {
            return _direction;
        }
    }
}