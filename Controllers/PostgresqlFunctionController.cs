using loadtestapi.Factory;
using loadtestapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace loadtestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostgresqlFunctionController : ControllerBase
    {        
        private readonly ILogger<PostgresqlFunctionController> _logger;
        private readonly ConnectionSettings connectionSettings;

        public PostgresqlFunctionController(ILogger<PostgresqlFunctionController> logger, IOptions<ConnectionSettings> options)
        {
            _logger = logger;
            connectionSettings = options.Value;
        }

        [HttpGet(Name = "GetPostgreSQLFunctionsData")]
        public IEnumerable<Result> Get(int partnerId = 535272)
        {
            var logic = new Logic();
            return logic.GetResult(partnerId, new PostgreSQLFunctionDatabase(), connectionSettings.postgres);
        }
    }
}