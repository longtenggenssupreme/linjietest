﻿using Hangfire;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using Quartz.Spi;
using System.Threading.Channels;
using Microsoft.FeatureManagement;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Net.WebSockets;
using System.Net.Sockets;

namespace EFCOREDB
{

    //System.Runtime.Serialization.SerializationException:
    //“程序集“ConsoleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null”
    //中的类型“CommonTools.Program”未标记为可序列化。”
    //处理方式1，添加[Serializable]特性
    //处理方式2，继承MarshalByRefObject
    //[Serializable]
    public class Program /*: MarshalByRefObject*/
    {
        public static int y = 5;
        public static int x = y;
        //static int y = 5;

        static void Main(string[] args)
        {
            #region 测试TestUdpSocket
            TestUdpSocket();
            #endregion

            #region 全部

            #region 测试TestTcpSocket
            //TestTcpSocket();
            #endregion

            #region 测试TestTcp
            //TestTcp();
            #endregion

            #region  测试Socket
            //TestSocket();
            #endregion

            #region  测试TestHttpListener
            //TestHttpListenerWebSocket(); 
            #endregion

            #region  测试TestHttpListener
            //TestHttpListener();
            #endregion

            #region  测试RestSharp
            //TestRestSharp();
            #endregion

            #region  测试Dotnet Core下的FeatureManage NET应用实现定时开关
            //TestFeatureManage();
            #endregion

            #region  测试Dotnet Core下的Channel System.Threading.Channels
            //TestDotnetCoreChannel();
            #endregion

            #region 测试 测试文件系统监听文件
            //TestFileSystemWatch();
            #endregion

            #region 测试 容器
            //TestServiceCollection();
            //TestServiceCollectionWithAutofac();
            //TestAutofacWithServiceCollection();
            #endregion

            #region 测试 批量插入 EntityFramework Core 5.0 VS SQLBulkCopy区别
            //EntityFramework Core 5.0
            //TestGenerateInsertAndInsertWithEFCoreData();
            //SQLBulkCopy
            //TestGenerateAndInsertWithSqlBulkCopyData();
            #endregion

            #region 测试析构函数
            //TestInstanceDestructor();

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            //while (true)
            //{
            //    System.Threading.Thread.Sleep(100);
            //}
            #endregion

            #region 自定义容器IOC(控制反转)，使用DI(依赖注入)
            //TestIOCcontainerFactory();
            #endregion

            #region 测试TestBitarry
            //TestBitarry(); 
            #endregion

            #region TestExpression
            //TestDynamicExpressionToSql();
            //TestDynamicExpressionVisitor();
            //TestDynamicExpression();
            //TestExpression();
            #endregion

            #region TestHashSet
            //TestHashSet();
            #endregion

            #region static
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(Program.x);
            //Console.WriteLine(Program.y);
            ////Console.WriteLine(Program.x);
            //Program.x = 99;
            //Program.y = 66;
            //Console.WriteLine(Program.x); 

            //TestStatic();
            #endregion

            #region QuartZ定时任务
            //TestQuartZ();
            #endregion

            #region 线程取消
            //TestThreancancel();
            #endregion

            #region task任务取消
            //TestTaskLinkedCancel();
            //TestTaskSync();
            //TestThreadCancel();
            //TestTaskCancel();
            //TestTaskCancel1(); 
            #endregion

            #region MyRegion
            //GetAsync();
            //var iterator = GetEnumerator();
            //while (iterator.MoveNext())
            //{
            //    Console.WriteLine($"输出{iterator.Current}");
            //} 
            #endregion

            #region 测试
            //TestConcurrentDictionary();
            //TestDBContext(); 
            #endregion

            #endregion

            Console.Read();
        }

        #region 测试TestUdp测试Socket

        /// <summary>
        /// 测试TestUdp
        /// </summary>
        public static void TestUdpSocket()
        {
            var threadStart = new Thread(new ThreadStart(StartTestUdpSocket))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"TestUdp开始测试数据");

