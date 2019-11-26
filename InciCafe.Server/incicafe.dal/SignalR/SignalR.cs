using Microsoft.AspNet.SignalR.Hubs;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using System.Web.Providers.Entities;
using InciCafe.DAL.Entities;

namespace InciCafe.DAL.SignalR
{
    [HubName("MyHub")]
    [Authorize]
    public class MessageHub : Hub
    {
        
        public void SendToAll(Order order)
        {
            Clients.All.InvokeAsync("sendToAll", order);
        }

    }

}


