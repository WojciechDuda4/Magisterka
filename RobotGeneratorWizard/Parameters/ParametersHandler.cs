using RobotGeneratorWizard.Enums;
using RobotGeneratorWizard.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotGeneratorWizard.Parameters
{
    public class ParametersHandler
    {
        IList<TextBox> parametersTextBoxes;

        public ParametersHandler(IList<TextBox> parametersTextBoxes)
        {
            this.parametersTextBoxes = parametersTextBoxes;
        }

        public RobotModelType GetRobotModelType()
        {
            int numberOfCheckedParameters = 0;

            foreach (TextBox textBox in parametersTextBoxes)
            {
                if (textBox.Enabled)
                {
                    numberOfCheckedParameters++;
                }
            }

            return GetRobotModelTypeBasedOnNumberOfCheckedParameters(numberOfCheckedParameters);
        }

        public IList<Parameter> GetParameters()
        {
            ParameterType parameterType;
            double parameterValue;
            Parameter parameter;
            IList<Parameter> parameters = new List<Parameter>();

            foreach (TextBox textBox in parametersTextBoxes)
            {
                if (textBox.Enabled)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        RaiseParameterTextBoxNotFilledExceptionWithCorrectMessage(textBox);
                    }
                    else
                    {
                        parameterType = GetParameterType(textBox);

                        if (!Double.TryParse(textBox.Text.Replace(',', '.'), out parameterValue))
                        {
                            RaiseParameterTextBoxInvalidValueWithCorrectMessage(textBox);
                        }

                        parameter = new Parameter(parameterType, parameterValue);
                        parameters.Add(parameter);
                    }
                }
            }

            return parameters;
        }

        private ParameterType GetParameterType(TextBox parameterTextBox)
        {
            ParameterType parameterType;

            if (parameterTextBox.Name == "txtNumberOfAxis")
            {
                parameterType = ParameterType.AxisNumber;
            }
            else if (parameterTextBox.Name == "txtPayload")
            {
                parameterType = ParameterType.Payload;
            }
            else
            {
                parameterType = ParameterType.Reach;
            }

            return parameterType;
        }

        private void RaiseParameterTextBoxInvalidValueWithCorrectMessage(TextBox parameterTextBox)
        {
            if (parameterTextBox.Name == "txtNumberOfAxis")
            {
                throw new ParameterTextBoxInvalidValue("Błędna wartość pola z liczbą osi.");
            }
            else if (parameterTextBox.Name == "txtReach")
            {
                throw new ParameterTextBoxInvalidValue("Błędna wartość pola z zasięgiem");
            }
            else if (parameterTextBox.Name == "txtPayload")
            {
                throw new ParameterTextBoxInvalidValue("Błędna wartość pola z obciążeniem.");
            }
        }

        private void RaiseParameterTextBoxNotFilledExceptionWithCorrectMessage(TextBox parameterTextBox)
        {
            if (parameterTextBox.Name == "txtNumberOfAxis")
            {
                throw new ParameterTextBoxNotFilledException("Proszę wypełnić pole z liczbą osi.");
            }
            else if (parameterTextBox.Name == "txtReach")
            {
                throw new ParameterTextBoxNotFilledException("Proszę wypełnić pole z zasięgiem");
            }
            else if (parameterTextBox.Name == "txtPayload")
            {
                throw new ParameterTextBoxNotFilledException("Proszę wypełnić pole z obciążeniem.");
            }
        }

        private RobotModelType GetRobotModelTypeBasedOnNumberOfCheckedParameters(int numberOfCheckedParameters)
        {
            RobotModelType robotModelType = RobotModelType.Invalid;
            switch (numberOfCheckedParameters)
            {
                case 0:
                    robotModelType = RobotModelType.Invalid;
                    break;
                case 1:
                    robotModelType = RobotModelType.SingleParameter;
                    break;
                case 2:
                    robotModelType = RobotModelType.TwoParameters;
                    break;
                case 3:
                    robotModelType = RobotModelType.ThreeParameters;
                    break;
            }

            return robotModelType;
        }
    }
}
