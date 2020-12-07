using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class TestDestructor : IDisposable
    {

        /// <summary>
        /// 是否已经是放过资源
        /// </summary>
        private bool isDisposed = false;
        private string TestStr;
        public TestDestructor()
        {
            TestStr = "TestDestructor构造函数初始化的字符串";
            Console.WriteLine("TestDestructor构造函数初始化");
        }

        /// <summary>
        /// 析构函数程序员无法控制解构器何时被执行因为这是由垃圾搜集器决定的。
        /// 但程序退出时解构器被调用了。你能通过日志输出文件来确认析构函数是否别调用。这里将它输出在文本文件中，可以看到解构器被调用了，因为在背后base.Finalize()被调用了。
        /// </summary>
        ~TestDestructor()
        {
            File.WriteAllText(@"F:\Person\aaa\LJTest\ConsoleTest\ConsoleTest\Deconstructor\123.txt", @"~TestDestructor()被执行了");
            Dispose(false);
        }

        public void InvokeExampleMethod()
        {
            //Console.WriteLine("调用TestDestructor的方法");
        }

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDisposing">是否释放托管资源</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)//释放托管资源
                {
                    TestStr = null;
                    Console.WriteLine("释放。。。完毕");
                }
                //释放非托管资源，例如，句柄，文件流，GDI+绘图对象等
            }
            isDisposed = true;
        }
    }
}
