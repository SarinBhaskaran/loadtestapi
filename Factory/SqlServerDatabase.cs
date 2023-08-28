using loadtestapi.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Npgsql;

namespace loadtestapi.Factory
{
    public class SqlServerDatabase : IDatabase
    {

        public List<Result> Fetch(int partnerId,string ConnectionString)
        {
            List<Result> result = new List<Result>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();


                SqlCommand command = new SqlCommand("usp_objectaccesspartnergrouplist", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter o = new SqlParameter();
                o.ParameterName = "@PartnerId";
                o.DbType = DbType.Int32;
                o.Direction = ParameterDirection.Input;
                o.Value = partnerId;//191290
                command.Parameters.Add(o);


                using (var dr = command.ExecuteReader())
                {
                    result = dr.MapToList<Result>();
                }

                connection.Close();

            }
            return result;
        }
    }


}
