using System;
using NASA.Mars.Shared.ComplexTypes;

namespace NASA.Mars.Domain
{
    public class Position
    {
        private int x;
        private int y;
        private readonly Directions _directions;

        public Position(string position)
        {
            if (string.IsNullOrEmpty(position) || string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position can not be null or empty");
            }

            string[] parts = position.Split(" ");
            if (parts.Length < 3)
            {
                throw new ArgumentException("Position not matches with X Y H");
            }

            int x = 0;
            if (!int.TryParse(parts[0], out x))
            {
                throw new ArgumentException("Position not matches with X Y H");
            }

            int y = 0;
            if (!int.TryParse(parts[1], out y))
            {
                throw new ArgumentException("Position not matches with X Y H");
            }

            this.x = x;
            this.y = y;

            this._directions = new Directions(parts[2]);
        }

        public void Rotate90LeftSide()
        {
            switch (this._directions.GetCurrenctDirection())
            {
                case Direction.NORTH:
                    this._directions.SetDirection(Direction.WEST);
                    break;
                case Direction.WEST:
                    this._directions.SetDirection(Direction.SOUTH);
                    break;
                case Direction.SOUTH:
                    this._directions.SetDirection(Direction.EAST);
                    break;
                case Direction.EAST:
                    this._directions.SetDirection(Direction.NORTH);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Rotate90RightSide()
        {
            switch (this._directions.GetCurrenctDirection())
            {
                case Direction.NORTH:
                    this._directions.SetDirection(Direction.EAST);
                    break;
                case Direction.WEST:
                    this._directions.SetDirection(Direction.NORTH);
                    break;
                case Direction.SOUTH:
                    this._directions.SetDirection(Direction.WEST);
                    break;
                case Direction.EAST:
                    this._directions.SetDirection(Direction.SOUTH);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public void MoveForward()
        {
            switch (this._directions.GetCurrenctDirection())
            {
                case Direction.NORTH:
                    y++;
                    break;
                case Direction.WEST:
                    x--;
                    break;
                case Direction.SOUTH:
                    y--;
                    break;
                case Direction.EAST:
                    x++;
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }

        public bool IsOnPlateau(Plateau p)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }

            if (x < 0 || x > p.dimX)
            {
                return false;
            }

            if (y < 0 || y > p.dimY)
            {
                return false;
            }

            return true;
        }


        public bool Equals(Position comparePosition)
        {
            return x == comparePosition.x && y == comparePosition.y;
        }

        public string GetPositionCurrentStatus()
        {
            return this.x + " " + this.y + " " + this._directions.GetCurrenctDirection().ToString().Substring(0, 1);
        }
    }
}