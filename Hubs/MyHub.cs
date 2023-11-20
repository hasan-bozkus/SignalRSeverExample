using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRSeverExample.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string message)
        {
            //Ekstra işlemler...
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
