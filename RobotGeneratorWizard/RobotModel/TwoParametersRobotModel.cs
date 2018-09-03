using RobotGeneratorWizard.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.RobotModel
{
    public class TwoParametersRobotModel : IRobotModelsHandler
    {
        IList<Parameter> parameters;

        string applicationType;

        public TwoParametersRobotModel(IList<Parameter> parameters, string applicationType)
        {
            this.parameters = parameters;
            this.applicationType = applicationType;
        }

        public DataTable GetChosenRobotModels()
        {
            DataTable chosenRobotModels;
            bool hasNumberOfAxisParameter = parameters.Any(t => t.ParameterType == Enums.ParameterType.AxisNumber);

            if (hasNumberOfAxisParameter)
            {
                TwoParametersRobotModelWithNumberOfAxisParameter twoParametersRobotModelWithNumberOfAxisParameter = new TwoParametersRobotModelWithNumberOfAxisParameter(parameters, applicationType);
                chosenRobotModels = twoParametersRobotModelWithNumberOfAxisParameter.GetChosenRobotModels();
            }
            else
            {
                TwoParametersRobotModelWithReachAndPayload twoParametersRobotModelWithNumberOfAxisParameter = new TwoParametersRobotModelWithReachAndPayload(parameters, applicationType);
                chosenRobotModels = twoParametersRobotModelWithNumberOfAxisParameter.GetChosenRobotModels();
            }

            return chosenRobotModels;
        }
    }
}
