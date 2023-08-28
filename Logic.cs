using loadtestapi.Factory;
using loadtestapi.Models;
using Microsoft.Extensions.Options;

namespace loadtestapi
{
    public class Logic
    {
        public List<Result> GetResult(int partnerId,IDatabase database, string ConnectionString)
        {
            return database.Fetch(partnerId,ConnectionString);
        }
    }
}
