using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSeverExample.Businnes;
using SignalRSeverExample.Hubs;
using System.Threading.Tasks;

namespace SignalRSeverExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly myBusinnes _myBusinnes;
        readonly IHubContext<MyHub> _hubContext;

        public HomeController(myBusinnes myBusinnes, IHubContext<MyHub> hubContext)
        {
            _myBusinnes = myBusinnes;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusinnes.SendMessageAsync(message);
            return Ok();
        }
    }
}
