using RobotGeneratorWizard.Database;
using RobotGeneratorWizard.Enums;
using RobotGeneratorWizard.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.RobotModel
{
    public class SingleParameterRobotModel : IRobotModelsHandler
    {
        IList<Parameter> parameters;

        string applicationType;

        public SingleParameterRobotModel(IList<Parameter> parameters, string applicationType)
        {
            this.parameters = parameters;
            this.applicationType = applicationType;
        }

        public DataTable GetChosenRobotModels()
        {
            DataTable allRobotModels, chosenRobotModels;

            try
            {
                allRobotModels = GetAllRobotModels();
            }
            catch (SqlException exception)
            {
                //logowanie
                return null;
            }

            chosenRobotModels = GetChosenModels(allRobotModels);

            return chosenRobotModels;
        }

        private DataTable GetChosenModels(DataTable allRobotModels)
        {
            DataTable chosenRobotModels;
            if (parameters[0].ParameterType == ParameterType.AxisNumber)
            {
                chosenRobotModels = allRobotModels.Copy();
            }
            else
            {
                if (parameters[0].ParameterType == ParameterType.Payload)
                {
                    RemoveNullRowsFromTableForSpecificParameter(allRobotModels, "Payload");
                    chosenRobotModels = GetChosenRobotModelsUsingSimilarity(allRobotModels, "Payload");
                }
                else
                {
                    RemoveNullRowsFromTableForSpecificParameter(allRobotModels, "Reach");
                    chosenRobotModels = GetChosenRobotModelsUsingSimilarity(allRobotModels, "Reach");
                }
            }

            return chosenRobotModels;
        }

        private DataTable GetChosenRobotModelsUsingSimilarity(DataTable allRobotModels, string parameterType)
        {
            DataTable expectedTable, aggregateTable;
            DataRow closestRow;
            var expectedRows = allRobotModels.AsEnumerable().Where(row => row.Field<dynamic>(parameterType) == parameters[0].ParameterValue);
            if (expectedRows.Count() != 0)
            {
                expectedTable = expectedRows.CopyToDataTable();
            }
            else
            {
                expectedTable = allRobotModels.Clone();
            }

            var aggregateRows = allRobotModels.AsEnumerable().Where(row => row.Field<dynamic>(parameterType) > parameters[0].ParameterValue);

            if (aggregateRows.Count() != 0)
            {
                aggregateTable = aggregateRows.CopyToDataTable();

                closestRow = aggregateTable.AsEnumerable().Aggregate((x, y) => Math.Abs(x.Field<dynamic>(parameterType) - parameters[0].ParameterValue) < Math.Abs(y.Field<dynamic>(parameterType) - parameters[0].ParameterValue) ? x : y);

                if (expectedTable.Rows.Count == 0)
                {
                    expectedTable.Rows.Add(closestRow.ItemArray);

                    aggregateTable.Rows.Remove(closestRow);
                    if (aggregateTable.Rows.Count != 0)
                    {
                        closestRow = aggregateTable.AsEnumerable().Aggregate((x, y) => Math.Abs(x.Field<dynamic>(parameterType) - parameters[0].ParameterValue) < Math.Abs(y.Field<dynamic>(parameterType) - parameters[0].ParameterValue) ? x : y);

                        expectedTable.Rows.Add(closestRow.ItemArray);
                    }
                }
                else
                {
                    expectedTable.Rows.Add(closestRow.ItemArray);
                }
            }

            return expectedTable;
        }

        private DataTable GetAllRobotModels()
        {
            Dictionary<string, object> storedProcedureParameters = new Dictionary<string, object>();
            if (parameters[0].ParameterType == ParameterType.AxisNumber)
            {
                storedProcedureParameters.Add("@ApplicationType", applicationType);
                storedProcedureParameters.Add("@NumberOfAxis", parameters[0].ParameterValue);
                return DatabaseMethods.GetDataFromDatabase("GetModelsBasedOnApplicationTypeAndNumberOfAxis", CommandType.StoredProcedure, storedProcedureParameters);
            }
            else
            {
                storedProcedureParameters.Add("@ApplicationType", applicationType);
                return DatabaseMethods.GetDataFromDatabase("GetModelsBasedOnApplicationType", CommandType.StoredProcedure, storedProcedureParameters);
            }
        }

        private void RemoveNullRowsFromTableForSpecificParameter(DataTable table, string parameterName)
        {
            var rowsWithoutNulls = table.AsEnumerable().Where(t => !double.IsNaN((t.Field<dynamic>(parameterName) is DBNull ? double.NaN : t.Field<dynamic>(parameterName))));

            if (rowsWithoutNulls.Count() > 0)
            {
                table = rowsWithoutNulls.CopyToDataTable();
            }
            else
            {
                table.Clear();
            }
        }
    }
}
