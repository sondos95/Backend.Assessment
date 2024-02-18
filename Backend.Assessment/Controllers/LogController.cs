using Backend.Assessment.Application.Requests;
using Backend.Assessment.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Assessment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly ILogger _logger;
        public LogController(ILogger logger)
        {
            _logger = logger;   
        }

        [HttpPost]
        [Route("AddLog")]
        public IActionResult AddLog([FromBody] LogDto dto)
        {
            var msg = $"MESSAGE: {dto.Message} - " +
                      $"FILE: {dto.FileName} - " +
                      $"LEVEL: {dto.Level} - " +
                      $"TIMESTAMP: {dto.Timestamp:F}";
            _logger.LogError(msg);
            return Ok();
        }
    }
}
