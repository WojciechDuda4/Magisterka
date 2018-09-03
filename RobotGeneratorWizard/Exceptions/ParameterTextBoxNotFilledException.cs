using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.Exceptions
{
    public class ParameterTextBoxNotFilledException : Exception
    {
        public ParameterTextBoxNotFilledException()
        {
        }

        public ParameterTextBoxNotFilledException(string message)
            : base(message)
        {
        }

        public ParameterTextBoxNotFilledException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
