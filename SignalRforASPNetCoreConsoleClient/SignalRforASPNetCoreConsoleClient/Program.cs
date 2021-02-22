using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRforASPNetCoreConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("测试SignalR for ASPNetCore Console Client 控制台客户端!");
            HubConnection hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/messagehub").Build();
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"user:{user},message:{message}");
            });

            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("SendMessage", "Jack", "哈哈哈，SignalR for ASPNetCore Console Client 控制台客户端!");
            Console.ReadLine();
        }
    }

    //class Program
    //{
    //    static async Task Main(string[] args)
    //    {
    //        try
    //        {
    //            Console.WriteLine("测试SignalR for ASPNetCore Console Client 控制台客户端!");
    //            //        HubConnection hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/messagehub").Build();
    //            HubConnection connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/messagehub").Build();

    //            connection.On<string, string>("ReceiveMessage", (user, message) =>
    //            {
    //                var newMessage = $"{user}: {message}";

    //                Console.WriteLine(newMessage);
    //            });

    //            await connection.StartAsync();

    //            await connection.InvokeAsync("SendMessage", "jack", "hello,world");
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //        Console.ReadLine();
    //    }
    //}
}
