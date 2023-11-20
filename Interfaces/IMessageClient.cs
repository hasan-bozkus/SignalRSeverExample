using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSeverExample.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task userJoined(string connectionId);
        Task userLeaved(string connectionId);
    }
}
