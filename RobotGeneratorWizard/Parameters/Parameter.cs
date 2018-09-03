using RobotGeneratorWizard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.Parameters
{
    public class Parameter
    {
        public ParameterType ParameterType { get; private set; }

        public double ParameterValue { get; private set; }

        public Parameter(ParameterType parameterType, double parameterValue)
        {
            ParameterType = parameterType;
            ParameterValue = parameterValue;
        }
    }
}
