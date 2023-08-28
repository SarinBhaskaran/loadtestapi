using Dapper;
using loadtestapi.Models;
using Microsoft.AspNetCore.Http;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace loadtestapi.Factory
{
    public class PostgreSQLFunctionDatabase : IDatabase
    {
        public List<Result> Fetch(int partnerId, string ConnectionString)
        {
            List<Result> result = new List<Result>();

            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * from usp_objectaccesspartnergrouplistfunc(@p_partnerid);", connection);
                command.Parameters.AddWithValue("p_partnerid", partnerId);

                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    result = dr.MapToList<Result>();
                }

                connection.Close();

            }
            return result;
        }
    }
}
