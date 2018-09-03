using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGeneratorWizard.Database
{
    public static class DatabaseMethods
    {
        static string _connectionString
        {
            get
            {
                return "Data Source=DESKTOP-JRDA1QJ\\MAGISTERKA;Initial Catalog=RobotsGeneratorDb;Integrated Security=SSPI";
            }
        }

        public static DataTable GetDataFromDatabase(string query, CommandType commandType, Dictionary<string, object> parameters)
        {
            DataTable dataFromDatabase = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = commandType;

                        foreach (KeyValuePair<string, object> pair in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                        }

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        sqlDataAdapter.Fill(dataFromDatabase);
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }

            return dataFromDatabase;
        }

        public static int InvokeNonQueryProcedure(string query, CommandType type, Dictionary<string, object> parameters)
        {
            int modifiedRowsCount = -1;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = type;

                        foreach (KeyValuePair<string, object> pair in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                        }

                        modifiedRowsCount = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            return modifiedRowsCount;
        }
    }
}
