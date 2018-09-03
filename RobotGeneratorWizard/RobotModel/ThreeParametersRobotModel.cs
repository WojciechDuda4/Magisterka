using RobotGeneratorWizard.Database;
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
    public class ThreeParametersRobotModel : IRobotModelsHandler
    {
        IList<Parameter> parameters;

        Parameter payload, reach;

        string applicationType;

        public ThreeParametersRobotModel(IList<Parameter> parameters, string applicationType)
        {
            this.parameters = parameters;
            this.applicationType = applicationType;
            payload = parameters.Where(t => t.ParameterType == Enums.ParameterType.Payload).First();
            reach = parameters.Where(t => t.ParameterType == Enums.ParameterType.Reach).First();
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
            DataTable expectedTable, workTable;

            DataColumn similarityColumn = new DataColumn("Similarity", typeof(double));
            allRobotModels.Columns.Add(similarityColumn);

            var expectedParametersRobotModelsRows = allRobotModels.AsEnumerable().Where(row => row.Field<double>("Reach") == reach.ParameterValue
                                                                                                && row.Field<int>("Payload") == payload.ParameterValue);
            if (expectedParametersRobotModelsRows.Count() == 0)
            {
                expectedTable = allRobotModels.Clone();
            }
            else
            {
                expectedTable = expectedParametersRobotModelsRows.CopyToDataTable();
            }

            expectedParametersRobotModelsRows = allRobotModels.AsEnumerable().Where(row => row.Field<double>("Reach") > reach.ParameterValue
                                                                                                && row.Field<int>("Payload") > payload.ParameterValue);

            if (expectedParametersRobotModelsRows.Count() != 0)
            {
                workTable = expectedParametersRobotModelsRows.CopyToDataTable();

                foreach (DataRow row in workTable.Rows)
                {
                    row["Similarity"] = Math.Sqrt(Math.Pow(Convert.ToDouble(row["Reach"]) - reach.ParameterValue, 2) + Math.Pow(Convert.ToDouble(row["Payload"]) - payload.ParameterValue, 2));
                }
                if (expectedTable.Rows.Count > 0)
                {
                    DataRow rowsWithLowestSimilarity = workTable.AsEnumerable().OrderBy(t => t.Field<double>("Similarity")).First();
                    expectedTable.Rows.Add(rowsWithLowestSimilarity.ItemArray);
                }
                else
                {
                    var rowsWithLowestSimilarity = workTable.AsEnumerable().OrderBy(t => t.Field<double>("Similarity")).Take(2);
                    foreach (DataRow row in rowsWithLowestSimilarity)
                    {
                        expectedTable.Rows.Add(row.ItemArray);
                    }
                }
            }

            return expectedTable;
        }

        private DataTable GetAllRobotModels()
        {
            return DatabaseMethods.GetDataFromDatabase("GetModelsBasedOnApplicationTypeAndNumberOfAxis", CommandType.StoredProcedure, GetStoredProcedureParameters());
        }

        private Dictionary<string, object> GetStoredProcedureParameters()
        {
            Dictionary<string, object> storedProcedureParameters = new Dictionary<string, object>();
            Parameter numberOfAxisParameter = parameters.Where(t => t.ParameterType == Enums.ParameterType.AxisNumber).First();

            storedProcedureParameters.Add("@ApplicationType", applicationType);
            storedProcedureParameters.Add("@NumberOfAxis", numberOfAxisParameter.ParameterValue);

            return storedProcedureParameters;
        }

        private void RemoveNullRowsFromTableForSpecificParameters(DataTable table)
        {
            var rowsWithoutNulls = table.AsEnumerable().Where(t => !double.IsNaN(t.Field<dynamic>("Reach") is DBNull ? double.NaN : t.Field<dynamic>("Reach"))
                                                                    && !double.IsNaN(t.Field<dynamic>("Payload") is DBNull ? double.NaN : t.Field<dynamic>("Payload")));

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
