using Microsoft.AspNetCore.Mvc;

namespace loadtestapi.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet, HttpPut, HttpPost, HttpDelete, HttpPatch, Route("")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Get()
        {
            var message = $"XpoConnect Load Test API Version \"{GetType().Assembly.GetName().Version}\"";
            return Ok(message);
        }
    }
}
