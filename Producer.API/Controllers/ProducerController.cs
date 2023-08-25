using Microsoft.AspNetCore.Mvc;
using Producer.API.Models;
using Producer.API.Services.Interfaces;

namespace Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly ILogger<ProducerController> _logger;
        private readonly IMessageProducer _messageProducer;

        public ProducerController(ILogger<ProducerController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult PostMessage(Message simple)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _messageProducer.SendMessage(simple);
            return Ok();
        }

    }
}

