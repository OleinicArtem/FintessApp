using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FitnessClubApp
{
    public static class DataAccess
    {
        private static readonly string connectionString;

        // Статический конструктор для инициализации строки подключения
        static DataAccess()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["FitnessClubApp.Properties.Settings.TrainingConnectionString"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'FitnessClubApp.Properties.Settings.TrainingConnectionString' is not configured in the application configuration file.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to initialize connection string.", ex);
            }
        }

        // Публичное свойство для доступа к строке подключения
        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static DataTable GetDataTable(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
            }
        }

        public static void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}", ex);
                }
            }
        }

        public static int ExecuteNonQueryWithTransaction(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            if (parameters != null)
                            {
                                command.Parameters.AddRange(parameters);
                            }
                            int result = command.ExecuteNonQuery();
                            transaction.Commit();
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Transaction error: {ex.Message}", ex);
                }
            }
        }

        public static DataTable ExecuteStoredProcedure(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Stored procedure error: {ex.Message}", ex);
                }
            }
        }
    }
}