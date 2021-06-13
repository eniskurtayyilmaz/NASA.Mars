using System;
using NASA.Mars.Shared.ComplexTypes;
using NASA.Mars.Shared.Exceptions;

namespace NASA.Mars.Domain
{
    public class Rover
    {
        private readonly string _tagName;
        private readonly Plateau _plateau;
        private Position _position;
        private readonly Instructions _instructions;

        public Rover(string tagName, Plateau plateau, Position position, Instructions instructions)
        {
            if (string.IsNullOrWhiteSpace(tagName) || string.IsNullOrEmpty(tagName))
            {
                throw new ArgumentException("Tagname can not be null or empty");
            }

            ArgumentPlateauNullCheck(plateau);
            ArgumentPositionNullCheck(position);
            ArgumentInstructionsNullCheck(instructions);

            _tagName = tagName;
            _plateau = plateau;
            _position = position;
            _instructions = instructions;
        }

        private void ArgumentPlateauNullCheck(Plateau plateau)
        {
            if (plateau == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ArgumentInstructionsNullCheck(Instructions instructions)
        {
            if (instructions == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ArgumentPositionNullCheck(Position position)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }
        }

        public string GetTagName()
        {
            return _tagName;
        }

        public void RunInstructions()
        {
            foreach (var instruction in _instructions.GetInstructions())
            {
                switch (instruction)
                {
                    case Instruction.LEFT:
                        _position.Rotate90LeftSide();
                        break;
                    case Instruction.RIGHT:
                        _position.Rotate90RightSide();
                        break;
                    case Instruction.MOVE:

                        if (!_position.IsOnPlateau(_plateau))
                        {
                            throw new PositionNotAvailableOnPlateauException("No space left on plateau");
                        }

                        _position.MoveForward();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string GetRoverCurrentStatus()
        {
            return _position.GetPositionCurrentStatus();
        }
    }
}