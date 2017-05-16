using Microsoft.Web.WebSockets;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CHATWebSocket.Controllers
{
    public class WebSocketController : ApiController
    {
        public HttpResponseMessage Get()
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatClient());

            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }
    }
}