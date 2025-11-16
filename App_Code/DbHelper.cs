using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public static class DbHelper
    {
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable ExecuteStoredProcToDataTable(string spName, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}