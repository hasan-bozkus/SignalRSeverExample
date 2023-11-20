using Microsoft.AspNetCore.SignalR;
using SignalRSeverExample.Hubs;
using System.Threading.Tasks;

namespace SignalRSeverExample.Businnes
{
    public class myBusinnes
    {
        readonly IHubContext<MyHub> _hubContext;

        public myBusinnes(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            //Ekstra işlemler...
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);

        }
    }
}
