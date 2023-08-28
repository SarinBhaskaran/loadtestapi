using Dapper;
using loadtestapi.Models;
using Microsoft.AspNetCore.Http;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace loadtestapi.Factory
{
    public class PostgreSQLDatabase : IDatabase
    {
        public List<Result> Fetch(int partnerId, string ConnectionString)
        {
            List<Result> result = new List<Result>();

            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                NpgsqlTransaction tran = connection.BeginTransaction();

                NpgsqlCommand command = new NpgsqlCommand("usp_objectaccesspartnergrouplist", connection);
                command.CommandType = CommandType.StoredProcedure;
                NpgsqlParameter o = new NpgsqlParameter();
                o.ParameterName = "@p_partnerid";
                o.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o.Direction = ParameterDirection.Input;
                o.Value = partnerId; //535272
                command.Parameters.Add(o);

                NpgsqlParameter p = new NpgsqlParameter();
                p.ParameterName = "@cur";
                p.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Refcursor;
                p.Direction = ParameterDirection.InputOutput;
                p.Value = "cur";
                command.Parameters.Add(p);
                command.ExecuteNonQuery();

                command.CommandText = "fetch all in \"cur\"";
                command.CommandType = CommandType.Text;

                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    result = dr.MapToList<Result>();
                }

                tran.Commit();
                connection.Close();

            }
            return result;
        }

    }
}
