using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.Exceptions
{
    public class ParameterTextBoxInvalidValue : Exception
    {
            public ParameterTextBoxInvalidValue()
        {
        }

        public ParameterTextBoxInvalidValue(string message)
            : base(message)
        {
        }

        public ParameterTextBoxInvalidValue(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
