using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Shared.Exceptions
{
    public class InvalidInstructionException : Exception
    {
        public InvalidInstructionException(string insturction) : base(String.Format("Invalid Instruction: {0}", insturction))
        {

        }
    }
}
