using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSeverExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            //sadece server'a bildirim gönderen client'la iletişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            //Server'a bağlı olan tüm client'larla iletişim kurar.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Other
            //Sadece Server'a bildirim gönderen client dışında server'a bağlı tüm client'lara mesaj gönderir.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotları

            #region AllExcept
            //Belirtilen Cilent'lar hariç server'a bağlı olan tüm clientalara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            //Server'a bağlı olan clientlar arasından sadece belirli bir client'a bildiride bulunur.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            //Server'a bağlı olan clientlar arasından sadece belirtilenlere bildiride bulunur.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Group
            //Belirtilen gruptaki tüm clientlara bildiride bulunur.
            //önce gruplar oluşturulmalı ve ardından clinetlar gruplara subsc. olmalı.
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region GroupExcept
            #endregion

            #region Groups
            #endregion

            #region OtherInGroups
            #endregion

            #region User
            #endregion

            #region Users
            #endregion

            #endregion


        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
