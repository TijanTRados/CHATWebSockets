using Microsoft.Web.WebSockets;
using System;

namespace CHATWebSocket.Controllers
{
    public class ChatClient : WebSocketHandler
    {
        //public readonly Guid ConnectionId = Guid.NewGuid();
        private static WebSocketCollection chatClients = new WebSocketCollection();
        public string name;

        public override void OnOpen()
        {
            this.name = this.WebSocketContext.QueryString["name"];
            chatClients.Add(this);
            chatClients.Broadcast("Client joined: " + name.ToString());
        }

        public override void OnClose()
        {
            chatClients.Broadcast("Client left: " + name.ToString());
            chatClients.Remove(this);
        }

        public override void OnMessage(string message)
        {
            chatClients.Broadcast(
                name.ToString() + " said: " + message
            );
        }
    }
}