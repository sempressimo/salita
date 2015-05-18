using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Salita_Client
{
    public class UpdateHub : Hub
    {
        public void Send(string name)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name);
        }

        internal static void SendServer(string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UpdateHub>();
            context.Clients.All.broadcastMessage(message);
        }
    }
}