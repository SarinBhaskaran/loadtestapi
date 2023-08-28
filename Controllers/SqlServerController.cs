using loadtestapi.Factory;
using loadtestapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace loadtestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlServerController : ControllerBase
    {
        private readonly ILogger<SqlServerController> _logger;
        private readonly ConnectionSettings connectionSettings;

        public SqlServerController(ILogger<SqlServerController> logger, IOptions<ConnectionSettings> options)
        {
            _logger = logger;
            connectionSettings = options.Value;
        }

        [HttpGet(Name = "GetSqlServerData")]
        public IEnumerable<Result> Get(int partnerId= 191290)
        {
            var logic = new Logic();
            return logic.GetResult(partnerId,new SqlServerDatabase(), connectionSettings.sqlserver);
        }
    }
}