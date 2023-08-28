using loadtestapi.Models;

namespace loadtestapi.Factory
{
    public interface IDatabase
    {
        List<Result> Fetch(int partnerId,string connectionString);
    }
}
