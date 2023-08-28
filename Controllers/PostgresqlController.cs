using loadtestapi.Factory;
using loadtestapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace loadtestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostgresqlController : ControllerBase
    {        
        private readonly ILogger<PostgresqlController> _logger;
        private readonly ConnectionSettings connectionSettings;

        public PostgresqlController(ILogger<PostgresqlController> logger, IOptions<ConnectionSettings> options)
        {
            _logger = logger;
            connectionSettings = options.Value;
        }

        [HttpGet(Name = "GetPostgreSQLData")]
        public IEnumerable<Result> Get(int partnerId = 535272)
        {
            var logic = new Logic();
            return logic.GetResult(partnerId, new PostgreSQLDatabase(), connectionSettings.postgres);
        }
    }
}