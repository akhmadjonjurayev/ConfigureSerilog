using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerFactory factory)
        {
            _logger = logger;
            //_logger = factory.CreateLogger("DemoCategory");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogError("error field", DateTime.Now);
            _logger.LogInformation("working weatherforecast", DateTime.Now);
            _logger.LogDebug("debuging", DateTime.Now);
            _logger.LogTrace("log trace", DateTime.Now);
            _logger.LogCritical("log critical", DateTime.Now);
            _logger.BeginScope(new WeatherForecast());
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
//https://gist.github.com/koldev/d439741099a6a120a261