            //var endip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2233);
            var ipendipoint = new IPEndPoint(IPAddress.Any, 0);
            ipendipoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2233);
            var endipoint = (EndPoint)ipendipoint;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int test = 1;
            while (true)
            {
                #region  Socket----Udp
                //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1122));
                Console.WriteLine($"Udp scoket client 发送数据:{test}");
                var senddata = Encoding.UTF8.GetBytes($"client{test}");
                socket.SendTo(senddata, 0, senddata.Length, SocketFlags.None, endipoint);

                var buffer = new byte[1024];
                var socketConnReceCount = socket.ReceiveFrom(buffer, ref endipoint);
                Console.WriteLine($"Udp scoket client 接收数据::{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");
             
                test++;
                Thread.Sleep(2000);
                //socket.Dispose();
                #endregion

                #region Socket----Tcp
                //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1122));
                //Console.WriteLine($"scoket client 发送数据:{test}");
                //socket.Send(Encoding.UTF8.GetBytes($"client{test}"));

                //var buffer = new byte[1024];
                //var socketConnReceCount = socket.Receive(buffer);
                //Console.WriteLine($"scoket client 接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                //test++;
                //Thread.Sleep(2000);
                //socket.Dispose();
                #endregion

            }
        }

        public static void StartTestUdpSocket()
        {
            var endip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2233);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(endip);
            //socket.Listen(10);

            var ipendipoint = new IPEndPoint(IPAddress.Any, 0);
            var endipoint = (EndPoint)ipendipoint;
            int test = 1;
            Console.WriteLine($"Udp服务端 启动监听");
            while (true)
            {
                #region Socket----Udp
                //var socketConn = await socket.AcceptAsync();
                var buffer = new byte[1024];
                var socketConnReceCount = socket.ReceiveFrom(buffer,ref endipoint);
                Console.WriteLine($"Udp服务端 scoket 服务端接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                Console.WriteLine($"Udp服务端 scoket 服务端处理数据:{test}");
                var senddata = Encoding.UTF8.GetBytes($"服务端已处理{test}");
                socket.SendTo(senddata, 0, senddata.Length,SocketFlags.None, endipoint);
                test++;
                //socket.Dispose();
                #endregion

                #region Socket----Tcp
                //var socketConn = await socket.AcceptAsync();
                //var buffer = new byte[1024];
                //var socketConnReceCount = socketConn.Receive(buffer);
                //Console.WriteLine($"TcpListener scoket 服务端接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                //Console.WriteLine($"TcpListener scoket 服务端处理数据:{test}");
                //socketConn.Send(Encoding.UTF8.GetBytes($"服务端已处理{test}"));
                //test++;
                //socketConn.Dispose();
                #endregion
            }
        }

        #endregion

        #region 测试TestTcp测试Socket

        /// <summary>
        /// 测试TestTcp
        /// </summary>
        public static void TestTcpSocket()
        {
            var threadStart = new Thread(new ThreadStart(StartTestTcpSocket))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"TestTcp开始测试数据");

            int test = 1;
            while (true)
            {
                #region TcpClient
                //TcpClient tcpClient = new TcpClient();
                //tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 1122);
                //Console.WriteLine($"TcpClient 发送数据:{test}");
                //await tcpClient.GetStream().WriteAsync(Encoding.UTF8.GetBytes($"client{test}"));

                //var buffer = new byte[1024];
                //var socketConnReceCount = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
                //Console.WriteLine($"TcpClient 接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                //test++;
                //Thread.Sleep(2000);
                //tcpClient.Dispose();
                #endregion

                #region Socket
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1122));
                Console.WriteLine($"scoket client 发送数据:{test}");
                socket.Send(Encoding.UTF8.GetBytes($"client{test}"));

                var buffer = new byte[1024];
                var socketConnReceCount = socket.Receive(buffer);
                Console.WriteLine($"scoket client 接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                test++;
                Thread.Sleep(2000);
                socket.Dispose();
                #endregion

            }
        }

        public static async void StartTestTcpSocket()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1122);
            #region TcpListener scoket
            //tcpListener.Server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1122));
            //tcpListener.Server.Listen(10);
            #endregion
            tcpListener.Start();
            int test = 1;
            Console.WriteLine($"TcpListener服务端 启动监听");
            while (true)
            {
                #region TcpClient----AcceptTcpClientAsync
                //var tcpclient = await tcpListener.AcceptTcpClientAsync();
                //var bytes = new byte[1024];
                //var readdataCount = await tcpclient.GetStream().ReadAsync(bytes, 0, bytes.Length);
                //Console.WriteLine($"TcpListener服务端接收数据:{Encoding.UTF8.GetString(bytes, 0, readdataCount)}");

                //bytes = Encoding.UTF8.GetBytes($"服务端已处理{test}");
                //await tcpclient.GetStream().WriteAsync(bytes, 0, bytes.Length);
                //tcpclient.Dispose();
                #endregion

                #region Socket----AcceptSocketAsync
                var socketConn = await tcpListener.AcceptSocketAsync();
                //var socketConn = await socket.AcceptAsync();
                var buffer = new byte[1024];
                var socketConnReceCount = socketConn.Receive(buffer);
                Console.WriteLine($"TcpListener scoket 服务端接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                Console.WriteLine($"TcpListener scoket 服务端处理数据:{test}");
                socketConn.Send(Encoding.UTF8.GetBytes($"服务端已处理{test}"));
                test++;
                socketConn.Dispose();
                #endregion
            }
        }

        #endregion

        #region 测试TestTcp

        /// <summary>
        /// 测试TestTcp
        /// </summary>
        public static async void TestTcp()
        {
            var threadStart = new Thread(new ThreadStart(StartTestTcp))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"TestTcp开始测试数据");

            int test = 1;
            while (true)
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 1122);
                Console.WriteLine($"TcpClient 发送数据:{test}");
                await tcpClient.GetStream().WriteAsync(Encoding.UTF8.GetBytes($"client{test}"));

                var buffer = new byte[1024];
                var socketConnReceCount = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine($"TcpClient 接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                test++;
                Thread.Sleep(2000);
                tcpClient.Dispose();
            }
        }

        public static async void StartTestTcp()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1122);
            tcpListener.Start();
            int test = 1;
            Console.WriteLine($"TcpListener服务端 启动监听");
            while (true)
            {
                var tcpclient = await tcpListener.AcceptTcpClientAsync();
                var bytes = new byte[1024];
                var readdataCount = await tcpclient.GetStream().ReadAsync(bytes, 0, bytes.Length);
                Console.WriteLine($"TcpListener服务端接收数据:{Encoding.UTF8.GetString(bytes, 0, readdataCount)}");

                bytes = Encoding.UTF8.GetBytes($"服务端已处理{test}");
                await tcpclient.GetStream().WriteAsync(bytes, 0, bytes.Length);
                test++;
                tcpclient.Dispose();
            }
        }

        #endregion

        #region 测试Socket

        /// <summary>
        /// 测试Socket
        /// </summary>
        public static void TestSocket()
        {
            var threadStart = new Thread(new ThreadStart(StartSocket))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"Socket开始测试数据");

            int test = 1;
            while (true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3344));
                Console.WriteLine($"scoket client 发送数据:{test}");
                socket.Send(Encoding.UTF8.GetBytes($"client{test}"));

                var buffer = new byte[1024];
                var socketConnReceCount = socket.Receive(buffer);
                Console.WriteLine($"scoket client 接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                test++;
                Thread.Sleep(2000);
                socket.Dispose();
            }
        }

        public static async void StartSocket()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.LingerState.Enabled = false;
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3344));
            socket.Listen(10);
            int test = 1;
            Console.WriteLine($"Socket服务端 启动监听");
            while (true)
            {
                var socketConn = await socket.AcceptAsync();
                var buffer = new byte[1024];
                var socketConnReceCount = socketConn.Receive(buffer);
                Console.WriteLine($"scoket 服务端接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                Console.WriteLine($"scoket 服务端处理数据:{test}");
                socketConn.Send(Encoding.UTF8.GetBytes($"服务端已处理{test}"));
                test++;
                socketConn.Dispose();
            }
        }

        #endregion

        #region 测试HttpListenerWebSocket

        /// <summary>
        /// 测试HttpListener
        /// </summary>
        public static async void TestHttpListenerWebSocket()
        {
            var threadStart = new Thread(new ThreadStart(StartHttpListenerWebSocket))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"WebSocket开始测试数据");

            int test = 1;
            while (true)
            {
                ClientWebSocket clientWebSocket = new ClientWebSocket();
                await clientWebSocket.ConnectAsync(new Uri("ws://localhost:5566"), default);
                if (clientWebSocket.State == WebSocketState.Open)
                {
                    var bytes = Encoding.UTF8.GetBytes($"客户端发---{test}");
                    var bufferSend = new ArraySegment<byte>(bytes);
                    await clientWebSocket.SendAsync(bufferSend, WebSocketMessageType.Text, true, default);

                    var buffer = new byte[1024];
                    var webSocketReceiveResult = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), default);
                    var result = Encoding.UTF8.GetString(buffer, 0, webSocketReceiveResult.Count);
                    Console.WriteLine($"客户端收---{result}");
                }
                test++;
                Thread.Sleep(1000);
            }
        }

        public static async void StartHttpListenerWebSocket()
        {
            HttpListener httpListener = new HttpListener();
            //httpListener.Prefixes.Add("http://localhost:5566/");
            //httpListener.Prefixes.Add("http://+:5566/");
            httpListener.Prefixes.Add("http://*:5566/");
            httpListener.Start();
            Console.WriteLine($"httpListener 启动监听");
            while (true)
            {
                //var asyncResult = httpListener.BeginGetContext(new AsyncCallback(CallbackWebSocket), httpListener);
                //asyncResult.AsyncWaitHandle.WaitOne();
                //下面也可以
                //var httpListenerContext = httpListener.GetContextAsync().GetAwaiter().GetResult();
                //var httpListenerContext = httpListener.GetContextAsync().Result;
                var httpListenerContext = await httpListener.GetContextAsync();
                //处理httpListenerContext
                ProcessHttpListenerContextWebSocket(httpListenerContext);
            }
        }

        private static async void ProcessHttpListenerContextWebSocket(HttpListenerContext httpcontent)
        {
            if (httpcontent.Request.IsWebSocketRequest)//处理WebSocketRequest
            {
                var webSocketContext = await httpcontent.AcceptWebSocketAsync(null);
                var webSocket = webSocketContext.WebSocket;
                var buffer = new byte[1024];
                var WebSocketReceiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), default);
                var result = Encoding.UTF8.GetString(buffer, 0, WebSocketReceiveResult.Count);
                Console.WriteLine($"服务端 收到:{result}");

                var bytes = Encoding.UTF8.GetBytes($"服务端处理:{result}");
                var bufferSend = new ArraySegment<byte>(bytes);
                await webSocket.SendAsync(bufferSend, WebSocketMessageType.Text, true, default);
                webSocket.Dispose();
            }
            else //处理HttpWebRequest
            {
                Console.WriteLine($"HttpWebRequest 请求");
                if (httpcontent.Request.HttpMethod == HttpMethod.Post.ToString())
                {
                    Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
                    var input = new StreamReader(httpcontent.Request.InputStream).ReadToEnd();
                    var bytes = Encoding.UTF8.GetBytes($"我们收到数据:{input}，哈哈哈哈");
                    httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
                    httpcontent.Response.Close();
                }
                else
                {
                    Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
                    var bytes = Encoding.UTF8.GetBytes($"{httpcontent.Request.RawUrl}----哈哈哈哈");
                    httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
                    httpcontent.Response.Close();
                }
            }
        }

        private static async void CallbackWebSocket(IAsyncResult ar)
        {
            var httplist = (HttpListener)ar.AsyncState;
            var httpcontent = httplist.EndGetContext(ar);
            if (httpcontent.Request.IsWebSocketRequest)
            {
                var webSocketContext = await httpcontent.AcceptWebSocketAsync(null);
                var webSocket = webSocketContext.WebSocket;
                var buffer = new byte[1024];
                await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), default);
                var result = Encoding.UTF8.GetString(buffer.ToArray());
                var bytes = Encoding.UTF8.GetBytes($"我们收到数据:{result}，以处理");
                var bufferSend = new ArraySegment<byte>(bytes);
                await webSocket.SendAsync(bufferSend, WebSocketMessageType.Text, true, default);
            }
        }

        #endregion

        #region 测试HttpListener

        /// <summary>
        /// 测试HttpListener
        /// </summary>
        public static async void TestHttpListener()
        {
            var threadStart = new Thread(new ThreadStart(StartHttpListener))
            {
                IsBackground = true
            };
            threadStart.Start();
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine($"开始测试数据");
            int test = 1;
            while (true)
            {
                if (test % 2 == 0)
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5566?a={test}");
                    httpWebRequest.Method = "Get";
                    using var response = httpWebRequest.GetResponse().GetResponseStream();
                    var result = new StreamReader(response).ReadToEnd();
                    Console.WriteLine($"偶数--结果数据{result}");
                }
                else
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5566?a={test}");
                    httpWebRequest.Method = "Post";
                    var bytes = Encoding.UTF8.GetBytes($"Post数据：{test}");
                    using var requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    using var response = httpWebRequest.GetResponse().GetResponseStream();
                    var result = new StreamReader(response).ReadToEnd();
                    Console.WriteLine($"奇数--结果数据{result}");
                }
                test++;
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        public static async void StartHttpListener()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            HttpListener httpListener = new HttpListener();
            //httpListener.Prefixes.Add("http://localhost:5566/");
            //httpListener.Prefixes.Add("http://+:5566/");
            httpListener.Prefixes.Add("http://*:5566/");
            httpListener.Start();
            Console.WriteLine($"httpListener 启动监听");
            while (true)
            {
                var ssyncResult = httpListener.BeginGetContext(new AsyncCallback(Callback), httpListener);
                ssyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        private static void Callback(IAsyncResult ar)
        {
            var httplist = (HttpListener)ar.AsyncState;
            var httpcontent = httplist.EndGetContext(ar);
            ProcessHttpListenerContext(httpcontent);
            #region 下面的处理抽成 ProcessHttpListenerContext 方法
            //if (httpcontent.Request.HttpMethod == HttpMethod.Post.ToString())
            //{
            //    Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
            //    var input = new StreamReader(httpcontent.Request.InputStream).ReadToEnd();
            //    var bytes = Encoding.UTF8.GetBytes($"我们收到数据:{input}，哈哈哈哈");
            //    httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
            //    httpcontent.Response.Close();
            //}
            //else
            //{
            //    Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
            //    var bytes = Encoding.UTF8.GetBytes($"{httpcontent.Request.RawUrl}----哈哈哈哈");
            //    httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
            //    httpcontent.Response.Close();
            //} 
            #endregion
        }

        private static void ProcessHttpListenerContext(HttpListenerContext httpcontent)
        {
            if (httpcontent.Request.HttpMethod == HttpMethod.Post.ToString())
            {
                Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
                var input = new StreamReader(httpcontent.Request.InputStream).ReadToEnd();
                var bytes = Encoding.UTF8.GetBytes($"我们收到数据:{input}，哈哈哈哈");
                httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
                httpcontent.Response.Close();
            }
            else
            {
                Console.WriteLine($"请求方法：{httpcontent.Request.HttpMethod}");
                var bytes = Encoding.UTF8.GetBytes($"{httpcontent.Request.RawUrl}----哈哈哈哈");
                httpcontent.Response.OutputStream.Write(bytes, 0, bytes.Length);
                httpcontent.Response.Close();
            }
        }
        #endregion

        #region 测试RestSharp

        /// <summary>
        /// 测试RestSharp
        /// </summary>
        public static async void TestRestSharp()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            //创建RestSharp的请求客户端以及设置基地址，该机地址是配合请求的资源地址一起使用的
            //RestSharp.RestClient restClient = new RestSharp.RestClient("http://+:5566");//http://localhost:5566
            RestClient restClient = new RestClient("http://localhost:5566");
            //创建请求信息以及请求的地址
            RestRequest restRequest = new RestRequest("/api/TestRestSharp", Method.GET);
            //restRequest.AddHeader("contentType", "application.json;charset=utf-8");
            //执行请求，获取返回的请求结果
            //var result = restClient.ExecuteAsync(restRequest).GetAwaiter().GetResult();
            var result = restClient.Execute<List<string>>(restRequest);

            restRequest = new RestRequest("/api/TestRestSharp/1", Method.GET);
            var result1 = restClient.Execute(restRequest);

            restRequest = new RestRequest("/api/TestRestSharp", Method.POST);
            restRequest.AddJsonBody("666666");
            var result2 = restClient.Execute(restRequest);

            restRequest = new RestRequest("/api/TestRestSharp/2", Method.PUT);
            restRequest.AddJsonBody("9999");
            var result3 = restClient.Execute(restRequest);

            restRequest = new RestRequest("/api/TestRestSharp/1", Method.DELETE);
            var result4 = restClient.Execute(restRequest);
            //if (result is not null)
            //{
            //    Console.WriteLine($"FeatureManage NET应用实现定时开关,启用");
            //}
            //else
            //{
            //    Console.WriteLine($"FeatureManage开关,关闭");
            //}
        }

        #endregion

        #region 测试Dotnet Core下的FeatureManage NET应用实现定时开关
        /// <summary>
        /// 测试.NET应用实现定时开关
        /// </summary>
        public static async void TestFeatureManage()
        {
            //添加IOC依赖注入到容器
            IServiceCollection services = new ServiceCollection();
            services.AddFeatureManagement();

            var seviceProvider = services.BuildServiceProvider();
            IFeatureManager featureManager = seviceProvider.GetRequiredService<IFeatureManager>();
            if (await featureManager.IsEnabledAsync(nameof(FeatureFlag.EnableWebAPI)))
            {
                Console.WriteLine($"FeatureManage NET应用实现定时开关,启用");
            }
            else
            {
                Console.WriteLine($"FeatureManage开关,关闭");
            }
        }

        /// <summary>
        /// 测试开关枚举
        /// </summary>
        public enum FeatureFlag
        {
            /// <summary>
            /// webapi
            /// </summary>
            EnableWebAPI,
            /// <summary>
            /// 审计
            /// </summary>
            EnableAduit
        }
        #endregion

        #region 测试Dotnet Core下的Channel System.Threading.Channels
        /// <summary>
        /// 测试Dotnet Core下的ChannelSystem.Threading.Channels
        /// </summary>
        public static async void TestDotnetCoreChannel()
        {
            int x = 1;
            //创建通道
            var channel = Channel.CreateUnbounded<string>();
            while (true)
            {
                Console.WriteLine($"生产者生产数据:{x}");
                await channel.Writer.WriteAsync($"数据:{x}");
                if (await channel.Reader.WaitToReadAsync())
                {
                    if (channel.Reader.TryRead(out string item))
                    {
                        Console.WriteLine($"消费者读取item:{item}");
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
                x++;
            }
        }
        #endregion

        #region 测试文件系统监听文件
        /// <summary>
        /// 测试文件系统监听文件
        /// </summary>
        public static void TestFileSystemWatch()
        {
            FileSystemWatcher fileSystem = new()
            {
                Path = @"F:\Test\test",//监听的目录
                Filter = "*.*",//监听目录下哪些类型的文件
                               //NotifyFilter = NotifyFilters.LastWrite//监听操作类型，修改删除创建等
                               //EnableRaisingEvents=true//是否启用该监听组件
            };
            fileSystem.EnableRaisingEvents = true;
            fileSystem.Created += FileSystem_Created;
            fileSystem.Deleted += FileSystem_Deleted;
            fileSystem.Renamed += FileSystem_Renamed;
            fileSystem.Changed += FileSystem_Changed;
            Console.WriteLine();

        }

        private static void FileSystem_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"监听文件变化：ChangeType:{e.ChangeType},FullPath:{e.FullPath},Name:{e.Name}");
        }

        private static void FileSystem_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"监听文件变化：ChangeType:{e.ChangeType},FullPath:{e.FullPath},Name:{e.Name}");
        }

        private static void FileSystem_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"监听文件变化：ChangeType:{e.ChangeType},FullPath:{e.FullPath},Name:{e.Name}");
        }

        private static void FileSystem_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"监听文件变化：ChangeType:{e.ChangeType},FullPath:{e.FullPath},Name:{e.Name}");
        }
        #endregion

        #region 测试 容器
        /// <summary>
        /// 测试自带的IOC容器的DI依赖注入单独使用
        /// </summary>
        public static void TestServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ITestA, TestA>();//瞬态，每次使用的时候容器都会创建一个新的实例对象
            services.AddSingleton<ITestB, TestB>();//单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            services.AddScoped<ITestC, TestC>();//作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
                                                //根容器下保留容器创建的单例实例对象，
                                                //根容器下的子容器中的公用根容器的容器创建的单例实例对象，子容器中容器创建的单例实例对象也是存储到根容器的容器中的
                                                //根容器下不同子容器中使用的对象实例是相同的
            services.AddTransient<ITestD, TestD>();

            var seviceProvider = services.BuildServiceProvider();

            #region Transient 瞬态，每次使用的时候容器都会创建一个新的实例对象
            Console.WriteLine("---瞬态，每次使用的时候容器都会创建一个新的实例对象---");
            ITestA testA = seviceProvider.GetRequiredService<ITestA>();
            ITestA testA1 = seviceProvider.GetRequiredService<ITestA>();
            testA.Show();
            Console.WriteLine($"是否为同一个对象实例：{testA.Equals(testA1)}");
            Console.WriteLine();
            #endregion

            #region Singleton 单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            Console.WriteLine("---单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中---");
            ITestB testB = seviceProvider.GetRequiredService<ITestB>();
            ITestB testB1 = seviceProvider.GetRequiredService<ITestB>();
            testB.Show();
            Console.WriteLine($"是否为同一个对象实例：{testB.Equals(testB1)}");
            Console.WriteLine();
            #endregion

            #region Scoped 作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下---");
            ITestC testC = seviceProvider.GetRequiredService<ITestC>();
            ITestC testC1 = seviceProvider.GetRequiredService<ITestC>();
            testC.Show();
            Console.WriteLine($"是否为同一个对象实例：{testC.Equals(testC1)}");
            Console.WriteLine();

            Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象 作用域1和作用域2---");
            ITestC testC2 = seviceProvider.CreateScope().ServiceProvider.GetRequiredService<ITestC>();
            ITestC testC3 = seviceProvider.CreateScope().ServiceProvider.GetRequiredService<ITestC>();
            testC2.Show();
            Console.WriteLine($"是否为同一个对象实例：{testC2.Equals(testC3)}");
            Console.WriteLine();


            Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象 作用域1和作用域2---BuildServiceProvider");
            var seviceProvider1 = services.BuildServiceProvider();
            ITestC testC4 = seviceProvider.GetRequiredService<ITestC>();
            ITestC testC5 = seviceProvider1.GetRequiredService<ITestC>();
            testC4.Show();
            Console.WriteLine($"是否为同一个对象实例：{testC4.Equals(testC5)}");
            Console.WriteLine();


            Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象 作用域1和作用域2---BuildServiceProvider");
            var seviceProvider2 = services.BuildServiceProvider();
            var seviceProvider3 = services.BuildServiceProvider();
            ITestC testC7 = seviceProvider2.GetRequiredService<ITestC>();
            ITestC testC8 = seviceProvider3.GetRequiredService<ITestC>();
            testC7.Show();
            Console.WriteLine($"是否为同一个对象实例：{testC7.Equals(testC7)}");
            Console.WriteLine();

            #endregion
        }

        /// <summary>
        /// 测试Autofac的IOC容器的DI依赖注入的使用
        /// </summary>
        public static void TestServiceCollectionWithAutofac()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            //瞬态，每次使用的时候容器都会创建一个新的实例对象
            containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            //单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();
            //作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();
            //作用域--指定名称，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("作用域名称1");

            var container = containerBuilder.Build();
            #region Autofac
            #region Transient 瞬态，每次使用的时候容器都会创建一个新的实例对象
            Console.WriteLine("---瞬态---");
            ITestA testA = container.Resolve<ITestA>();
            ITestA testA1 = container.Resolve<ITestA>();
            //testA.Show();
            Console.WriteLine($"是否为同一个对象实例：{testA.Equals(testA1)}");
            Console.WriteLine();
            #endregion

            #region Singleton 单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            //Console.WriteLine("---单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中---");
            //ITestB testB = container.Resolve<ITestB>();
            //ITestB testB1 = container.Resolve<ITestB>();
            ////testB.Show();
            //Console.WriteLine($"是否为同一个对象实例：{testB.Equals(testB1)}");
            //Console.WriteLine();
            #endregion

            #region Scoped 作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下---");
            //ITestC testC = container.Resolve<ITestC>();
            //ITestC testC1 = container.Resolve<ITestC>();
            ////testC.Show();
            //Console.WriteLine($"是否为同一个对象实例：{testC.Equals(testC1)}");
            //Console.WriteLine();
            #endregion

            #region Scoped 作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下---BeginLifetimeScope");
            //using var lifetimeScope = container.BeginLifetimeScope();
            //ITestC testC2 = lifetimeScope.Resolve<ITestC>();
            //ITestC testC3 = lifetimeScope.Resolve<ITestC>();
            ////testC.Show();
            //Console.WriteLine($"是否为同一个对象实例：{testC2.Equals(testC3)}");
            //Console.WriteLine();

            //using var lifetimeScope1 = container.BeginLifetimeScope();
            //ITestC testC5 = lifetimeScope1.Resolve<ITestC>();
            //using var lifetimeScope2 = container.BeginLifetimeScope();
            //ITestC testC6 = lifetimeScope2.Resolve<ITestC>();
            ////testC.Show();
            //Console.WriteLine($"是否为同一个对象实例：{testC5.Equals(testC6)}");
            //Console.WriteLine();
            #endregion
            //ITestC testC323; ITestC testC353;
            #region Scoped 作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下---BeginLifetimeScope lifetimeScope33");
            //using var lifetimeScope30 = lifetimeScope.BeginLifetimeScope();
            //testC323 = lifetimeScope30.Resolve<ITestC>();

            //using var lifetimeScope31 = lifetimeScope.BeginLifetimeScope();
            //testC353 = lifetimeScope31.Resolve<ITestC>();
            //Console.WriteLine($"是否为同一个对象实例：{testC323.Equals(testC353)}");
            //Console.WriteLine();
            #endregion

            #region Scoped 作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //using var lifetimeScopeTag = container.BeginLifetimeScope("作用域名称1");
            //ITestC testC2Tag = lifetimeScopeTag.Resolve<ITestC>();
            //ITestC testC3Tag = lifetimeScopeTag.Resolve<ITestC>();
            //Console.WriteLine($"是否为同一个对象实例：{testC2Tag.Equals(testC3Tag)}");
            //Console.WriteLine(); 
            //ITestC testC323Tag; ITestC testC353Tag;          
            //Console.WriteLine("---作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下---BeginLifetimeScope 作用域名称1");
            //using var lifetimeScope30Tag = lifetimeScopeTag.BeginLifetimeScope();
            //testC323Tag = lifetimeScope30Tag.Resolve<ITestC>();

            //using var lifetimeScope31Tag = lifetimeScopeTag.BeginLifetimeScope();
            //testC353Tag = lifetimeScope31Tag.Resolve<ITestC>();
            //Console.WriteLine($"是否为同一个对象实例：{testC323Tag.Equals(testC353Tag)}");
            //Console.WriteLine();
            #endregion
            #endregion

            #region 原生依赖注入的扩展 Scrutor----》 Register services using assembly scanning and a fluent API.
            //Console.WriteLine("---瞬态，每次使用的时候容器都会创建一个新的实例对象---");
            //ITestA testA = seviceProvider.GetRequiredService<ITestA>();
            //ITestA testA1 = seviceProvider.GetRequiredService<ITestA>();
            //testA.Show();
            //Console.WriteLine($"是否为同一个对象实例：{testA.Equals(testA1)}");
            //Console.WriteLine();
            #endregion
        }


        /// <summary>
        /// 测试Autofac的IOC容器的DI依赖注入和原生IOC容器的DI依赖注入的使用
        /// </summary>
        public static void TestAutofacWithServiceCollection()
        {
            #region Autofac
            //IServiceCollection services = new ServiceCollection();
            //services.AddTransient<ITestA, TestA>();//瞬态，每次使用的时候容器都会创建一个新的实例对象
            //services.AddSingleton<ITestB, TestB>();//单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            ////services.AddScoped<ITestC, TestC>();//作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            ////根容器下保留容器创建的单例实例对象，
            ////根容器下的子容器中的公用根容器的容器创建的单例实例对象，子容器中容器创建的单例实例对象也是存储到根容器的容器中的
            ////根容器下不同子容器中使用的对象实例是相同的
            ////services.AddTransient<ITestD, TestD>();

            ////var seviceProvider = services.BuildServiceProvider();

            //ContainerBuilder containerBuilder = new ContainerBuilder();
            ////瞬态，每次使用的时候容器都会创建一个新的实例对象
            ////containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            ////单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            ////containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();
            ////作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();
            ////作用域--指定名称，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("作用域名称1");
            //containerBuilder.Populate(services);//IServiceCollection 原生的服务容器注册到Autofac容器中            
            //var container = containerBuilder.Build();
            ////使用Autofac容器创建对象实例
            //ITestB testB = container.Resolve<ITestB>();
            //ITestB testB1 = container.Resolve<ITestB>();
            //Console.WriteLine($"是否为同一个对象实例：{testB.Equals(testB1)}");

            //var seviceProvider= new AutofacServiceProvider(container);
            //ITestA testA = seviceProvider.GetRequiredService<ITestA>();
            //ITestA testA1 = seviceProvider.GetRequiredService<ITestA>();
            //Console.WriteLine($"是否为同一个对象实例：{testA.Equals(testA1)}");
            #endregion

            #region 原生IServiceCollection依赖注入的扩展 Scrutor----》 Register services using assembly scanning and a fluent API.
            IServiceCollection services = new ServiceCollection();
            //services.AddTransient<ITestA, TestA>();//瞬态，每次使用的时候容器都会创建一个新的实例对象
            //services.AddSingleton<ITestB, TestB>();//单例，整个进程中容器只会创建一个实例对象存储在根容器的容器中
            //services.AddScoped<ITestC, TestC>();//作用域，不同的作用域容器创建不同的实例对象，但是都属于根容器下
            //根容器下保留容器创建的单例实例对象，
            //根容器下的子容器中的公用根容器的容器创建的单例实例对象，子容器中容器创建的单例实例对象也是存储到根容器的容器中的
            //根容器下不同子容器中使用的对象实例是相同的
            //services.AddTransient<ITestD, TestD>();

            //Scrutor其实是IServiceCollection的扩展
            //Scrutor使用Scan和Decorate批量注册服务和接口
            //我们写一些接口和实现类的时候，都会根据这样的习惯来命名，定义一个接口IClass，它的实现类就是Class。
            //services.Scan(scan =>
            //scan.FromAssemblyOf<TestD>()
            //.AddClasses()
            //.AsMatchingInterface()
            //.WithTransientLifetime());
            //AsMatchingInterface 针对（接口IClass和它的实现类就是Class）。
            //这种处理方式很方便，但仅限于同一种生命周期，如果不同的类和接口想要不同的生命周期的话，该方式就不适合了

            //Scrutor使用Scan和Decorate批量注册服务和接口
            //services.Scan(scan =>
            //scan.FromAssemblyOf<TestD>()
            //.AddClasses(classes => classes.Where(c => c.Name.Contains("Test")))//类型名称中包含Test的都会被注册
            //.AsImplementedInterfaces()
            //.WithTransientLifetime());



            //Scrutor使用Scan和Decorate批量注册单个服务
            services.Scan(scan =>
            scan.AddTypes(typeof(MyScrutorTest)).AsSelf().WithSingletonLifetime());


            //var listarr = services.Where(s => s.ServiceType.Namespace.Contains("", StringComparison.OrdinalIgnoreCase)).ToList();
            //foreach (var item in listarr)
            //{
            //    Console.WriteLine($"容器中的服务:ServiceType:{item.ServiceType},ImplementationType:{item.ImplementationType},Lifetime:{item.Lifetime}");
            //}

            #region Test 类型名称中包含Test的都会被注册 上面的foreach循环输出的内容
            //容器中的服务: ServiceType: System.IDisposable,ImplementationType: EFCOREDB.TestDestructor,Lifetime: Transient
            //容器中的服务:ServiceType: EFCOREDB.ITestA,ImplementationType: EFCOREDB.TestA,Lifetime: Transient
            //容器中的服务:ServiceType: EFCOREDB.ITestB,ImplementationType: EFCOREDB.TestB,Lifetime: Transient
            //容器中的服务:ServiceType: EFCOREDB.ITestC,ImplementationType: EFCOREDB.TestC,Lifetime: Transient
            //容器中的服务:ServiceType: EFCOREDB.ITestD,ImplementationType: EFCOREDB.TestD,Lifetime: Transient
            //容器中的服务:ServiceType: EFCOREDB.ITestA,ImplementationType: EFCOREDB.TestF,Lifetime: Transient 

            //可以看出 TestF TestA都实现了ITestA接口，结果查询的时候都显示了，那么如果想要去掉，即只显示一个接口和一个实现该怎么处理
            //重复注册处理策略
            //还有一个比较常见的情形是，重复注册，即同一个接口，有多个不同的实现。
            //Scrutor提供了三大策略，Append、Skip和Replace。 Append是默认行为，就是叠加，也就是出现上述 TestF TestA都实现了ITestA接口的情况
            //下面使用Scrutor提供Skip策略
            services.Scan(scan =>
            scan.FromAssemblyOf<TestD>()
            .AddClasses(classes => classes.AssignableTo<ITestA>())//类型名称中实现ITestA的类都会被注册
            .UsingRegistrationStrategy(Scrutor.RegistrationStrategy.Skip)//解决 TestF TestA都实现了ITestA接口的情况，之注册一个接口和实现
            .AsImplementedInterfaces()
            .WithTransientLifetime());
            var listarr = services.Where(s => s.ServiceType.Namespace.Contains("", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var item in listarr)
            {
                Console.WriteLine($"容器中的服务:ServiceType:{item.ServiceType},ImplementationType:{item.ImplementationType},Lifetime:{item.Lifetime}");
            }
            //容器中的服务:ServiceType:EFCOREDB.MyScrutorTest,ImplementationType:EFCOREDB.MyScrutorTest,Lifetime:Singleton
            //容器中的服务: ServiceType: EFCOREDB.ITestA,ImplementationType: EFCOREDB.TestA,Lifetime: Transient
            //可以看出 TestF TestA都实现了ITestA接口，结果查询的时候只显示一个接口和一个实现了
            #endregion

            var seviceProvider = services.BuildServiceProvider();
            MyScrutorTest myScrutorTest = seviceProvider.GetRequiredService<MyScrutorTest>();
            myScrutorTest.Show();
            #region Transient 瞬态，每次使用的时候容器都会创建一个新的实例对象
            Console.WriteLine("---瞬态，每次使用的时候容器都会创建一个新的实例对象---");
            ITestA testA = seviceProvider.GetRequiredService<ITestA>();
            ITestA testA1 = seviceProvider.GetRequiredService<ITestA>();
            testA.Show();
            Console.WriteLine($"是否为同一个对象实例：{testA.Equals(testA1)}");
            Console.WriteLine();
            #endregion
            #endregion
        }
        #endregion

        #region EntityFramework Core 5.0 VS SQLBulkCopy
        /// <summary>
        /// EntityFramework Core 5.0 上下文去新增数据，然后分别打印伪造数据和新增成功所耗费时间
        /// </summary>
        public static async void TestGenerateInsertAndInsertWithEFCoreData()
        {
            Console.WriteLine("产生模拟数据");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = GenerateMockData.GetTests(10000);
            //产生10条模拟数据
            //产生模拟数据, 花费时间：0.2591446 秒
            //产生模拟数据, 花费时间：0.2591446 秒,插入数据的数据数量: 10，插入数据花费时间: 0.2411458

            //产生10000条模拟数据
            //产生模拟数据,花费时间：0.9874856 秒
            //产生模拟数据,花费时间：0.9874856 秒,插入数据的数据数量: 10000，插入数据花费时间: 1.4542355

            var TotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"产生模拟数据,花费时间：{TotalSeconds} 秒");
            //上下文去新增数据，然后分别打印伪造数据和新增成功所耗费时间
            var datetime1 = DateTime.Now;
            using var EFCoreVSSqlBulkCopyContext = new EFCoreVSSqlBulkCopyContext() { CreateDateTime = datetime1 };
            EFCoreVSSqlBulkCopyContext.Database.EnsureCreated();
            stopwatch.Restart();
            EFCoreVSSqlBulkCopyContext.Tests.AddRange(data);
            await EFCoreVSSqlBulkCopyContext.AddRangeAsync(data);
            var result = await EFCoreVSSqlBulkCopyContext.SaveChangesAsync();

            Console.WriteLine($"产生模拟数据,花费时间：{TotalSeconds} 秒,插入数据的数据数量:{result}，插入数据花费时间:{stopwatch.Elapsed.TotalSeconds}");
        }

        /// <summary>
        /// SQLBulkCopy 上下文去新增数据，然后分别打印伪造数据和新增成功所耗费时间
        /// </summary>
        public static async void TestGenerateAndInsertWithSqlBulkCopyData()
        {
            Console.WriteLine("产生模拟数据");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = GenerateMockData.GetTests(10000);

            //产生10000条模拟数据
            //产生模拟数据,花费时间：1.0126009 秒
            //产生模拟数据, 花费时间：1.0126009 秒,插入数据的数据数量: 10000，插入数据花费时间: 0.3210853

            var TotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"产生模拟数据,花费时间：{TotalSeconds} 秒");
            //上下文去新增数据，然后分别打印伪造数据和新增成功所耗费时间
            var datetime1 = DateTime.Now;
            using (var EFCoreVSSqlBulkCopyContext = new EFCoreVSSqlBulkCopyContext() { CreateDateTime = datetime1 })
            {
                EFCoreVSSqlBulkCopyContext.Database.EnsureCreated();
            }
            stopwatch.Restart();

            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("Content");
            dt.Columns.Add("CreateDateTime");
            foreach (var item in data)
            {
                dt.Rows.Add(item.Id, item.Title, item.Content, item.CreateDateTime);
            }
            //注意DestinationTableName 必须是全路径即 数据库名称.架构名称.表名称
            using var sqlbulkcopy = new SqlBulkCopy("server=127.0.0.1;database=EFCoreVSSqlBulkCopyContext;user=sa;password=sa123;") { DestinationTableName = "EFCoreVSSqlBulkCopyContext.dbo.[20201208]" };
            await sqlbulkcopy.WriteToServerAsync(dt);

            Console.WriteLine($"产生模拟数据,花费时间：{TotalSeconds} 秒,插入数据的数据数量:{10000}，插入数据花费时间:{stopwatch.Elapsed.TotalSeconds}");
        }
        #endregion

        #region 测试析构函数
        /// <summary>
        /// 测试析构函数程序员无法控制解构器何时被执行因为这是由垃圾搜集器决定的。
        /// 但程序退出时解构器被调用了。你能通过日志输出文件来确认析构函数是否别调用。这里将它输出在文本文件中，可以看到解构器被调用了，因为在背后base.Finalize()被调用了。
        /// </summary>
        public static void TestInstanceDestructor()
        {
            Console.WriteLine("测试析构函数");
            //var sanBox = new CurrentDomainSandbox();
            //var instance = sanBox.CreateInstance<Program>();

            //using (var test = new TestDestructor())
            //{
            //    test.InvokeExampleMethod();
            //}
            //GC.Collect();

            //var test = new TestDestructor();
            //test = null;
            //GC.Collect();


            TestDesttructor1 testDesttructor1 = new TestDesttructor1();
            testDesttructor1.InvokeMethod1();
        }
        #endregion

        #region 测试 bitarry 位压缩
        static void TestBitarry()
        {
            // Creates and initializes several BitArrays.
            BitArray myBA1 = new BitArray(5);

            BitArray myBA2 = new BitArray(5, false);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            BitArray myBA3 = new BitArray(myBytes);

            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray myBA4 = new BitArray(myBools);

            int[] myInts = new int[5] { 6, 7, 8, 9, 10 };
            BitArray myBA5 = new BitArray(myInts);

            // Displays the properties and values of the BitArrays.
            Console.WriteLine("myBA1");
            Console.WriteLine("   Count:    {0}", myBA1.Count);
            Console.WriteLine("   Length:   {0}", myBA1.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA1, 8);

            Console.WriteLine("myBA2");
            Console.WriteLine("   Count:    {0}", myBA2.Count);
            Console.WriteLine("   Length:   {0}", myBA2.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA2, 8);

            Console.WriteLine("myBA3");
            Console.WriteLine("   Count:    {0}", myBA3.Count);
            Console.WriteLine("   Length:   {0}", myBA3.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA3, 8);

            Console.WriteLine("myBA4");
            Console.WriteLine("   Count:    {0}", myBA4.Count);
            Console.WriteLine("   Length:   {0}", myBA4.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA4, 8);

            Console.WriteLine("myBA5");
            Console.WriteLine("   Count:    {0}", myBA5.Count);
            Console.WriteLine("   Length:   {0}", myBA5.Length);
            Console.WriteLine("   Values:");
            PrintValues(myBA5, 8);
        }

        public static void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }

        #endregion

        #region 自定义容器IOC(控制反转)，使用DI(依赖注入)

        /// <summary>
        ///  测试自定义容器IOC(控制反转)
        /// </summary>
        public static void TestIOCcontainerFactory()
        {
            ContainerFactory containerFactory = new ContainerFactory();
            if (containerFactory.GetCreateObject("SquareShape") is SquareShape squareShape)
            {
                squareShape.Show();
                var ishape = squareShape.RectangleShape;
                ishape.Show();
                Console.WriteLine("自定义容器创建实例完成。。。");
            }

            if (containerFactory.GetCreateObject("SquareShape") is SquareShape squareShape1)
            {
                squareShape1.Show();
                var ishape = squareShape1.RectangleShape;
                ishape.Show();
                Console.WriteLine("自定义容器创建实例完成。。。");
            }

            Console.WriteLine("自定义容器创建实例完成。。。");
        }

        #region 开始处理思路--出现情况1、创建A对象的实例时候遇到属性赋值》A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //创建对象实例
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        var subPropertyType = Activator.CreateInstance(subtype);
        //                        property.SetValue(typeInstant, subPropertyType);

        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    }
        //                }
        //            }
        //        }
        //    }            
        //}
        #endregion

        #region 问题1
        //使用递归方法 解决出现情况1、创建A对象的实例时候遇到属性赋值》A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A，又出现新问题，创建对象以及属性赋值的时候foreach嵌套2次循环会有性能问题

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //创建对象实例
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                        property.SetValue(typeInstant, CreateObject(subtype, types));                               
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(Type type, Type[] types)
        //    {
        //        //创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            foreach (var subtype in types)
        //            {
        //                if (property.PropertyType.Name.Equals(subtype.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(subtype, types));
        //                }
        //            }
        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }
        //}
        #endregion

        #region 解决问题1，出现问题2
        //使用哈希字典 把foreach嵌套2次循环改成分开的2次foreach循环 解决出现问题：创建对象以及属性赋值的时候2次foreach循环会有性能问题，又出现新问题，如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            typesDict.Add(type.Name, type);
        //        }

        //        //第一次循环 创建对象实例
        //        foreach (var type in types)
        //        {
        //            var typeInstant = Activator.CreateInstance(type);
        //            //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //            var properties = type.GetProperties();
        //            foreach (var property in properties)
        //            {
        //                //情况1 A对象中有属性B
        //                foreach (var subtype in types)
        //                {
        //                    if (property.PropertyType.Name.Equals(subtype.Name))
        //                    {
        //                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                        property.SetValue(typeInstant, CreateObject(subtype, types));
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(Type type, Type[] types)
        //    {
        //        //创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            foreach (var subtype in types)
        //            {
        //                if (property.PropertyType.Name.Equals(subtype.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(subtype, types));
        //                }
        //            }
        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }
        //}
        #endregion

        #region 解决问题2，出新问题3
        //构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 
        //解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        //出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            typesDict.Add(type.Name, type);
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(string typeName)
        //    {
        //        //从哈希字典存储程序集中的所有的类对象查询对应类名的类
        //        Type type = typesDict[typeName];

        //        //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
        //        if (iocContainerDict.ContainsKey(typeName))
        //        {
        //            return iocContainerDict[typeName];
        //        }

        //        //第一次循环 创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //情况1 A对象中有属性B
        //            if (typesDict.ContainsKey(property.PropertyType.Name))
        //            {
        //                //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //            }

        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }

        //    /// <summary>
        //    /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
        //    /// </summary>
        //    /// <param name="typeName">需要创建的类名称</param>
        //    /// <returns>创建对应类的实例化对象</returns>
        //    public object GetCreateObject(string typeName)
        //    {
        //        if (typeName is null)
        //        {
        //            return null;
        //        }
        //        return CreateObject(typeName);
        //    }
        //}
        #endregion

        #region 解决问题3 出现问题4
        ////出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的
        ////使用attribute 特性标记需要的类和属性，那么就需要自定义标记需要的类的特性类和标记属性的特性类，
        ////自定义标记需要的类的特性类 ==》和标记属性的特性类
        ////构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        ////出现新问题 ：创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁

        ///// <summary>
        ///// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        ///// </summary>
        //public class ContainerFactory
        //{
        //    /// <summary>
        //    /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();

        //    /// <summary>
        //    /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
        //    /// </summary>
        //    private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

        //    public ContainerFactory()
        //    {
        //        //加载指定程序集
        //        Assembly assembly = Assembly.Load(@"F:\Person\aaa\LJTest\EFCOREDB\bin\Debug\net5.0\EFCOREDB.dll");
        //        //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
        //        //第一次循环
        //        var types = assembly.GetTypes();
        //        foreach (var type in types)
        //        {
        //            //获取带有[CustomPropertyAttribute]特性标记的类，只有带有自定义特性类的类型才可以通过容器来创建
        //            var customAttr = type.GetCustomAttribute(typeof(CustomTypeAttribute));
        //            if (customAttr is not null)
        //            {
        //                typesDict.Add(type.Name, type);
        //            }
        //            //typesDict.Add(type.Name, type);
        //        }
        //    }

        //    /// <summary>
        //    /// 创建对象的实例，包括对象中的所有属性的实例化等
        //    /// </summary>
        //    /// <param name="type"></param>
        //    /// <param name="types"></param>
        //    /// <returns></returns>
        //    public object CreateObject(string typeName)
        //    {
        //        //从哈希字典存储程序集中的所有的类对象查询对应类名的类
        //        Type type = typesDict[typeName];

        //        //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
        //        if (iocContainerDict.ContainsKey(typeName))
        //        {
        //            return iocContainerDict[typeName];
        //        }

        //        //第一次循环 创建对象实例
        //        var typeInstant = Activator.CreateInstance(type);
        //        //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
        //        var properties = type.GetProperties();
        //        foreach (var property in properties)
        //        {
        //            //获取带有[CustomPropertyAttribute]特性标记的属性，只有带有自定义特性类的属性才可以通过容器来创建
        //            var customAttr = property.GetCustomAttribute(typeof(CustomPropertyAttribute));
        //            if (customAttr is not null)
        //            {
        //                if (typesDict.ContainsKey(property.PropertyType.Name))
        //                {
        //                    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //                    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //                }
        //            }
        //            ////情况1 A对象中有属性B
        //            //if (typesDict.ContainsKey(property.PropertyType.Name))
        //            //{
        //            //    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
        //            //    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
        //            //}

        //        }
        //        //添加待哈希字典中，供以后DI使用
        //        iocContainerDict.Add(type.Name, typeInstant);
        //        return typeInstant;
        //    }

        //    /// <summary>
        //    /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
        //    /// </summary>
        //    /// <param name="typeName">需要创建的类名称</param>
        //    /// <returns>创建对应类的实例化对象</returns>
        //    public object GetCreateObject(string typeName)
        //    {
        //        if (typeName is null)
        //        {
        //            return null;
        //        }
        //        return CreateObject(typeName);
        //    }
        //}
        #endregion

        #region 解决问题4 创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁
        //出现新问题现在有好多类是不需要容器创建的，只需要根据需要来使用容器创建，属性也是同样的
        //使用attribute 特性标记需要的类和属性，那么就需要自定义标记需要的类的特性类和标记属性的特性类，
        //自定义标记需要的类的特性类 ==》和标记属性的特性类
        //构造函数中的2次foreach循环拆分一下，构造函数只做一次循环，目的就是把程序集中的类添加到哈希字典中即可，而创建对象的实例化的循环放到需要的时候在去创建和添加容器 解决出现问题：如果都在构造函数里面创建的话，会有性能问题，会导致初始化会很慢，如果程序集中有成千上百个类的话，很大可能初始化要十几分钟，这么长时间的初始化，肯定是不能容忍和接受的
        //出现新问题 ：创建A对象的实例时候遇到属性赋值--A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁

        /// <summary>
        /// 容器工厂,加载指定程序集，然后根据程序集中的类创建类的对象实例，使用的时候直接通过DI来依赖注入使用即可
        /// </summary>
        public class ContainerFactory : IContainerFactory
        {
            /// <summary>
            /// 容器，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, object> iocContainerDict = new Dictionary<string, object>();
            //Hashtable //HashSet

            /// <summary>
            /// 容器，哈希字典存储程序集中的所有的类对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

            /// <summary>
            /// 临时容器 解决死锁问题，哈希字典存储创建对象的实例化对象，使用字典，不适用list集合，因为字典的1、有唯一性保证，2、检索效率高，性能好，当然也可以使用Hashset
            /// </summary>
            private Dictionary<string, object> iocTempContainerDict = new Dictionary<string, object>();

            public ContainerFactory()
            {
                #region MyRegion
                //加载指定程序集
                //Assembly assembly = Assembly.LoadFile(@"F:\Person\aaa\LJTest\NetCoreClassLibrary\NetCoreClassLibrary\bin\Debug\net5.0\NetCoreClassLibrary.dll");
                Assembly assembly = Assembly.GetExecutingAssembly();
                //获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
                //第一次循环
                var types = assembly.GetTypes().Where(t => t.GetCustomAttribute(typeof(CustomTypeAttribute)) is not null);//获取具有标记的类
                foreach (var type in types)
                {
                    typesDict.Add(type.Name, type);
                    #region 获取具有标记的类
                    //获取带有[CustomPropertyAttribute]特性标记的类，只有带有自定义特性类的类型才可以通过容器来创建
                    //var customAttr = type.GetCustomAttribute(typeof(CustomTypeAttribute));                  
                    //if (customAttr is not null)
                    //{
                    //    typesDict.Add(type.Name, type);
                    //} 
                    #endregion
                }
                #endregion

                #region MyRegion
                ////加载指定程序集
                ////Assembly assembly = Assembly.LoadFile(@"F:\Person\aaa\LJTest\NetCoreClassLibrary\NetCoreClassLibrary\bin\Debug\net5.0\NetCoreClassLibrary.dll");                
                ////获取程序集中已经定义的类型,然后添加到哈希字典中，来提提高性能
                ////第一次循环
                //var types = assembly.GetTypes();
                //foreach (var type in types)
                //{
                //    //获取带有[CustomPropertyAttribute]特性标记的类，只有带有自定义特性类的类型才可以通过容器来创建
                //    var customAttr = type.GetCustomAttribute(typeof(CustomTypeAttribute));                   
                //    if (customAttr is not null)
                //    {
                //        typesDict.Add(type.Name, type);
                //    }
                //}
                #endregion
            }

            /// <summary>
            /// 创建对象的实例，包括对象中的所有属性的实例化等
            /// </summary>
            /// <param name="typeName">创建对象的名称</param>
            /// <returns>创建对象的实例</returns>
            public object CreateObject(string typeName)
            {
                //iocTempContainerDict 先取值 解决死锁问题-----A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁
                if (iocTempContainerDict.ContainsKey(typeName))
                {
                    return iocTempContainerDict[typeName];
                }

                //从哈希字典存储程序集中的所有的类对象查询对应类名的类
                Type type = typesDict[typeName];

                //判断容器冲是否包含类的实例对象，如果有直接取出返回，没有则创建并添加到容器中
                if (iocContainerDict.ContainsKey(typeName))
                {
                    return iocContainerDict[typeName];
                }

                //第一次循环 创建对象实例
                var typeInstant = Activator.CreateInstance(type);


                //iocTempContainerDict 存值 解决死锁问题-----A对象中有属性B，B对象中有属性C C对象中有属性A，这样兴成循环，会导致死锁
                //iocTempContainerDict.Add(typeName, typeInstant);
                iocTempContainerDict.Add(type.Name, typeInstant);

                //设置实例的属性,出现情况1、A对象中有属性B，2、B对象中有属性C 3、B对象中有属性A
                var properties = type.GetProperties().Where(t => t.GetCustomAttribute(typeof(CustomPropertyAttribute)) is not null);//获取具有标记的属性;
                foreach (var property in properties)
                {
                    if (typesDict.ContainsKey(property.PropertyType.Name))
                    {
                        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
                        property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
                    }

                    #region 获取具有标记的属性
                    ////获取带有[CustomPropertyAttribute]特性标记的属性，只有带有自定义特性类的属性才可以通过容器来创建
                    //var customAttr = property.GetCustomAttribute(typeof(CustomPropertyAttribute));
                    //if (customAttr is not null)
                    //{
                    //    if (typesDict.ContainsKey(property.PropertyType.Name))
                    //    {
                    //        //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
                    //        property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
                    //    }
                    //} 
                    #endregion

                    #region MyRegion
                    ////情况1 A对象中有属性B
                    //if (typesDict.ContainsKey(property.PropertyType.Name))
                    //{
                    //    //情况 2、A对象中有属性B，B对象中有属性C 这样又要嵌套一次，如果C里面还有的话，又要嵌套，因此可以使用递归来处理
                    //    property.SetValue(typeInstant, CreateObject(property.PropertyType.Name));
                    //} 
                    #endregion

                }
                //添加待哈希字典中，供以后DI使用
                iocContainerDict.Add(type.Name, typeInstant);
                return typeInstant;
            }

            /// <summary>
            /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
            /// </summary>
            /// <param name="typeName">需要创建的类名称</param>
            /// <returns>创建对应类的实例化对象</returns>
            public object GetCreateObject(string typeName)
            {
                if (typeName is null)
                {
                    return null;
                }
                return CreateObject(typeName);
            }
        }

        public class ContainerFactory2 : IContainerFactory
        {
            public object GetCreateObject(string typeName)
            {
                throw new NotImplementedException();
            }


        }

        /// <summary>
        /// 容器工厂接口
        /// </summary>
        public interface IContainerFactory
        {

            /// <summary>
            /// 根据需要传入需要创建的类名称，创建对应类的实例化对象，返回该实例化对象
            /// </summary>
            /// <param name="typeName">需要创建的类名称</param>
            /// <returns>创建对应类的实例化对象</returns>
            public object GetCreateObject(string typeName);

            /// <summary>
            /// 创建对象的实例，包括对象中的所有属性的实例化等，c# 8.0 以后接口可以定义接口和方法实现了，
            /// </summary>
            /// <param name="typeName">创建对象的名称</param>
            /// <returns>创建对象的实例</returns>
            public object CreateObject22(string typeName)
            {
                Type type = null;
                return type;
            }
        }
        #endregion
        #endregion

        #region Expression表达式树

        #region 表达式树的访问过程，并转化成sql语句
        /// <summary>
        /// 访问 表达式树 Expression<Func<MyClass, bool>> expressionFunc = x => x.Age > 5 &&  x.Id == 8;
        /// 并转化成sql语句 select * from MyClass where age > 5 and id = 8
        /// </summary>
        public class OperatorExpressionToSql : ExpressionVisitor
        {
            /// <summary>
            /// 存放Expression表达式树的内容
            /// </summary>
            public Stack<string> StackSet { get; set; }

            public OperatorExpressionToSql()
            {
                StackSet = new Stack<string>();
                StackSet.Push("(");
            }
            /// <summary>
            /// 修改表达式树的形式
            /// </summary>
            /// <param name="expression"></param>
            /// <returns></returns>
            public Expression Modify(Expression expression)
            {
                //base.Visit(expression);
                //if (expression is BinaryExpression binary)
                //{
                //    if (binary.NodeType == ExpressionType.Add)
                //    {
                //        var left = base.Visit(binary.Left); ;
                //        var right = base.Visit(binary.Right);
                //        var result = Expression.Subtract(left, right);
                //        return result;
                //    }
                //}
                return base.Visit(expression);
            }

            /// <summary>
            /// 表达式树的二元操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (node.NodeType == ExpressionType.AndAlso)
                {
                    base.Visit(node.Left);
                    StackSet.Push("and");
                    base.Visit(node.Right);
                    //var result = Expression.Subtract(left, right);
                    //return result;
                    StackSet.Push(")");
                }
                else if (node.NodeType == ExpressionType.GreaterThan)
                {
                    if (node.Left is MemberExpression member)
                    {
                        StackSet.Push(member.Member.Name);
                    }
                    StackSet.Push(">");
                    if (node.Right is ConstantExpression constant)
                    {
                        StackSet.Push(constant.Value.ToString());
                    }
                }
                else if (node.NodeType == ExpressionType.Equal)
                {
                    if (node.Left is MemberExpression member)
                    {
                        StackSet.Push(member.Member.Name);
                    }
                    StackSet.Push("=");
                    if (node.Right is ConstantExpression constant)
                    {
                        StackSet.Push(constant.Value.ToString());
                    }
                }

                //StackSet.Push(node.Value.ToString());
                return node;
                //return base.VisitBinary(node);
            }

            /// <summary>
            /// 表达式树的常量操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitConstant(ConstantExpression node)
            {
                StackSet.Push(node.Value.ToString());
                return base.VisitConstant(node);
            }
        }

        /// <summary>
        /// 测试表达式树的访问过程，并转化成sql语句
        /// </summary>
        public static void TestDynamicExpressionToSql()
        {
            //访问 表达式树 
            Expression<Func<MyClass, bool>> expressionFunc = x => x.Age > 5 && x.Name == "8";
            /// 并转化成sql语句 select * from MyClass where age > 5 and id = 8
            OperatorExpressionToSql visitor = new OperatorExpressionToSql();
            var expression = visitor.Modify(expressionFunc.Body);
            var d = string.Join(' ', visitor.StackSet.Reverse().ToArray());
            //while (visitor.StackSet.Count > 0)
            //{
            //    Console.WriteLine($"结果：{visitor.StackSet.Pop()}");
            //}
            Console.WriteLine($"结果：{d}");
        }
        #endregion

        #region 访问 表达式树
        /// <summary>
        /// 访问 表达式树 Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
        /// (m, n) => m * n + 2;改成(m, n) => m * n - 2;
        /// </summary>
        public class OperatorExpressionVisitor : ExpressionVisitor
        {
            /// <summary>
            /// 存放Expression表达式树的内容
            /// </summary>
            public Stack<string> StackSet { get; set; }


            /// <summary>
            /// 修改表达式树的形式
            /// </summary>
            /// <param name="expression"></param>
            /// <returns></returns>
            public Expression Modify(Expression expression)
            {
                //base.Visit(expression);
                if (expression is BinaryExpression binary)
                {
                    if (binary.NodeType == ExpressionType.Add)
                    {
                        var left = base.Visit(binary.Left); ;
                        var right = base.Visit(binary.Right);
                        var result = Expression.Subtract(left, right);
                        return result;
                    }
                }
                return expression;
            }

            /// <summary>
            /// 表达式树的二元操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitBinary(BinaryExpression node)
            {
                return base.VisitBinary(node);
            }

            /// <summary>
            /// 表达式树的常量操作
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            protected override Expression VisitConstant(ConstantExpression node)
            {
                return base.VisitConstant(node);
            }
        }

        /// <summary>
        /// 测试表达式树的访问过程
        /// </summary>
        public static void TestDynamicExpressionVisitor()
        {
            Expression<Func<int, int, int>> predicate = (m, n) => m * n + 2;
            //修改之前
            var func1 = predicate.Compile();
            var result1 = func1.Invoke(2, 3);
            Console.WriteLine($"参数2，3");
            Console.WriteLine($"修改---前");
            Console.WriteLine($"body：{predicate.Body}");
            Console.WriteLine($"结果：{result1}");
            OperatorExpressionVisitor visitor = new OperatorExpressionVisitor();
            var expression = visitor.Modify(predicate.Body);
            Expression<Func<int, int, int>> lam = Expression.Lambda<Func<int, int, int>>(expression, predicate.Parameters);
            var func = lam.Compile();
            var result = func.Invoke(2, 3);
            Console.WriteLine($"修改---后");
            Console.WriteLine($"body：{lam.Body}");
            Console.WriteLine($"结果：{result}");
        }
        #endregion

        /// <summary>
        /// 测试动态表达式树一般拼接Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
        /// </summary>
        public static void TestDynamicExpression()
        {
            //IEnuable与IQueryable
            //var list = new List<int>().AsQueryable();
            //list = list.Where(c => c > 1);//参数：Expression<Func<TSource, bool>> predicate，如：Expression<Func<int, bool>> predicate = c => c > 1;
            Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
            //注意：Expression不能使用大括号，来写lambda表达式，如下写法，会报错
            //Expression<Func<int, int, int>> predicate2 = delegate (m, n) { return m* n +2};


            //var list1 = new List<int>();
            //var list2 = list1.Where(c => c > 1);//参数：Func<TSource, bool> predicate，如：Func<int, bool> predicate1 = c => c > 1;
            Func<int, bool> predicate6 = c => c > 1;
            Func<int, bool> predicate7 = delegate (int c)//delegate可以使用大括号，来写lambda表达式
            {
                return c > 1;
            };

            if (predicate7.Invoke(3))
            {
                Console.WriteLine("调用 Func<int, bool> predicate7 predicate7.Invoke(3) 成功。。。");
            }

            //构造=====》Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2;
            //(m, n) => m * n + 2;
            //1、左边的参数 (m, n)
            var paramM = Expression.Parameter(typeof(int));
            var paramN = Expression.Parameter(typeof(int));
            //2、m * n + 2;
            //2.1 右边的成员字段 m, n
            //var fieldM = Expression.Field(typeof(int),"m");
            //var fieldN = Expression.Variable(typeof(int), "n");
            //2.2 右边的成员字段 m * n
            var fieldMN = Expression.Multiply(paramM, paramN);
            //2.3 右边的成员常量字段 2
            var fieldConstant = Expression.Constant(2, typeof(int));
            //2.4 右边的成员m * n + 2;
            var memberField = Expression.Add(fieldMN, fieldConstant);
            //2.5 右边的成员常量字段 2
            Expression<Func<int, int, int>> lam = Expression.Lambda<Func<int, int, int>>(memberField, new ParameterExpression[] { paramM, paramN });
            var func = lam.Compile();

            var result = func.Invoke(2, 3);
            Console.WriteLine($"构造=====》Expression<Func<int, int, int>> predicate1 = (m, n) => m * n + 2 输出结果：{result}");

            #region #region 区分IEnuable与IQueryable 测试lambda expression 动态拼接方式2

            //List<int> grades1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Expression<Func<int, bool>> expression = t => true;
            //expression = expression.And1(t => t >2);
            //expression = expression.And1(t => t <8);
            //var ds = grades1.AsQueryable().Where(expression).ToList();
            //foreach (var item in ds)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //}
            #endregion

            //Console.WriteLine($"###########");
            #region 区分IEnuable与IQueryable 测试lambda expression 动态拼接方式1
            //var list0 = new List<MyClass>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list0.Add(new MyClass { Age = i, Name = i.ToString() });
            //}

            ////IEnuable
            //var result = list0.Where(a => a.Age > 5).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"IEnuable Age:{item.Age},Name:{item.Name}");
            //}
            //Console.WriteLine($"###########");

            ////IQueryable
            //Expression<Func<MyClass, bool>> exp = a => a.Age > 5;
            //Expression<Func<MyClass, bool>> exp2 = a => a.Name == "8";
            //exp = exp.And(exp2);
            //result = list0.AsQueryable<MyClass>().Where(exp).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"IQueryable:Age:{item.Age},Name:{item.Name}");
            //} 
            #endregion

            //Console.WriteLine($"###########");
            #region 测试lambda expression 的查询条件拼接
            //List<int> grades = new List<int> { 78, 92, 100, 37, 81 };
            //// Convert the List to an IQueryable<int>.
            //IQueryable<int> iqueryable = grades.AsQueryable();
            //Expression<Func<int, bool>> exp3 = a => a > 81;
            //Expression<Func<int, bool>> exp4 = a => a < 101;
            //exp3 = exp3.And(exp4);
            //var result3 = iqueryable.Where(exp3).ToList();
            //foreach (var item in result3)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //}

            //Console.WriteLine($"###########");
            //List<int> grades1 = new List<int> { 78, 92, 100, 37, 81 };
            //Expression<Func<int, bool>> expression = t => true;
            //expression = expression.And(t => t == 92);
            //expression = expression.And(t => t > 78);
            //var ds = grades1.AsQueryable().Where(expression).ToList();
            //foreach (var item in ds)
            //{
            //    Console.WriteLine($"IQueryable:{item}");
            //} 
            #endregion

            //expression_t => false;
            //expression_t = expression_t.Or(x => x.AAA == 1);
            //expression_t = expression_t.Or(x => x.BBB == 2);
            //expression = expression.And(expression_t);

        }

        /// <summary>
        /// 测试动态表达式树一般拼接Expression<Func<MyClass, int>> expressionFunc = x => x.Age + 1;
        /// </summary>
        public static void TestExpression()
        {
            #region Expression simple
            //Expression<Func<int, int>> expressionFunc = x => x + 1;
            //var func = expressionFunc.Compile();
            //var result = func(22);
            //Console.WriteLine($"Expression<Func<int, int>>执行结果：{result}");
            #endregion

            #region Expression complex
            //Expression<Func<MyClass, int>> expressionFunc = x => x.Age + 1;
            //x => x.Age + 1 lambda表达式的具体构造过程，如下，
            //lambda表达式 等号 左边的参数parameter
            ParameterExpression paramLeft = Expression.Parameter(typeof(MyClass));

            //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 x.Age 
            MemberExpression memberRight = Expression.PropertyOrField(paramLeft, "Age"); //MyClass的Age属性，可以再构造lambda表达式的时候传入，这样就可以根据需要来构造表达式了
                                                                                         //MemberExpression memberRight2 = Expression.Field(paramLeft, "Age"); 
                                                                                         //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 1 常量 
            ConstantExpression constantRight = Expression.Constant(1, typeof(int));

            //lambda表达式 等号 右边的参数parameter  x.Age + 1中的 + 加号
            BinaryExpression binaryRight = Expression.Add(memberRight, constantRight);

            //lambda表达式 等号 两边的参数parameter  x => x.Age + 1;中的 => goto符号 x => x + 1;
            Expression<Func<MyClass, int>> expressionFunc = Expression.Lambda<Func<MyClass, int>>(binaryRight, paramLeft);

            //Expression<Func<int, int>> expressionFunc = x => x + 1;
            var func = expressionFunc.Compile();
            MyClass myClass = new() { Age = 11 };
            var result = func(myClass);
            //result = func.Invoke(myClass);
            Console.WriteLine($"自定义构造lambda表达式树，产生Expression<Func<MyClass, int>>执行结果：{result}");
            #endregion
        }

        #endregion

        #region HashSet

        public static void TestHashSet()
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("123");
            hs.Add("456");
            hs.Add("789");
            //if (hs.Contains("123"))
            //{
            //    Console.WriteLine($"HashSet的长度：{hs.Count}");
            //    if (hs.Remove("123"))
            //    {
            //        Console.WriteLine($"HashSet删除元素之后的长度：{hs.Count}");
            //    }
            //    Console.WriteLine($"HashSet的长度：{hs.Count}");
            //}
            hs.Add("1");
            hs.Add("2");
            hs.Add("3");
            //foreach (var item in hs)
            //{
            //    Console.WriteLine($"{item}");
            //}

            HashSet<string> hs1 = new HashSet<string>(Enumerable.Range(1, 10).Select(x => x.ToString()));
            var result = hs.Intersect(hs1);
            Console.WriteLine($"----------------------");
            foreach (var item in hs)
            {
                Console.WriteLine($"{item}");
            }
            hs.IntersectWith(hs1);
            Console.WriteLine($"####################");
            foreach (var item in hs)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"----------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }
        }

        #endregion

        #region static
        public static void TestStatic()
        {
            List<MyClass> myClasses = new();
            for (int i = 0; i < 10; i++)
            {
                //myClasses.Add(new MyClass { ClassName = "一班", Name = i.ToString(), Age = i });

                var c = new MyClass { Name = i.ToString(), Age = i };
                MyClass.ClassName = i.ToString();
                myClasses.Add(c);
            }
            foreach (var item in myClasses)
            {
                //Console.WriteLine($"输出信息：班级：{item.ClassName}，姓名：{item.Name}，年龄：{item.Age}");
                Console.WriteLine($"输出信息：班级：{MyClass.ClassName}，姓名：{item.Name}，年龄：{item.Age}");
            }
        }
        #endregion

        #region Hangfire定时任务
        /// <summary>
        /// Hangfire定时任务
        /// </summary>
        public static void TestHangfire()
        {
            var queueStr = BackgroundJob.Enqueue(() => WriteLog("任务添加到队列之中"));
            string v = BackgroundJob.Schedule(() => WriteLog("延时任务"), TimeSpan.FromSeconds(2));
            string v1 = BackgroundJob.ContinueJobWith(queueStr, () => WriteLog("queueStr任务执行之后的任务。。。。"));
            RecurringJob.AddOrUpdate(() => WriteLog("RecurringJob"), Cron.Minutely);
        }

        public static void WriteLog(string str)
        {
            Console.WriteLine($"queueStr任务执行{str}");
        }

        #endregion

        #region QuartZ定时任务
        /// <summary>
        /// QuartZ定时任务
        /// </summary>
        public static async void TestQuartZ()
        {
            var factory = new StdSchedulerFactory();
            //var scheduler1 = factory.GetScheduler().GetAwaiter().GetResult();
            var scheduler = await factory.GetScheduler();
            //await scheduler.Start();
            var job = JobBuilder.Create<MyJob>().WithIdentity("job1", "group1").Build();
            var triger = TriggerBuilder.Create().WithIdentity("job1", "group1")
                .StartNow()
                .WithSimpleSchedule(sc => sc.WithInterval(TimeSpan.FromSeconds(5)).RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, triger);
            await scheduler.Start();
        }
        [DisallowConcurrentExecution]
        public class MyJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                return Task.Run(() => { Console.WriteLine($"{DateTime.Now}:执行任务"); });
                //return Console.Out.WriteLineAsync($"{DateTime.Now}:执行任务");
            }
        }

        /// <summary>
        /// 任务创建工厂
        /// </summary>
        public class CustomQuartzJobFactory : IJobFactory
        {
            private readonly IServiceProvider _serviceProvider;

            public CustomQuartzJobFactory(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
            {
                var jobDetail = bundle.JobDetail;
                return (IJob)_serviceProvider.GetService(jobDetail.JobType);
            }

            public void ReturnJob(IJob job)
            {

            }
        }

        #endregion

        #region 线程取消
        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel()
        {
            using CancellationTokenSource source = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(_ => TestThreancancel1(source.Token));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source.Cancel();

            using CancellationTokenSource source1 = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem((_) => { TestThreancancel2(source1.Token); });
            //source1.CancelAfter(TimeSpan.FromSeconds(3));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source1.Cancel();

            using CancellationTokenSource source2 = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem((_) => { TestThreancancel3(source2.Token); });
            //source2.CancelAfter(TimeSpan.FromSeconds(3));
            Thread.Sleep(TimeSpan.FromSeconds(3));
            source2.Cancel();
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel1(CancellationToken token)
        {
            Console.WriteLine($"第一个线程开始执行");
            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"第一个线程已经取消了。。。");
                    return;
                }
                Console.WriteLine($"第一个线程TestThreancancel 输出值：{i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                //Console.WriteLine($"第一个线程TestThreancancel 输出值：{i}");
            }
            Console.WriteLine($"第一个线程成功执行");
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel2(CancellationToken token)
        {
            Console.WriteLine($"第二个线程开始执行");
            bool isCanceled = false;
            token.Register(() => { isCanceled = true; });
            for (int i = 0; i < 10; i++)
            {
                if (isCanceled)
                {
                    Console.WriteLine($"第二个线程已经取消了。。。");
                    return;
                }
                Console.WriteLine($"第二个线程TestThreancancel 输出值：{i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                //Console.WriteLine($"第二个线程TestThreancancel 输出值：{i}");
            }
            Console.WriteLine($"第二个线程成功执行");
        }

        /// <summary>
        /// 线程取消
        /// </summary>
        public static void TestThreancancel3(CancellationToken token)
        {
            Console.WriteLine($"第三个线程开始执行");
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"第三个线程TestThreancancel 输出值：{i}");
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    //Console.WriteLine($"第三个线程TestThreancancel 输出值：{i}");
                }
                Console.WriteLine($"第三个线程成功执行");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"第三个线程已经取消了。。。");
            }
        }
        #endregion

        #region Task and CancellationTokenSource

        /// <summary>
        /// 任务的链式取消
        /// </summary>
        public async static void TestTaskLinkedCancel()
        {
            Console.WriteLine($"链接取消任务开始。。。。");
            await Task.Delay(TimeSpan.FromSeconds(1));
            CancellationTokenSource source1 = new CancellationTokenSource();
            var token1 = source1.Token;
            token1.Register(() => { Console.WriteLine($"任务--1--取消回调"); });
            CancellationTokenSource source2 = new CancellationTokenSource();
            var token2 = source2.Token;
            token2.Register(() => { Console.WriteLine($"任务--2--取消回调"); });
            CancellationTokenSource source3 = CancellationTokenSource.CreateLinkedTokenSource(token1, token2);
            var token3 = source3.Token;
            token3.Register(() => { Console.WriteLine($"任务--3--取消回调"); });
            source1.CancelAfter(TimeSpan.FromSeconds(3));
        }

        /// <summary>
        /// 同步任务和异步任务的对比
        /// </summary>
        public static void TestTaskSync()
        {
            Console.WriteLine($"当前线程:{ Thread.CurrentThread.ManagedThreadId}");
            //创建异步任务
            var taskAsync = Task.Run(() =>
            {
                Console.WriteLine($"异步任务：{Task.CurrentId}，运行的线程:{ Thread.CurrentThread.ManagedThreadId}");
                int sum = 0;
                Parallel.For(1, 10000, (i) => { Interlocked.Add(ref sum, i); });
                return sum;
            });

            //创建同步任务
            var taskSync = new Task<long>(() =>
            {
                Console.WriteLine($"同步任务：{Task.CurrentId}，运行的线程:{ Thread.CurrentThread.ManagedThreadId}");
                int sum2 = 0;
                Parallel.For(1, 10000, (i) => { Interlocked.Add(ref sum2, i); });
                return sum2;
            });

            taskSync.RunSynchronously();
            Console.WriteLine($"同步任务：{taskSync.Id}，运行的线程的结果:{ taskSync.Result}");
            Console.WriteLine($"异步任务：{taskAsync.Id}，运行的线程的结果:{ taskAsync.Result}");
        }

        public static void TestThreadCancel()
        {
            SpinLock spinLock = new SpinLock(false);
            object obj = new object();
            int sun1 = 0;
            int sun2 = 0;
            int sun3 = 0;

            //不加锁
            Parallel.For(1, 10000, i =>
            {
                sun1 += i;
            });

            //不加锁
            Parallel.For(1, 10000, i =>
            {
                bool islock = false;
                try
                {
                    spinLock.Enter(ref islock);
                    sun2 += i;
                }
                finally
                {
                    if (islock)
                    {
                        spinLock.Exit(false);
                    }
                }
            });
            //不加锁
            Parallel.For(1, 10000, i =>
            {
                lock (obj)
                {
                    sun3 += i;
                }

            });

            Console.WriteLine($"sun1={sun1}");
            Console.WriteLine($"sun2={sun2}");
            Console.WriteLine($"sun3={sun3}");
        }

        /// <summary>
        /// 测试取消
        /// </summary>
        public static void TestTaskThreadCancel()
        {
            #region MyRegion
            //var tokenSource = new CancellationTokenSource();//创建取消task实例
            //var testTask = new Task(() =>
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //    }
            //}, tokenSource.Token);
            //Console.WriteLine(testTask.Status);
            //testTask.Start();
            //Console.WriteLine(testTask.Status);
            //tokenSource.Token.Register(() =>
            //{
            //    Console.WriteLine("task is to cancel");
            //});
            //tokenSource.Cancel();
            //Console.WriteLine(testTask.Status);
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    Console.WriteLine(testTask.Status);
            //} 
            #endregion
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                var task = new Task(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }, token);//TaskCreationOptions.LongRunning
                token.Register(() => { Console.WriteLine($"任务取消了。。。。"); });
                Console.WriteLine($"task 状态 :{task.Status}");

                task.Start();
                Console.WriteLine($"task 状态 :{task.Status}");
                tokenSource.Cancel();
                Console.WriteLine($"task 状态 :{task.Status}");
                Console.WriteLine($"task是否取消看下面的 状态 ");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"task 状态 :{task.Status}");
                }
            }
            catch (AggregateException agg)
            {
                foreach (var item in agg.InnerExceptions)
                {
                    if (item is TaskCanceledException ex)
                        Console.WriteLine($"任务取消:{ex.Message}");
                    else
                        Console.WriteLine($"任务取消:{item.GetType().Name}");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        /// <summary>
        /// 测试取消
        /// </summary>
        public static void TestTaskCancel()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            TaskFactory factory = new TaskFactory(token);
            List<Task<int[]>> list = new List<Task<int[]>>();
            Random random = new Random();
            object lockObj = new object();
            for (int i = 0; i <= 10; i++)
            {
                list.Add(factory.StartNew(() =>
                {
                    int[] vs = new int[10];
                    int randomNum;
                    for (int j = 0; j < 10; j++)
                    {
                        lock (lockObj)
                        {
                            randomNum = random.Next(0, 101);
                        }

                        if (randomNum == 0)
                        {
                            tokenSource.Cancel();
                            Console.WriteLine($"当前任务是:{i + 1}");
                            break;
                        }
                        vs[j] = randomNum;
                    }
                    return vs;
                }, token));
            }

            try
            {
                var ts = factory.ContinueWhenAll(list.ToArray(), (taskList) =>
                {
                    long sum = 0;
                    int accumulate = 0;
                    foreach (var item in taskList)
                    {
                        foreach (var subitem in item.Result)
                        {
                            sum = +subitem;
                            accumulate++;
                        }
                    }
                    return sum / (double)accumulate;
                }, token);
                Console.WriteLine($"所有任务累加的结果:{ts.Result}");
            }
            catch (AggregateException agg)
            {
                foreach (var item in agg.InnerExceptions)
                {
                    if (item is TaskCanceledException ex)
                        Console.WriteLine($"任务取消:{ex.Message}");
                    else
                        Console.WriteLine($"任务取消:{item.GetType().Name}");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        public static void TestTaskCancel1()
        {
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}",
                                          ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally
            {
                source.Dispose();
            }
        }
        #endregion

        #region 测试并发字典ConcurrentDictionary
        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async void GetAsync()
        {
            var iterator = GetEnumeratorAsyncFor();
            while (await iterator.MoveNextAsync())
            {
                Console.WriteLine($"输出{iterator.Current}");
            }
            #region MyRegion
            //var iterator = GetEnumeratorAsync();
            //    var result = await iterator.MoveNextAsync();
            //    while (result)
            //    {
            //        Console.WriteLine($"输出{iterator.Current}");
            //        result = await iterator.MoveNextAsync();
            //    }

            //    //while (await iterator.MoveNextAsync())
            //    //{
            //    //    Console.WriteLine($"输出{iterator.Current}");
            //    //} 
            #endregion
            Console.WriteLine("GetAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async IAsyncEnumerator<string> GetEnumeratorAsyncFor()
        {
            for (int i = 0; i < 10; i++)
            {
                //await Task.Delay(1000);
                //yield return i.ToString();

                await Task.Delay(1000).ContinueWith((_) =>
                {
                    Console.WriteLine($"迭代器--异步--{i}");
                });
                yield return i.ToString();
            }
            Console.WriteLine("GetEnumeratorAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器--异步
        /// </summary>
        /// <returns></returns>
        static async IAsyncEnumerator<string> GetEnumeratorAsync()
        {
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "B";
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "C";
            await Task.Delay(1000);
            //Console.WriteLine("输出A");
            yield return "D";
            Console.WriteLine("GetEnumeratorAsync---结束。。。。");
        }

        /// <summary>
        /// 迭代器
        /// </summary>
        /// <returns></returns>
        static IEnumerator<string> GetEnumerator()
        {
            yield return "A";
            //Console.WriteLine("输出A");
            yield return "B";
            //Console.WriteLine("输出A");
            yield return "C";
            //Console.WriteLine("输出A");
            yield return "D";
            Console.WriteLine("结束。。。。");
        }

        /// <summary>
        /// 测试并发字典ConcurrentDictionary
        /// </summary>
        static void TestConcurrentDictionary()
        {
            #region MyRegion
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();
            Parallel.For(1, 100, i =>
            {
                cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            });
            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);
            // Should return 100, as key 2 is not yet in the dictionary
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);

            // Should return 100, as key 2 is already set to that value
            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
            //Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);
            #endregion
        }
        #endregion

        #region Database数据库操作
        /// <summary>
        /// 测试数据库的分库分表，表映射，切换表
        /// </summary>
        static void TestDBContext()
        {
            #region DBContext
            //DateTime datetime1 = DateTime.Now;
            //using (var context = new DynamicContext { CreateDateTime = datetime1 })
            //{
            //    Console.WriteLine("开始删除数据库");
            //    context.Database.EnsureDeleted();
            //    Console.WriteLine("删除成功");
            //    Console.WriteLine("开始创建数据库");
            //    context.Database.EnsureCreated();
            //    Console.WriteLine("创建成功");
            //    var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();
            //    #region MyRegion
            //    //context.Tests.Add(new Test { Title = "Great News One", Content = $"Hello World! I am the news of {datetime1}", CreateDateTime = datetime1 });
            //    //更新实体的方式
            //    //0、查询实体，修改实体字段，context.SaveChanges();
            //    //1、创建实体，context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //2、创建实体，context.Update(创建的实体); context.SaveChanges();
            //    //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.ChangeTracker.DetectChanges(); context.SaveChanges();
            //    //3、创建实体，context.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
            //    //4、context.ChangeTracker.TrackGraph(ss, e => {
            //    //    if ((e.Entry.Entity as Test) != null)
            //    //    {
            //    //        e.Entry.State = EntityState.Unchanged;
            //    //    }
            //    //    else
            //    //    {
            //    //        e.Entry.State = EntityState.Modified;
            //    //    }
            //    //});
            //    //context.SaveChanges(); 
            //    #endregion

            //    var ss = new Test { Title = "11", Content = $"111 {datetime1}", CreateDateTime = datetime1 };
            //    Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
            //    //context.Attach(ss);//告诉EF Core开始跟踪person实体的更改，因为调用DbContext.Attach方法后，EF Core会将person实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改回EntityState.Unchanged，所以这里testDBContext.Attach(ss)一定要放在下面一行testDBContext.Entry(ss).Property(p => p.Content).IsModified = true的前面，否者后面的testDBContext.SaveChanges方法调用后，数据库不会被更新
            //    //context.Entry(ss).Property(p => p.Content).IsModified = true;//告诉EF Core实体ss的Content属性已经更改。将testDBContext.Entry(person).Property(p => p.Name).IsModified设置为true后，也会将ss实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改为EntityState.Modified，这样就保证了下面SaveChanges的时候会将ss实体的Content属性值Update到数据库中。
            //    //context.Entry(ss).Property(p => p.Content).IsModified = true;
            //    //context.Tests.Attach(ss);
            //    context.Attach(ss);
            //    Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
            //    //context.ChangeTracker.DetectChanges();
            //    context.SaveChanges();
            //}

            ////切换表
            //DateTime datetime2 = DateTime.Now.AddDays(-1);
            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();//查询实体映射到数据库中对应的表名称
            //    if (!tablename.Equals("20201118"))
            //    {
            //        //var str = GetMySQLSqls(datetime2);
            //        var str = GetSqlServerSqls(datetime2);

            //        //判断是否存在表，不存在则创建
            //        using var cmd = context.Database.GetDbConnection().CreateCommand();
            //        cmd.CommandText = str[0];
            //        if (cmd.Connection.State != System.Data.ConnectionState.Open)
            //        {
            //            cmd.Connection.Open();
            //        }
            //        var result = cmd.ExecuteScalar();
            //        if (result.ToString() == "0")
            //        {
            //            //创建新表
            //            context.Database.ExecuteSqlRaw(str[1]);
            //        }
            //    }

            //    //context.Database.EnsureCreated();
            //    context.Tests.Add(new Test { Title = "22", Content = $"222 {datetime2}", CreateDateTime = datetime2 });
            //    context.SaveChanges();
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime1 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of today
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of yesterday
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //} 
            #endregion
        }

        #region Database数据库操作
        private static string[] GetMySQLSqls(DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string decide = $"SELECT count(1) FROM information_schema.TABLES WHERE table_name='{tableName}'";
            string sqlRaw = $@"
CREATE TABLE IF NOT EXISTS `{tableName}` (
  `Id` int(20) NOT NULL,
  `Title` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Content` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateDateTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetSqlServerSqls(DateTime time)
        {
            //注意：[Id] int NOT NULL IDENTITY(1,1)中的 IDENTITY(1,1) 表示自增
            string tableName = time.ToString("yyyyMMdd");
            //-- 判断要创建的表名是否存在 select * from dbo.sysobjects where id=object_id(N'[dbo].[{0}]') and xtype='U'
            string decide = $"SELECT COUNT(1) FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[{tableName}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            string sqlRaw = $@"IF NOT EXISTS ( SELECT * FROM dbo.sysobjects WHERE id=object_id(N'[dbo].[{tableName}]') AND xtype='U')
BEGIN
CREATE TABLE [dbo].[{tableName}] (
[Id] int NOT NULL IDENTITY(1,1),
[Title] nvarchar(20) NULL ,
[Content] nvarchar(500) NULL ,
[CreateDateTime] datetime2(7) NOT NULL ,
);
ALTER TABLE [dbo].[{tableName}] ADD PRIMARY KEY ([Id]);
END";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetOracleSqls(string defaultSchema, DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string schema = defaultSchema;
            string id_seq = $"{tableName}_id_seq";
            var pk = $"PK_{tableName}";
            string decide = $"SELECT COUNT(1) FROM all_tables WHERE TABLE_NAME='{tableName}' AND OWNER='{schema}'";
            string sqlRaw =
        $@"DECLARE num NUMBER;
BEGIN
	SELECT
		COUNT(1) INTO num 
	FROM
		all_tables 
	WHERE
		TABLE_NAME = '{tableName}' 
		AND OWNER = '{schema}';
	IF
		num = 0 THEN
			EXECUTE IMMEDIATE 'CREATE TABLE ""{schema}"".""{tableName}"" (
            ""Id"" NUMBER(10) NOT NULL,
            ""Title"" NVARCHAR2(20),
            ""Content"" NCLOB,
            ""CreateDateTime"" TIMESTAMP(7) NOT NULL,
            CONSTRAINT ""{pk}"" PRIMARY KEY(""Id""),
            )';

            EXECUTE IMMEDIATE 'CREATE SEQUENCE ""{schema}"".""{id_seq}"" START WITH 1 INCREMENT BY 1';
            END IF;
            END; ";
            return new string[] { decide, sqlRaw };
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// 测试类
    /// </summary>
    public class MyClass
    {
        //public MyClass()
        //{
        //    ClassName = "一般";
        //}
        public int Age { get; set; }
        public string Name { get; set; }
        public static string ClassName { get; set; } = "一般";

    }

    #region lambda expression 拼接方式1
    /// <summary>
    /// Expression表达式树
    /// </summary>
    public class LambdaParameteRebinder : ExpressionVisitor
    {
        /// <summary>
        /// 存放表达式树的参数的字典
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map"></param>
        public LambdaParameteRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 重载参数访问的方法，访问表达式树参数，如果字典中包含，则取出
        /// </summary>
        /// <param name="node">表达式树参数</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (map.TryGetValue(node, out ParameterExpression expression))
            {
                node = expression;
            }
            return base.VisitParameter(node);
        }

        public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new LambdaParameteRebinder(map).Visit(exp);
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExtension
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="merge"></param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var parameterMap = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = LambdaParameteRebinder.ReplaceParameter(parameterMap, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() => f => false;

        /// <summary>
        /// Expression表达式树lambda参数拼接-true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() => f => true;

        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);
    }
    #endregion

    #region lambda expression 拼接方式2
    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法扩展类
    /// </summary>
    public class LambdaExpressionParameter : ExpressionVisitor
    {
        /// <summary>
        /// 表达式数的lambda参数
        /// </summary>
        public ParameterExpression parameterExpression { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameterExpression"></param>
        public LambdaExpressionParameter(ParameterExpression parameterExpression)
        {
            this.parameterExpression = parameterExpression;
        }

        /// <summary>
        /// 替代方法
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Expression Replace(Expression expression)
        {
            return base.Visit(expression);
        }

        /// <summary>
        /// 重载参数访问的方法，处理参数表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.parameterExpression;
        }
    }

    /// <summary>
    /// 表达式数的lambda参数的拼接扩展方法
    /// </summary>
    public static class LambdaExpressionExtend
    {
        /// <summary>
        /// Expression表达式树lambda参数拼接--and
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or1<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            //var param = first.Parameters[0];
            var param = Expression.Parameter(typeof(T), "w");//指定参数和参数名称
            LambdaExpressionParameter lambdaExpression = new LambdaExpressionParameter(param);
            var left = lambdaExpression.Replace(first.Body);
            var right = lambdaExpression.Replace(second.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        /// <summary>
        /// Expression表达式树lambda参数拼接--not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not1<T>(this Expression<Func<T, bool>> expression)
        {
            var param = expression.Parameters[0];//指定参数和参数名称
                                                 //var param = Expression.Parameter(typeof(T), "w");
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
    #endregion

    #region 源码
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> map;

    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    //    {
    //        return new ParameterRebinder(map).Visit(exp);
    //    }

    //    protected override Expression VisitParameter(ParameterExpression p)
    //    {
    //        ParameterExpression replacement;
    //        if (map.TryGetValue(p, out replacement))
    //        {
    //            p = replacement;
    //        }
    //        return base.VisitParameter(p);
    //    }
    //}

    //public static class PredicateBuilder
    //{

    //    public static Expression<Func<T, bool>> True<T>() { return f => true; }
    //    public static Expression<Func<T, bool>> False<T>() { return f => false; }
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        // build parameter map (from parameters of second to parameters of first)  
    //        var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

    //        // replace parameters in the second lambda expression with parameters from the first  
    //        var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

    //        // apply composition of lambda expression bodies to parameters from the first expression   
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    //    {
    //        return first.Compose(second, Expression.And);
    //    }

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    //    {
    //        return first.Compose(second, Expression.Or);
    //    }

    //} 
    #endregion

    #region MyRegion
    ///// <summary>
    ///// Expression表达式树
    ///// </summary>
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    /// <summary>
    //    /// 存放表达式树的参数的字典
    //    /// </summary>
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> map;

    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="map"></param>
    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) => new ParameterRebinder(map).Visit(exp);
    //    //{
    //    //    return new ParameterRebinder(map).Visit(exp);
    //    //}

    //    /// <summary>
    //    /// 访问表达式树参数，如果字典中包含，则取出
    //    /// </summary>
    //    /// <param name="node">表达式树参数</param>
    //    /// <returns></returns>
    //    protected override Expression VisitParameter(ParameterExpression node)
    //    {
    //        if (map.TryGetValue(node, out ParameterExpression replace))
    //        {
    //            node = replace;
    //        }
    //        return base.VisitParameter(node);
    //    }

    //}

    ///// <summary>
    ///// 表达式数的lambda参数的拼接扩展方法
    ///// </summary>
    //public static class ExpressionExtension
    //{

    //    //public static Expression<Func<T, bool>> True<T>() { return f => true; }
    //    //public static Expression<Func<T, bool>> False<T>() { return f => false; }
    //    //public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    //{
    //    //    // build parameter map (from parameters of second to parameters of first)  
    //    //    var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

    //    //    // replace parameters in the second lambda expression with parameters from the first  
    //    //    var secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

    //    //    // apply composition of lambda expression bodies to parameters from the first expression   
    //    //    return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    //}
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        var dict = first.Parameters.Select((f, index) => new { f, s = second.Parameters[index] }).ToDictionary(a => a.s, a => a.f);
    //        var secondBody = ParameterRebinder.ReplaceParameter(dict, second.Body);
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--or
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);
    //    //{
    //    //    return first.Compose(second, Expression.Or);
    //    //}

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--and
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>
    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);
    //    //{
    //    //    return first.Compose(second, Expression.And);
    //    //}


    //    public static Expression<Func<T, bool>> True<T>() => f => true;
    //    //{
    //    //    return f => true;
    //    //}

    //    public static Expression<Func<T, bool>> False<T>() => f => false;
    //    //{
    //    //    return f => false;
    //    //}
    //}
    #endregion

    //#region MyRegion
    ///// <summary>
    ///// Expression表达式树
    ///// </summary>
    //public class ParameterRebinder : ExpressionVisitor
    //{
    //    /// <summary>
    //    /// 存放表达式树的参数的字典
    //    /// </summary>
    //    private readonly Dictionary<ParameterExpression, ParameterExpression> Map;

    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="map"></param>
    //    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    //    {
    //        this.Map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    //    }

    //    public static Expression ReplaceParameter(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) /*=> new ParameterRebinder(map).Visit(exp);*/
    //    {
    //        return new ParameterRebinder(map).Visit(exp);
    //    }

    //    /// <summary>
    //    /// 访问表达式树参数，如果字典中包含，则取出
    //    /// </summary>
    //    /// <param name="node">表达式树参数</param>
    //    /// <returns></returns>
    //    protected override Expression VisitParameter(ParameterExpression node)
    //    {
    //        if (Map.TryGetValue(node, out ParameterExpression replace))
    //        {
    //            node = replace;
    //        }
    //        return base.VisitParameter(node);
    //    }

    //}

    ///// <summary>
    ///// 表达式数的lambda参数的拼接扩展方法
    ///// </summary>
    //public static class ExpressionExtension
    //{
    //    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    //    {
    //        var dict = first.Parameters.Select((f, index) => new { f, s = second.Parameters[index] }).ToDictionary(a => a.f, a => a.s);
    //        var secondBody = ParameterRebinder.ReplaceParameter(dict, second.Body);
    //        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--or
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) /*=> first.Compose(second, Expression.Or);*/
    //    {
    //        return first.Compose(second, Expression.Or);
    //    }

    //    /// <summary>
    //    /// Expression表达式树lambda参数拼接--and
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="first"></param>
    //    /// <param name="second"></param>
    //    /// <returns></returns>
    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) /*=> first.Compose(second, Expression.And);*/
    //    {
    //        return first.Compose(second, Expression.And);
    //    }


    //    public static Expression<Func<T, bool>> True<T>() /*=> f => true;*/
    //    {
    //        return f => true;
    //    }

    //    public static Expression<Func<T, bool>> False<T>() /*=> f => false;*/
    //    {
    //        return f => false;
    //    }
    //}
    //#endregion
}

//顶级程序

//System.Console.WriteLine("After initial GetOrAdd");
//System.Console.Read();