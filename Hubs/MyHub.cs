using Microsoft.AspNetCore.SignalR;
using SignalRSeverExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSeverExample.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();

        //public async Task SendMessageAsync(string message)
        //{
        //    //Ekstra işlemler...
        //    await Clients.All.SendAsync("receiveMessage", message);

        //}
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.userJoined(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.userLeaved(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}
// Connection ID: Hub'a bağlantı gerçekleştiren client'lara verilen unique/tekil bir değerdir. Amacı, client'ları birbirinden ayırmaktır.