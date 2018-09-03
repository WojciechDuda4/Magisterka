using RobotGeneratorWizard.Enums;
using RobotGeneratorWizard.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.RobotModel
{
    public static class RobotModelFactory
    {
        public static IRobotModelsHandler GetRobotModelHandler(RobotModelType robotModelType, IList<Parameter> parameters, string applicationType)
        {
            IRobotModelsHandler robotModelHandler = null;

            switch (robotModelType)
            {
                case RobotModelType.Invalid:
                    robotModelHandler = null;
                    break;
                case RobotModelType.SingleParameter:
                    robotModelHandler = new SingleParameterRobotModel(parameters, applicationType);
                    break;
                case RobotModelType.TwoParameters:
                    robotModelHandler = new TwoParametersRobotModel(parameters, applicationType);
                    break;
                case RobotModelType.ThreeParameters:
                    robotModelHandler = new ThreeParametersRobotModel(parameters, applicationType);
                    break;
            }

            return robotModelHandler;
        }
    }
}
