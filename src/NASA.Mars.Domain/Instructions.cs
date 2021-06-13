using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NASA.Mars.Shared;
using NASA.Mars.Shared.ComplexTypes;
using NASA.Mars.Shared.Exceptions;

namespace NASA.Mars.Domain
{
    public class Instructions
    {
        private readonly Instruction[] _instructions;
        public Instructions(string instructions)
        {
            if (string.IsNullOrEmpty(instructions) || string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Instructions can not be null or empty");
            }
            

            List<Instruction> result = new List<Instruction>();

            foreach (char i in instructions.ToCharArray())
            {
                switch (i)
                {
                    case 'L':
                        result.Add(Instruction.LEFT);
                        break;
                    case 'M':
                        result.Add(Instruction.MOVE);
                        break;
                    case 'R':
                        result.Add(Instruction.RIGHT);
                        break;
                    default:
                        throw new InvalidInstructionException(i.ToString());
                }
            }

            _instructions = result.ToArray();
        }

        public Instruction[] GetInstructions()
        {
            return _instructions;
        }
    }
}
