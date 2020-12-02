using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSingleInstance();
            TestLambda();
            Console.Read();
        }

        /// <summary>
        /// 测试单例
        /// </summary>
        public static void TestSingleInstance()
        {
            CommonTool tool = new CommonTool();
            var ss = tool.GetHttpPost();
            Console.WriteLine($"{ss}");
            //var ss = tool.GetHttp();
            //Console.WriteLine($"{ss}");
            Console.ReadLine();
            if (RunningInstance() == null)
            {
                Console.WriteLine("启动。。。");
            }
            else
            {
                Console.WriteLine("已经运行了一个实例了。");
            }
        }

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Console.WriteLine($"当前进程名称：{current.ProcessName},  current.MainModule.FileName：{current.MainModule.FileName}");

            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes) //查找相同名称的进程 
            {
                if (process.Id != current.Id) //忽略当前进程
                { //确认相同进程的程序运行位置是否一样. 
                    var local = Assembly.GetExecutingAssembly().Location;
                    Console.WriteLine($"Assembly.GetExecutingAssembly().Location：{local}");
                    if (local.Replace("/", @"\") != current.MainModule.FileName)
                    {
                        continue;
                    }
                    return process;
                }
            }
            return null;
        }

        /// <summary>
        /// 测试Lambda Expression 表达式拼接
        /// </summary>
        public static void TestLambda()
        {
            List<int> grades1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Expression<Func<int, bool>> expression = t => true;
            expression = expression.And1(t => t > 2);
            expression = expression.And1(t => t < 8);
            var ds = grades1.AsQueryable().Where(expression).ToList();
            foreach (var item in ds)
            {
                Console.WriteLine($"IQueryable:{item}");
            }
        }
    }
}
