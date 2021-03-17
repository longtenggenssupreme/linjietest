using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EFCOREDB
{

    /// <summary>
    /// 在支持远程操作的应用程序中，允许跨应用程序域边界访问对象
    /// </summary>
    //System.Runtime.Serialization.SerializationException:
    //“程序集“ConsoleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null”
    //中的类型“CommonTools.Program”未标记为可序列化。”
    //处理方式1，添加[Serializable]特性
    //处理方式2，继承MarshalByRefObject
    //[Serializable]
    public class Program /*MarshalByRefObject*/
    {
        public static int y = 5;
        public static int x = y;
        //static int y = 5;

        static void Main(string[] args)
        {


            #region 语音播报
            SpeechTest();
            #endregion

            #region 全部

            #region RSAji公钥加密，私钥解密以及 私钥签名公钥验签
            //RSATest();
            #endregion

            #region PLINQ是保留序列中的原始顺序
            //PLINQOrder();
            #endregion

            #region 测试验证码authcode
            //AuthCode();
            #endregion

            #region 测试TestStackTrace
            //SendFile();
            #endregion

            #region 测试TestStackTrace
            //TestStackTrace();
            #endregion

            #region 测试自定义 nuget包 TestLongteng nuget包
            //TestLongteng();
            #endregion

            #region 测试TestLinqWhereIf
            //TestLinqWhereIf();
            #endregion

            #region 测试TestForeach
            //TestForeach();
            #endregion

            #region 测试NotNull
            //string ss = "123";
            //TestNotNull(ss);
            //string ss1 = null;
            //TestNotNull(ss1);
            //string ss2 = string.Empty;
            //TestNotNull(ss2);
            #endregion

            #region 测试TestSpan
            //TestSpan();
            #endregion

            #region 测试TestEnvironment
            //TestEnvironment();
            #endregion

            #region 测试TestDelegate
            //TestDelegate();
            #endregion

            #region IOC TestIOC
            //TestIOC();
            #endregion

            #region 消除eliminate remove If-Else
            //TestRemoveIfElse();
            #endregion

            #region 测试TestUdpSocket
            //TestUdpSocket();
            #endregion

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

        #region 语音播报
        public static void SpeechTest()
        {
            using var speech = new System.Speech.Synthesis.SpeechSynthesizer
            {
                Rate = 0,//语速
                Volume = 10//音量
            };
            speech.Speak("这是测试的语音");//播放文字

            //SoundPlayer播放本地音频,项目添加引用→COM类型库：Windows Media Player

            SoundPlayer play = new SoundPlayer();
            play.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "123.wav"; //本地音频位置，这里放在了当前项目bin→debug下
            play.Load();  //加载声音
            play.Play(); //播放

        }
        #endregion

        #region RSA公钥加密，私钥解密以及 私钥签名公钥验签
        public static void RSATest()
        {
            Console.WriteLine($"RSA公钥加密，私钥解密以及 私钥签名公钥验签");
            using var rsa = new System.Security.Cryptography.RSACryptoServiceProvider();

            #region 导出公钥和私钥（字节数组）
            var RSAPublicKey = rsa.ExportRSAPublicKey();
            var RSAPrivateKey = rsa.ExportRSAPrivateKey();
            var RSAPublicKeyBase64 = Convert.ToBase64String(RSAPublicKey);
            var RSAPrivateKeyBase64 = Convert.ToBase64String(RSAPrivateKey);

            Console.WriteLine($"导出公钥和私钥（字节数组）,公钥：{RSAPublicKeyBase64}, 私钥：{RSAPrivateKeyBase64}");
            Console.WriteLine($"");
            #endregion

            #region 导出公钥和私钥（xml字符串）
            var RSAXmlStringPublicKey = rsa.ToXmlString(false);
            var RSAXmlStringPrivateKey = rsa.ToXmlString(true);
            var RSAXmlStringPublicKeyBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(RSAXmlStringPublicKey));
            var RSAXmlStringPrivateKeyBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(RSAXmlStringPrivateKey));
            Console.WriteLine($"导出公钥和私钥（xml字符串）,公钥：{RSAXmlStringPublicKeyBase64}, 私钥：{RSAXmlStringPrivateKeyBase64}");
            Console.WriteLine($"");
            #endregion

            #region 导出公钥和私钥（RSAPublicKeyRSAParameters）
            var RSAPublicKeyRSAParameters = rsa.ExportParameters(false);
            var RSAPrivateKeyRSAParameters = rsa.ExportParameters(true);
            Console.WriteLine($"导出公钥和私钥（RSAPublicKeyRSAParameters）,公钥：{RSAPublicKeyRSAParameters}, 私钥：{RSAPrivateKeyRSAParameters}");
            Console.WriteLine($"");
            #endregion

            //下面显示公钥加密--私钥解密--私钥加签名--公钥验证签名
            Console.WriteLine($"下面显示公钥加密--私钥解密--私钥加签名--公钥验证签名");
            //测试数据---我是哈哈哈--嘿嘿嘿嘿
            string data = "我是哈哈哈--嘿嘿嘿嘿";

            #region 导出公钥和私钥（字节数组）
            //rsa.ImportRSAPublicKey(new ReadOnlySpan<byte>(RSAPublicKey), out int bytesRead);
            ////公钥加密
            //var encrypto = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
            //var encryptoBase64 = Convert.ToBase64String(encrypto);
            //Console.WriteLine($"公钥加密,原数据：{data},加密以后的数据：{encryptoBase64}");

            ////私钥解密
            //var decrpyt = Convert.FromBase64String(encryptoBase64);
            //rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(RSAPrivateKey), out int byteread);
            //var decrypto = rsa.Decrypt(decrpyt, false);
            //var decryptoBase64 = Encoding.UTF8.GetString(decrypto);
            //Console.WriteLine($"私钥解密,加密以后的数据：{encryptoBase64}, 解密以后的数据：{decryptoBase64}"); 
            #endregion

            #region 导出公钥和私钥（xml字符串）
            //rsa.FromXmlString(RSAXmlStringPublicKey);
            ////公钥加密
            //var encrypto = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
            //var encryptoBase64 = Convert.ToBase64String(encrypto);
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"公钥加密,原数据：{data},加密以后的数据：{encryptoBase64}");
            //Console.ForegroundColor = ConsoleColor.Green;
            ////私钥解密
            //var decrpyt = Convert.FromBase64String(encryptoBase64);
            //rsa.FromXmlString(RSAXmlStringPrivateKey);
            //var decrypto = rsa.Decrypt(decrpyt, false);
            //var decryptoBase64 = Encoding.UTF8.GetString(decrypto);
            //Console.WriteLine($"私钥解密,加密以后的数据：{encryptoBase64}, 解密以后的数据：{decryptoBase64}");
            #endregion

            #region 导出公钥和私钥（xml字符串）
            //rsa.ImportParameters(RSAPublicKeyRSAParameters);
            ////公钥加密
            //var encrypto = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
            //var encryptoBase64 = Convert.ToBase64String(encrypto);
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"公钥加密,原数据：{data},加密以后的数据：{encryptoBase64}");
            //Console.ForegroundColor = ConsoleColor.Green;
            ////私钥解密
            //var decrpyt = Convert.FromBase64String(encryptoBase64);
            //rsa.ImportParameters(RSAPrivateKeyRSAParameters);
            //var decrypto = rsa.Decrypt(decrpyt, false);
            //var decryptoBase64 = Encoding.UTF8.GetString(decrypto);
            //Console.WriteLine($"私钥解密,加密以后的数据：{encryptoBase64}, 解密以后的数据：{decryptoBase64}");
            #endregion

            #region 私钥加签名,公钥验证签名
            //私钥加签名
            var secret = System.Security.Cryptography.Aes.Create().Key;//获取对称加密的密钥                   
            rsa.ImportParameters(RSAPrivateKeyRSAParameters);//导入私钥，使用私钥对获取对称加密的密钥加加签名
            var signature = rsa.SignData(secret, "MD5");
            var signcryptoBase64 = Encoding.UTF8.GetString(signature);//base64方便传输
            Console.WriteLine($"私钥签名,加密对称加密的密钥以后的数据：{signcryptoBase64}");

            rsa.ImportParameters(RSAPublicKeyRSAParameters);
            //公钥验证签名
            var issignature = rsa.VerifyData(secret, "MD5", signature);
            var outstring = issignature == true ? "已签名" : "未签名";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"公钥验证签名：{outstring}");
            Console.ForegroundColor = ConsoleColor.Green;
            #endregion
        }
        #endregion


        #region PLINQ是保留序列中的原始顺序
        public static void PLINQOrder()
        {
            Console.WriteLine($"PLINQ");
            new List<string> { "a", "b", "c", "d" }.AsParallel().Select(s => s + "a").AsSequential().ToList().ForEach(a => Console.WriteLine(a));
            Console.WriteLine($"PLINQ是否保留序列中的原始顺序");
            new List<string> { "a", "b", "c", "d" }.AsParallel().AsOrdered().Select(s => s + "a").AsSequential().ToList().ForEach(a => Console.WriteLine(a));
        }
        #endregion

        #region verificaionCode验证码
        public static void AuthCode()
        {
            Console.WriteLine($"开始测试 verificaionCode验证码");
            var path = Path.Combine(Environment.CurrentDirectory, "自定义绘制验证码.gif");
            //byte[] vs1 = BitConverter.GetBytes(true);
            //bool ss = BitConverter.ToBoolean(vs1);
            //ss = BitConverter.ToBoolean(vs1, 0);
            //byte vs = Convert.ToByte('d');
            //创建图片
            using Bitmap bitmap = new Bitmap(200, 60);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Bold, GraphicsUnit.Pixel);
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            //绘制验证码
            for (int i = 0; i < 5; i++)
            {
                var s = letters.Substring(random.Next(0, letters.Length - 1), 1);
                sb.Append(s);
                graphics.DrawString(s, font, brush, i * 36, random.Next(0, 12));
            }
            //混淆背景
            Pen pen = new Pen(new SolidBrush(Color.Black), 2);
            for (int j = 0; j < 6; j++)
            {
                graphics.DrawLine(pen, new Point(random.Next(0, 199), random.Next(0, 59)), new Point(random.Next(0, 199), random.Next(0, 59)));
            }
            //保存验证码图片
            bitmap.Save(path, ImageFormat.Gif);
        }
        #endregion
        #region 测试TestStackTrace
        public static void SendFile()
        {
            Console.WriteLine($"开始测试 StackTrace 使用");
            var path = @"C:\Users\Administrator\Pictures\图片.jpg";
            //byte[] fileStream = File.ReadAllBytes(path);
            using FileStream fileStream = File.OpenRead(path);
            byte[] vs = new byte[1024];
            int count = 0;
            //byte[] vs1 = BitConverter.GetBytes(true);

            //bool ss = BitConverter.ToBoolean(vs1);
            //ss = BitConverter.ToBoolean(vs1, 0);
            //vs[0] = Convert.ToByte('d');
            while ((count = fileStream.Read(vs, 0, vs.Length)) > 0)
            {
                //vs实际长度是count，处理读取到的数据
            }
        }
        #endregion

        #region 测试TestStackTrace
        public static void TestStackTrace()
        {
            Console.WriteLine($"开始测试 StackTrace 使用");

            int index = 0;
            StackTrace stackTrace = new StackTrace(true);
            var count = stackTrace.FrameCount;
            while (index < count)
            {
                var frame = stackTrace.GetFrame(index++);
                Console.WriteLine($"frame：{frame}");
                var lineNumber = frame.GetFileLineNumber();
                Console.WriteLine($"lineNumber：{lineNumber}");
                var columnNumber = frame.GetFileColumnNumber();
                Console.WriteLine($"columnNumber：{columnNumber}");
                var methodinfo = frame.GetMethod();
                Console.WriteLine($"methodinfo Name：{methodinfo.Name}");
                var ss = methodinfo.DeclaringType;
                Console.WriteLine($"DeclaringType：{ss}");
                var module = methodinfo.Module;
                Console.WriteLine($"Module：{module}");
                var Assembly = methodinfo.Module.Assembly;
                Console.WriteLine($"Assembly：{Assembly.GetName().Name}");
                Console.WriteLine($"Assembly：{Assembly.GetName().FullName}");
                var FileName = frame.GetFileName();
                Console.WriteLine($"FileName：{FileName}");

                Console.WriteLine($"-------");
                //Console.WriteLine($"22222222");
                //var stackFrames = stackTrace.GetFrames();
                //string callChain = string.Join(" -> ", stackFrames.Select((r, i) =>
                //{
                //    if (i == 0) return null;
                //    var m = r.GetMethod();
                //    return $"{m.DeclaringType.FullName}.{m.Name}";
                //})
                //    .Where(r => !string.IsNullOrWhiteSpace(r))
                //    //.WhereIf(r=> !string.IsNullOrWhiteSpace(r),true)
                //    .Reverse());
                //Console.WriteLine($"callChain：{callChain}");
                //Console.WriteLine($"22222222");
            }
        }
        #endregion

        #region 测试自定义 nuget包 TestLongteng nuget包
        public static void TestLongteng()
        {
            Console.WriteLine($"开始测试 自定义的longteng nuget包的使用");

            LongTengDragon.LongTeng longTeng = new LongTengDragon.LongTeng();
            var ss = longTeng.GetRandomNumber(100, 200);
            {
                Console.WriteLine($"自定义的longteng nuget包使用，输出随机数：{ss}");
            }
        }
        #endregion

        #region TestLinqWhereIf
        public static void TestLinqWhereIf()
        {
            Console.WriteLine($"开始测试 linq where 条件筛选");
            Console.WriteLine($"开始测试 linq where 条件筛选---IEnumerable<T>");
            var lsist = Enumerable.Range(1, 20).WhereIf(a => a % 2 == 0, true);
            foreach (var item in lsist)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"开始测试 linq where 条件筛选--IQueryable<T> 远程枚举");
            Expression<Func<int, bool>> expression = a => a % 2 == 0;
            var lsist1 = Enumerable.Range(1, 20).AsQueryable<int>().WhereIf(expression, true);
            foreach (var item in lsist1)
            {
                Console.WriteLine($"{item}");
            }
        }
        #endregion

        #region TestForeach
        public static void TestForeach()
        {
            Console.WriteLine($"没有继承");
            var a = 11;
            foreach (var item in a)
            {
                Console.WriteLine($"{item}");
            }
        }
        #endregion

        #region Null and NotNull
        /// <summary>
        /// 测试NotNull
        /// </summary>
        public static void TestNotNull(NotNull<string> notNull)
        {
            Console.WriteLine($"notNull:{notNull.Value}");
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4
            //Console.WriteLine($"{path1}");
        }

        public class NotNull<T>
        {
            public T Value { get; set; }
            public NotNull(T value)
            {
                Value = value;
            }

            public static implicit operator NotNull<T>(T value)
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }
                return new NotNull<T>(value);
            }
        }

        public readonly struct Fraction
        {
            private readonly int num;
            private readonly int den;

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
                }
                num = numerator;
                den = denominator;
            }

            public static Fraction operator +(Fraction a) => a;
            public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

            public static Fraction operator +(Fraction a, Fraction b)
                => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

            public static Fraction operator -(Fraction a, Fraction b)
                => a + (-b);

            public static Fraction operator *(Fraction a, Fraction b)
                => new Fraction(a.num * b.num, a.den * b.den);

            public static Fraction operator /(Fraction a, Fraction b)
            {
                if (b.num == 0)
                {
                    throw new DivideByZeroException();
                }
                return new Fraction(a.num * b.den, a.den * b.num);
            }

            public override string ToString() => $"{num} / {den}";
        }

        #endregion

        #region TestSpan
        /// <summary>
        /// 测试Span
        /// </summary>
        public static void TestSpan()
        {
            Span<byte> stackMemory = stackalloc byte[256];

            //Span使用时，最简单的，可以把它想象成一个数组，它会做所有的指针运算，同时，内部又可以指向任何类型的内存
            //例如，我们可以为非托管内存创建Span
            unsafe
            {
                IntPtr unmanagedHandle = Marshal.AllocHGlobal(256);
                Span<byte> unmanaged = new Span<byte>(unmanagedHandle.ToPointer(), 256);
                Marshal.FreeHGlobal(unmanagedHandle);
            }

            //从T[]到Span的隐式转换
            char[] array = new char[] { 'i', 'm', 'p', 'l', 'i', 'c', 'i', 't' };
            Span<char> fromArray = array;

            //还有ReadOnlySpan，可以用来处理字符串或其他不可变类型：

            ReadOnlySpan<char> fromString = "Hello world".AsSpan();
            //Span创建完成后，就跟普通的数组一样，有一个Length属性和一个允许读写的index，因此使用时就和一般的数组一样使用就好。
            //Console.WriteLine($"{path1}");
        }
        #endregion

        #region 密码进行加密及密码验证加密和解密  scrypt 和 bcrypt对密码进行加密及密码验证 
        public static void TestHashAlgorithm()
        {
            // //using CryptSharp.Utility; 使用SCrypt的加密算法
            //Console.WriteLine("SCrypt");
            //string pwd = "SCrypt明文信息";
            ////HashAlgorithm hash = HashAlgorithm.Create("MD5");
            //HashAlgorithm hash = MD5.Create();
            //byte[] ms5bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            //Console.WriteLine($"ms5bytes :{BitConverter.ToString(ms5bytes).Replace("-",string.Empty)}");
            //byte[] salt = new byte[10];
            //byte[] salt2 = new byte[4];
            //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            //rng.GetBytes(salt);
            //rng.GetBytes(salt2);
            //Console.WriteLine(BitConverter.ToString(salt2));
            //byte[] result = SCrypt.ComputeDerivedKey(Encoding.UTF8.GetBytes(pwd), salt, 4, 8, 2, 2, 5);
            //Console.WriteLine($"加密以后的密文:{BitConverter.ToString(result).Replace("-","").ToLower()}");
        }

        //using CryptSharp.Utility;
        //using System;
        //using System.Security.Cryptography;
        //using System.Text;
        public static void TestScrypt()
        {
            //Console.WriteLine("SCrypt.Net.BCrypt");
            //SCrypt.ScryptEncoder scrypt = new Scrypt.ScryptEncoder();
            //Scrypt.ScryptEncoder scrypt1 = new Scrypt.ScryptEncoder(4, 8, 1);
            //Scrypt.ScryptEncoder scrypt2 = new Scrypt.ScryptEncoder(8, 16, 1, RandomNumberGenerator.Create());

            //string pwd = "SCrypt明文信息";
            //Console.WriteLine($"明文信息:{pwd}");
            //string result = scrypt.Encode(pwd);
            //Console.WriteLine($"加密以后的密文:{result}");

            ////string pwd1 = "SCrypt明文信息111";
            ////Console.WriteLine($"明文信息:{pwd1}");
            ////string result1 = scrypt1.Encode(pwd1);
            ////Console.WriteLine($"加密以后的密文:{result1}");

            ////string pwd2 = "SCrypt明文信息222";
            ////Console.WriteLine($"明文信息:{pwd2}");
            ////string result2 = scrypt2.Encode(pwd2);
            ////Console.WriteLine($"加密以后的密文:{result2}");

            //bool isValid = scrypt.IsValid(result);
            //Console.WriteLine($"加密以后的密文 isvalid:{isValid}");
            //bool isMatchpasswordAndpwd = scrypt.Compare("SCrypt明文信息", result);
            //Console.WriteLine($"明文信息与加密以后的密文是否一致:{isMatchpasswordAndpwd}");
        }

        //using DevOne.Security.Cryptography.BCrypt;
        //using System;
        public static void TestBCrypt()
        {
            //#region BCrypt对密码进行加密及密码验证
            //// Console.WriteLine("BCryptHelper");
            //// string salt = BCryptHelper.GenerateSalt();
            //// Console.WriteLine($"产生随机盐 salt:{salt}");

            //// string password = "1234567890";
            ////Console.WriteLine($"明文:{password}");
            //// string pwd = BCryptHelper.HashPassword(password, salt);
            //// Console.WriteLine($"加密以后的密文:{pwd}");
            //// bool isMatchpasswordAndpwd = BCryptHelper.CheckPassword("1234567890", pwd);
            //// Console.WriteLine($"明文和加密以后的密文是否匹配:{isMatchpasswordAndpwd}"); 
            //#endregion

            //#region BCrypt.Net.BCrypt

            //Console.WriteLine("BCrypt.Net.BCrypt");
            //string salt = BCrypt.Net.BCrypt.GenerateSalt(28);
            //Console.WriteLine($"产生随机盐 salt:{salt}");
            //salt = BCrypt.Net.BCrypt.GenerateSalt();
            //Console.WriteLine($"产生随机盐 salt:{salt}");
            //string password = "1234567890";
            //Console.WriteLine($"明文:{password}");
            //string pwd = BCrypt.Net.BCrypt.HashPassword(password);
            //Console.WriteLine($"加密以后的密文:{pwd}");
            //pwd = BCrypt.Net.BCrypt.HashPassword(password, 4);
            //Console.WriteLine($"加密以后的密文:{pwd}");
            //pwd = BCrypt.Net.BCrypt.HashPassword(password, salt);
            //Console.WriteLine($"加密以后的密文:{pwd}");
            //pwd = BCrypt.Net.BCrypt.HashString("密文");
            //Console.WriteLine($"加密以后的密文:{pwd}");
            //pwd = BCrypt.Net.BCrypt.HashString("密文", 4);
            //Console.WriteLine($"加密以后的密文:{pwd}");
            //bool isMatchpasswordAndpwd = BCrypt.Net.BCrypt.Verify("密文", pwd);
            //Console.WriteLine($"明文和加密以后的密文是否匹配:{isMatchpasswordAndpwd}");
            //#endregion

            ////string salt = BCrypt.Net.BCrypt.GenerateSalt
            ////Console.WriteLine($"产生随机盐 salt:{salt}");

            ////string password = "1234567890";
            ////Console.WriteLine($"明文:{password}");
            ////string pwd = BCryptHelper.HashPassword(password, salt);
            ////Console.WriteLine($"加密以后的密文:{pwd}");
            ////bool isMatchpasswordAndpwd = BCryptHelper.CheckPassword("1234567890", pwd);
            ////Console.WriteLine($"明文和加密以后的密文是否匹配:{isMatchpasswordAndpwd}");
        }

        #endregion

        #region TestEnvironment 特殊文件夹 
        public static void TestEnvironment()
        {
            //判断系统文件的时候会存在32位和64位的差异，普通文件就不存在任何影响了
            var path1 = Environment.GetFolderPath(Environment.SpecialFolder.System);
            //系统文件在32位系统中：path1是C:\Windows\system32
            //系统文件在64位系统中：path1是C:\Windows\SysWoW64，之所以会这样是因为
            //该SysWoW64文件夹主要是被设计用来处理许多在32位Windows和64位Windows之间的不同的问题，
            //使得可以在64位Windows中运行32位的程序
            //所以我们在32位程序的时候判断系统路径其实已经重定向到了: C:\Windows\SysWoW64了，
            //这是系统自动重定向，这个目录肯定不是我们要找的C:\Windows\system32目录
            Console.WriteLine($"{path1}");
            //例如：
            // 获取系统目录
            var system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var filePath = system + @"\drivers\evserial7.sys";
            var flag = File.Exists(filePath);
            Console.WriteLine($"系统路径:{filePath} checkDrives:{flag}");
            //解决---系统文件的时候会存在32位和64位的差异

            //使用 C:\Windows\SysNative路径,这是个虚拟路径，我们在Windows资源管理器中是无法找到的。
            //但是他最终还是会指向到system32中。SysNative文件夹目的就是让32位应用程序访问64位系统文件的方法。
            //现在我将代码改下,前面的 Environment.GetFolderPath(Environment.SpecialFolder.System)是获取system32
            //这里要改为Environment.SpecialFolder.Windows，获取windows目录，并在下面拼接上Sysnative目录。
            // 获取windows目录
            var system1 = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var filePath1 = system1 + @"\Sysnative\drivers\evserial7.sys";
            var flag1 = File.Exists(filePath1);
            Console.WriteLine($"系统路径:{filePath1} checkDrives:{flag1}");
        }
        #endregion

        #region Task<int>  ==》ValueTask<int>
        /// <summary>
        /// 如果时立即返回的需要使用 ValueTask<int>，而不使用Task<int>，例如内存操作以及读缓存
        /// </summary>
        /// <returns></returns>
        public Task<int> GetCustomerIdAsync()
        {
            return Task.FromResult(1);
        }

        public ValueTask<int> GetCustomerIdAsync1()
        {
            return new ValueTask<int>(1);
        }
        #endregion

        #region TestDelegate
        public static void TestDelegate()
        {
            TestCustomDelegate testCustom = new TestCustomDelegate();
            testCustom.Test();
        }

        public class TestCustomDelegate
        {
            //定义委托
            public delegate void TestVoidDelegate();
            //定义委托
            public delegate string TestStringDelegate();

            public void Test1()
            {
                Console.WriteLine("这是没有返回值的Delegate--Test1");
            }
            public void Test2()
            {
                Console.WriteLine("这是没有返回值的Delegate--Test2");
            }

            public string Test3()
            {
                Console.WriteLine("这是有返回值的Delegate---Test3");
                return "这是有返回值的Delegate";
            }

            public string Test4()
            {
                Console.WriteLine("这是有返回值的Delegate--Test4");
                return "这是有返回值的Delegate";
            }

            public void Test()
            {
                TestVoidDelegate testVoid = new TestVoidDelegate(Test1);
                TestVoidDelegate testVoid1 = new TestVoidDelegate(Test2);
                TestStringDelegate TestString = new TestStringDelegate(Test3);
                TestStringDelegate TestString1 = new TestStringDelegate(Test4);
                testVoid();
                testVoid.Invoke();
                TestString();
                TestString.Invoke();

                //多播委托
                TestVoidDelegate TestCom = testVoid + testVoid1;
                TestCom();
                TestCom.Invoke();
                TestStringDelegate TestStringCom = TestString + TestString1;
                TestStringCom();
                TestStringCom.Invoke();

                //多播委托
                testVoid += testVoid1;
                testVoid();
                testVoid.Invoke();
                TestString += TestString1;
                TestString();
                TestString.Invoke();

                //多播委托
                TestVoidDelegate TestCom1 = (TestVoidDelegate)Delegate.Combine(testVoid, testVoid1);
                TestCom1();
                TestCom1.Invoke();
                TestStringDelegate TestStringCom1 = (TestStringDelegate)Delegate.Combine(TestString, TestString1);
                TestStringCom1();
                TestStringCom1.Invoke();
            }
        }

        #endregion

        #region IOC TestIOC
        public static void TestIOC()
        {
            Console.WriteLine($"测试---IOC");
            ContainerBuilder builder = new ContainerBuilder();

            #region Autofac默认都是构造函数注入
            ////Autofac默认都是构造函数注入
            //builder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();//瞬态
            //builder.RegisterType<TestB>().As<ITestB>().SingleInstance();//单例
            //builder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//作用域，应用域
            //builder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////指定作用域，指定应用域
            //builder.RegisterType<TestD>().As<ITestD>().InstancePerRequest("TEST");////指定作用域，指定应用域
            //builder.RegisterType<TestD>().As<ITestD>().PerRequest();////指定作用域，指定应用域

            ////Autofac接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            //builder.RegisterType<TestE>().As<ITestE>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//指定作用域，指定应用域
            #endregion

            #region Autofac Controller控制器中接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            ////Autofac Controller控制器中接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            ////containerBuilder.RegisterType<HHController>().As<ControllerBase>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//指定作用域，指定应用域
            //public void ConfigureServices(IServiceCollection services)中添加如下
            //控制器属性注入，默认ioc容器之创建接口服务，控制器的创建是由IControllerActivator创建的，现在使用ioc容器创建ServiceBasedControllerActivator
            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //public void ConfigureContainer(ContainerBuilder containerBuilder)中添加如下
            //var types = this.GetType().Assembly.ExportedTypes.Where(t => typeof(ControllerBase).IsAssignableFrom(t)).ToArray();
            ////注册所有controller,PropertiesAutowired 属性注入所有的接口服务以及自定义特性CustomPropAttribute区分标记和自定义属性选择器MyPropertySelector
            //containerBuilder.RegisterTypes(types).PropertiesAutowired(new MyPropertySelector()); 
            #endregion

            #region 使用方法注入----接口中的实现类中的其他接口服务的属性注入
            ////使用方法注入----接口中的实现类中的其他接口服务的属性注入
            //builder.RegisterType<TestG>().OnActivated(t => t.Instance.MethodInject(t.Context.Resolve<ITestB>())).As<ITestG>().InstancePerMatchingLifetimeScope("TEST456").PropertiesAutowired();//指定作用域，指定应用域
            #endregion


            #region Autofac 配置文件 配置IOC 依赖注入 属性注入
            //////Autofac 配置文件 配置IOC 依赖注入 属性注入
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.Add(new JsonConfigurationSource() { Path = "Config/autofacconfig.json", Optional = false, ReloadOnChange = true });
            //var conmodule = new ConfigurationModule(configurationBuilder.Build());
            //builder.RegisterModule(conmodule);
            #endregion


            #region Autofac 一对象多实例问题,例如：一个接口ITestA 2个实现TestA和TestF
            builder.RegisterType<TestB>().As<ITestB>().SingleInstance();//单例
            builder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//作用域，应用域
            builder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");//指定作用域，指定应用域 
            ////1、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试
            //builder.RegisterType<TestF>().As<ITestA>().InstancePerDependency();
            //builder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();

            ////一个接口ITestA 2个实现TestA和TestF,
            ////AController中使用测试，可以同时获取接口ITestA的2个实现TestA和TestF的实例，
            ////然后可以使用TestA和TestF来调用对应的方法,
            ////使用 public AController(ITestA testA, IEnumerable<ITestA> testAList, TestA testAA, TestF testFF, ITestC testC)
            ////builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo(typeof(ITestA))));
            ////下面是对上面的扩展，其实内容是一样的
            //builder.RegisterModule(new CustomModule());


            //2、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试
            //builder.RegisterType<TestF>().Named<ITestA>("TestF").InstancePerDependency();
            //builder.RegisterType<TestA>().Named<ITestA>("TestA").InstancePerDependency();
            //var contaier = builder.Build();
            //var testA = contaier.ResolveKeyed<ITestA>("TestA");
            //testA.Show();
            //var testF = contaier.ResolveKeyed<ITestA>("TestF");
            //testF.Show();

            //3、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试
            //builder.RegisterType<TestF>().Named<ITestA>("TestF").InstancePerDependency();
            //builder.RegisterType<TestA>().Named<ITestA>("TestA").InstancePerDependency();
            //var contaier = builder.Build();
            //var testA = contaier.ResolveKeyed<ITestA>("TestA");
            //testA.Show();
            //var testF = contaier.ResolveKeyed<ITestA>("TestF");
            //testF.Show();

            ////IComponentContext 这个对象可以获取对应的接口服务，组件上下文，
            ////这是一接口多实现的使用，IComponentContext组件上下文，
            ////用于一接口多实现的使用一个接口ITestA 2个实现TestA和TestF,AController中使用测试 使用Index1测试
            //var componentCintext = contaier.Resolve<IComponentContext>();
            //var testA1 = componentCintext.ResolveKeyed<ITestA>("TestA");
            //testA1 = componentCintext.ResolveNamed<ITestA>("TestA");
            //testA1.Show();
            //var testF1 = componentCintext.ResolveKeyed<ITestA>("TestF");
            //testF1 = componentCintext.ResolveKeyed<ITestA>("TestF");
            //testF1.Show();
            #endregion

            #region 作用域
            #region 方法注入  InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的
            //using var scope = contaier.BeginLifetimeScope("TEST456");
            //var testG = scope.Resolve<ITestG>();
            //testG.Show();//测试方法注入
            #endregion

            #region 属性注入  InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的

            //using var scope = contaier.BeginLifetimeScope("TEST123");
            //var testE = scope.Resolve<ITestE>();
            //testE.Show();//测试属性注入

            #endregion

            #region 属性注入 InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的
            //ITestD testD5;
            //ITestD testD6;
            //ITestD testD7;
            //using var scope = contaier.BeginLifetimeScope("TEST");
            //var testD = scope.Resolve<ITestD>();
            ////var testA = scope.Resolve<ITestA>();//测试属性注入
            ////testA.Show();
            //testD.Show();//测试属性注入
            //testD5 = testD;

            ////子作用域
            //using var scope1 = scope.BeginLifetimeScope();
            //var testD1 = scope1.Resolve<ITestD>();
            //var testD11 = scope1.Resolve<ITestD>();
            //testD6 = testD1;
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testD1, testD11)}");

            ////子作用域
            //using var scope2 = scope.BeginLifetimeScope();
            //var testD2 = scope2.Resolve<ITestD>();
            //testD7 = testD2;
            //var testD21 = scope2.Resolve<ITestD>();
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testD2, testD21)}");

            //Console.WriteLine($"作用域及子作用域：{object.ReferenceEquals(testD5, testD6)}");
            //Console.WriteLine($"不同子作用域对比：{object.ReferenceEquals(testD6, testD7)}");
            #endregion

            #region InstancePerLifetimeScope使用作用域及子作用域
            //ITestC testC5;
            //ITestC testC6;
            //ITestC testC7;
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC5 = testC;

            ////子作用域
            //using var scope1 = scope.BeginLifetimeScope();
            //var testC1 = scope1.Resolve<ITestC>();
            //var testC11 = scope1.Resolve<ITestC>();
            //testC6 = testC1;
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testC1, testC11)}");

            ////子作用域
            //using var scope2 = scope.BeginLifetimeScope();
            //var testC2 = scope2.Resolve<ITestC>();
            //testC7 = testC2;
            //var testC21 = scope2.Resolve<ITestC>();
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testC2, testC21)}");

            //Console.WriteLine($"作用域及子作用域：{object.ReferenceEquals(testC5, testC6)}");
            //Console.WriteLine($"不同子作用域对比：{object.ReferenceEquals(testC6, testC7)}");
            #endregion

            #region InstancePerLifetimeScope使用同一作用域及不同作用域
            //ITestC testC5;
            //ITestC testC6;
            //using var scope1 = contaier.BeginLifetimeScope();
            //var testC = scope1.Resolve<ITestC>();
            //testC.Show();
            //testC5 = testC;
            //var testC1 = scope1.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"相同作用域：{object.ReferenceEquals(testC, testC1)}");

            //using var scope2 = contaier.BeginLifetimeScope();
            //var testC3 = scope2.Resolve<ITestC>();
            //testC3.Show();
            //testC6 = testC3;
            //var testC4 = scope2.Resolve<ITestC>();
            //testC4.Show();
            //Console.WriteLine($"相同作用域：{object.ReferenceEquals(testC3, testC4)}");

            //Console.WriteLine($"不同作用域对比：{object.ReferenceEquals(testC5, testC6)}");
            #endregion

            #region InstancePerLifetimeScope使用作用域
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = scope.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"作用域：{object.ReferenceEquals(testC, testC1)}");
            #endregion

            #region InstancePerLifetimeScope默认作用域单例
            //var testC = contaier.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = contaier.Resolve<ITestC>();
            //testC1.Show(); 
            //Console.WriteLine($"作用域：{object.ReferenceEquals(testC, testC1)}");
            #endregion
            #endregion

            #region 单例
            //var testB = contaier.Resolve<ITestB>();
            //testB.Show();
            //var testB1 = contaier.Resolve<ITestB>();
            //testB1.Show();
            //Console.WriteLine($"单例：{object.ReferenceEquals(testB, testB1)}");
            #endregion

            #region 瞬态
            //var testA = contaier.Resolve<ITestA>();
            ////testA.Show();
            //var testA1 = contaier.Resolve<ITestA>();
            ////testA1.Show();
            //Console.WriteLine($"瞬态：{object.ReferenceEquals(testA,testA1)}"); 
            #endregion

            Console.WriteLine($"测试完成。。。");
        }

        /// <summary>
        /// autofac中自定义属性选择器类
        /// </summary>
        public class MyPropertySelector : IPropertySelector
        {
            public bool InjectProperty(PropertyInfo propertyInfo, object instance)
            {
                return propertyInfo.GetCustomAttributes().Any(att => att.GetType() == typeof(CustomPropAttribute));
            }
        }

        /// <summary>
        /// 标记不同的属性--特性标记
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class CustomPropAttribute : Attribute
        {
        }
        #endregion

        #region 消除eliminate remove If-Else
        public static void TestRemoveIfElse()
        {
            Console.WriteLine($"TestRemoveIfElse");
            TestIfElse testIfElse = new TestIfElse();
            TestIfElse.TestOrder order = new TestIfElse.TestOrder { Id = 1, Name = "zhansan" };
            var result = TestIfElse.RemoveIfElse(order, "json");
            Console.WriteLine($"消除eliminate remove If-Else：{result}");
            result = TestIfElse.RemoveIfElse1(order, "json");
            Console.WriteLine($"消除eliminate remove If-Else：{result}");
            result = TestIfElse.RemoveIfElse3(order, "json");
            Console.WriteLine($"消除eliminate remove If-Else：{result}");
            result = testIfElse.RemoveIfElse4(order, "json");
            Console.WriteLine($"消除eliminate remove If-Else：{result}");
            result = testIfElse.RemoveIfElse4(order, "plaintext");
            Console.WriteLine($"消除eliminate remove If-Else：{result}");
        }

        public class TestIfElse
        {
            public TestIfElse()
            {

            }
            public TestIfElse(int s, string y)
            {

            }
            /// <summary>
            /// 第一种方式，最常见的方式
            /// </summary>
            /// <param name="order"></param>
            /// <param name="formatType"></param>
            /// <returns></returns>
            public static string RemoveIfElse(TestOrder order, string formatType)
            {
                string result = string.Empty;
                if (formatType.Equals("json", StringComparison.OrdinalIgnoreCase))
                {
                    result = JsonConvert.SerializeObject(order);
                }
                else if (formatType.Equals("plaintext", StringComparison.OrdinalIgnoreCase))
                {
                    result = $"id={order.Id},name={order.Name}";
                }
                else
                {
                    result = $"Unknown format";
                }
                return result;
            }

            /// <summary>
            /// 第二种方式，假设只有两种情况，也就是json和plaintext这两种格式
            /// </summary>
            /// <param name="order"></param>
            /// <param name="formatType"></param>
            /// <returns></returns>
            public static string RemoveIfElse1(TestOrder order, string formatType)
            {
                //if (formatType == "json") return JsonConvert.SerializeObject(order);
                //if (formatType == "plaintext") return $"id={order.Id},name={order.Name}";
                //return $"Unknown format";

                string result = string.Empty;
                switch (formatType)
                {
                    case "json":
                        result = $"id={order.Id},name={order.Name}";
                        break;
                    default:
                        result = $"Unknown format";
                        break;
                }

                string result2 = formatType switch
                {
                    "json" => $"id={order.Id},name={order.Name}",
                    _ => $"Unknown format"
                };
                return result;
            }

            /// <summary>
            /// 第二种方式，假设只有两种情况，也就是json和plaintext这两种格式
            /// </summary>
            /// <param name="order"></param>
            /// <param name="formatType"></param>
            /// <returns></returns>
            public static string RemoveIfElse2(TestOrder order, string formatType)
            {
                //先决条件
                if (string.IsNullOrWhiteSpace(formatType))
                    return $"Unknown format";
                //if (formatType is null)
                //    return $"Unknown format";

                //处理逻辑
                return formatType == "json" ? JsonConvert.SerializeObject(order) : $"id={order.Id},name={order.Name}";
            }

            /// <summary>
            /// 第三种方式，使用字典处理key格式名称，value是Func<TestOrder, string>(对应的处理逻辑)
            /// </summary>
            /// <param name="order"></param>
            /// <param name="formatType"></param>
            /// <returns></returns>
            public static string RemoveIfElse3(TestOrder order, string formatType)
            {
                //先决条件
                if (string.IsNullOrWhiteSpace(formatType))
                    return $"Unknown format";
                //字典应该是在其他位置预先设置好的，然后在这里使用，这里只为演示
                Dictionary<string, Func<TestOrder, string>> dict = new Dictionary<string, Func<TestOrder, string>>
                {
                    ["json"] = a => JsonConvert.SerializeObject(a),
                    ["plaintext"] = a => $"id={a.Id},name={a.Name}"
                };

                //处理逻辑
                return dict[formatType]?.Invoke(order);
            }

            #region 第四种方式使用反射和特性还有字典
            /// <summary>
            /// 第四种方式使用反射和特性还有字典
            /// </summary>
            /// <param name="order"></param>
            /// <param name="formatType">特性标记的名称(特性中定义的字段Name)</param>
            /// <returns></returns>
            public string RemoveIfElse4(TestOrder order, string formatType)
            {
                //先决条件
                if (string.IsNullOrWhiteSpace(formatType))
                    return $"format is null";

                ////字典应该是在其他位置预先设置好的，然后在这里使用，这里只为演示
                var dict = GetType().Assembly
                    .GetExportedTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IFormat123)))
                    .ToDictionary(t => t.GetCustomAttribute<FlagFormatAttribute>().Name);

                if (dict[formatType] is null)
                    return $"No valid format";

                //处理逻辑
                var format = Activator.CreateInstance(dict[formatType]) as IFormat123;
                return format.Format(order);
            }

            /// <summary>
            /// 格式化接口
            /// </summary>
            public interface IFormat123
            {
                /// <summary>
                /// 格式化处理方法
                /// </summary>
                /// <param name="order"></param>
                /// <returns></returns>
                string Format(TestOrder order);
            }

            /// <summary>
            /// json格式化
            /// </summary>
            [FlagFormat(Name = "json")]
            public class JsonFormat : IFormat123
            {
                public string Format(TestOrder order)
                {
                    return JsonConvert.SerializeObject(order);
                }
            }

            /// <summary>
            /// plaintext格式化
            /// </summary>
            [FlagFormat(Name = "plaintext")]
            public class PlainTextFormat : IFormat123
            {
                public string Format(TestOrder order)
                {
                    return $"id={order.Id},name={order.Name}";
                }
            }
            /// <summary>
            /// xml格式化
            /// </summary>
            [FlagFormat(Name = "xml")]
            public class XMLFormat : IFormat123
            {
                public string Format(TestOrder order)
                {
                    return $"<id>{order.Id}></id>,<name>{order.Name}</name>";
                }
            }

            #endregion

            /// <summary>
            /// 测试类
            /// </summary>
            public class TestOrder
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }

            /// <summary>
            /// 自定义特性，主要用于区分不同的对象
            /// </summary>
            [AttributeUsage(AttributeTargets.Class)]
            public class FlagFormatAttribute : Attribute
            {
                /// <summary>
                /// 名称
                /// </summary>
                public string Name { get; set; }
            }
        }

        public class TestIfElse1 : TestIfElse
        {
            public TestIfElse1(int s, string x) : base(s, x)
            {

            }
        }
        #endregion

        #region 测试TestUdp测试Socket

        /// <summary>
        /// 测试TestUdp
        /// </summary>
        public static void TestUdpSocket()
        {
            #region 将无连接数据报发送到指定的远程主机
            //IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            //IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[3], 11000);
            //Socket s = new Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            //byte[] msg = Encoding.ASCII.GetBytes("This is a test");
            //Console.WriteLine("Sending data.");
            //// This call blocks.
            //s.SendTo(msg, endPoint);
            //s.Close();
            #endregion

            #region 从远程主机接收无连接的数据报

            // IPHostEntry hostEntry1 = Dns.GetHostEntry(Dns.GetHostName());
            //IPEndPoint endPoint1 = new IPEndPoint(hostEntry1.AddressList[3], 11000);
            //Socket s1 = new Socket(endPoint1.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            //// Creates an IPEndPoint to capture the identity of the sending host.
            //IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            //EndPoint senderRemote = (EndPoint)sender;
            //// Binding is required with ReceiveFrom calls.
            //s1.Bind(endPoint);

            //byte[] msg1 = new Byte[256];
            //Console.WriteLine("Waiting to receive datagrams from client...");
            //// This call blocks.
            //s1.ReceiveFrom(msg, ref senderRemote);
            //s1.Close();
            #endregion

            var threadStart = new Thread(new ThreadStart(StartTestUdpSocket))
            {
                IsBackground = true
            };
            threadStart.Start();
            Console.WriteLine($"TestUdp开始测试数据");

            Thread.Sleep(1000);

            var ipendipoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2233);
            var endipoint = (EndPoint)ipendipoint;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int test = 1;
            try
            {
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
                    Thread.Sleep(1000);
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                socket.Dispose();
            }
        }

        public static void StartTestUdpSocket()
        {
            var endip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2233);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(endip);

            //var ipendipoint = new IPEndPoint(IPAddress.Any, 0);
            //var endipoint = (EndPoint)ipendipoint;
            int test = 1;
            Console.WriteLine($"Udp服务端 启动监听");
            try
            {
                while (true)
                {
                    #region Socket----Udp
                    //var socketConn = await socket.AcceptAsync();
                    var buffer = new byte[1024];
                    var ipendipoint = new IPEndPoint(IPAddress.Any, 0);
                    var endipoint = (EndPoint)ipendipoint;
                    var socketConnReceCount = socket.ReceiveFrom(buffer, ref endipoint);
                    Console.WriteLine($"Udp服务端 scoket 服务端接收数据:{Encoding.UTF8.GetString(buffer, 0, socketConnReceCount)}");

                    Console.WriteLine($"Udp服务端 scoket 服务端处理数据:{test}");
                    var senddata = Encoding.UTF8.GetBytes($"服务端已处理{test}");
                    socket.SendTo(senddata, 0, senddata.Length, SocketFlags.None, endipoint);
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                socket.Dispose();
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
        /// 但程序退出时解构器被调用了。只能通过日志输出文件来确认析构函数是否别调用。这里将它输出在文本文件中，可以看到解构器被调用了，因为在背后base.Finalize()被调用了。
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
    /// 测试linq 中where条件筛选
    /// </summary>
    public static class TestLinqWhereIf
    {
        #region TestLinqWhereIf
        /// <summary>
        /// IEnumerable<T> 本地枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            if (condition)//判断条件成立则，执行筛选
            {
                source = source.Where(predicate);
            }
            return source;
        }

        /// <summary> 
        /// IQueryable<T> 远程枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            if (condition)//判断条件成立则，执行筛选
            {
                source = source.Where(predicate);
            }
            return source;
        }
        #endregion
    }

    /// <summary>
    /// 测试，不继承 IEnumerable，IEnmuerable<T> 添加 GetEnumerator 方法，方法返回值类型需要有 Current 属性和 MoveNext 方法，可以参考这个
    /// IEnumerator，返回类型可以直接实现 IEnumerator 或 IEnumerator<T> 那么如果是一个别人封装的类型，能否支持 foreach 呢，
    /// 从 C# 9 之后就可以了，可以添加一个 GetEnumerator 的扩展方法，类似于下面
    /// </summary>
    public static class ForeachExtension
    {
        public static IEnumerator<char> GetEnumerator(this int Num)
        {
            return Num.ToString().GetEnumerator();
        }
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