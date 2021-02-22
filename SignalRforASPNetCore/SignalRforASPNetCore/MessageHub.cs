using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRforASPNetCore
{
    /// <summary>
    /// 创建一个自定义的 MessageHub 类并继承类库中的 Hub 基类，在 MessageHub 中定义一个 SendMessage 方法，该方法用于向所有已连接的客户端发送消息
    /// </summary>
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
