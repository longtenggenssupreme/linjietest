using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    public class TestDesttructor1
    {
        private int Id;
        private List<string> listStr;
        private string TestStr = "123";

        public TestDesttructor1()
        {
            Console.WriteLine($"构造函数，初始化");
        }

        ~TestDesttructor1()
        {
            Console.WriteLine($"析构函数，释放资源");
            File.WriteAllText(@"F:\Person\aaa\LJTest\EFCOREDB\Deconstructor\6666.txt", @"~~TestDesttructor1()被执行了");
        }

        /// <summary>
        /// 该方法执行完后不会调用析构函数，没有释放资源
        /// </summary>
        /// <returns></returns>
        public Task InvokeMethod()
        {
            //匿名方法中捕获了类的成员，可能出现了内存泄漏
            //值类型，
            //return Task.Run(() =>
            //{
            //    Console.WriteLine($"开始执行方法，当前任务的id={Id}");//匿名方法中捕获了类的成员，可能出现了内存泄漏
            //    System.Threading.Thread.Sleep(100);
            //});

            //引用类型
            return Task.Run(() =>
            {
                Console.WriteLine($"开始执行方法，当前任务的使用类的字符串={TestStr}");//匿名方法中捕获了类的成员，可能出现了内存泄漏
                System.Threading.Thread.Sleep(100);
            });
        }

        ///InvokeMethod与InvokeMethod1 的区别：
        ///私有成员 _id 被 Task.Run 的匿名方法捕获使用，进而导致 MyClass 实例被引用。
        ///当外部使用完 MyClass 实例时，本该由 GC 回收的时候却发现它还被其它资源引用着，
        ///所以 GC 认为该实例不应该被回收，也就可能永远失去了被回收的机会。

        /// <summary>
        /// 该方法执行完后会调用析构函数，释放资源
        /// </summary>
        /// <returns></returns>
        public Task InvokeMethod1()
        {
            //使用了本地变量，避免了内存泄漏
            //值类型
            //var local = this.Id;
            //return Task.Run(() =>
            //{
            //    Console.WriteLine($"开始执行方法，当前任务的id={local}");//使用了本地变量，避免了内存泄漏
            //    System.Threading.Thread.Sleep(100);
            //});

            var local = this.TestStr;
            //引用类型
            return Task.Run(() =>
            {
                Console.WriteLine($"开始执行方法，当前任务的使用类的字符串={local}");//使用了本地变量，避免了内存泄漏
                System.Threading.Thread.Sleep(100);
            });
        }
    }
}
