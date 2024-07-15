using Microsoft.AspNetCore.Mvc;

namespace HealthCheckApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private static int _healthCheckCount = 0;
        private static readonly object _lock = new object();

        [HttpGet]
        public IActionResult Get()
        {
            lock (_lock)
            {
                _healthCheckCount++;
                if (_healthCheckCount % 20 == 0)
                {
                    return Ok("Nok");
                }
                return Ok("ok");
            }
        }
    }
}



