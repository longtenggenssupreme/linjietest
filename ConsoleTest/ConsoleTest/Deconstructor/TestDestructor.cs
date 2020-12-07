using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class TestDestructor : IDisposable
    {
        private string TestStr;
        public TestDestructor()
        {
            TestStr = "TestDestructor构造函数初始化的字符串";
            Console.WriteLine("TestDestructor构造函数初始化");
        }

        ~TestDestructor()
        {
            Console.WriteLine("TestDestructor析构释放资源");
            Console.WriteLine("释放。。。CurrentDomainSandbox");
            Dispose(false);
        }

        public void InvokeExampleMethod()
        {
            //Console.WriteLine("调用TestDestructor的方法");
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.Collect();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose && !string.IsNullOrEmpty(TestStr))
            {
                TestStr = null;
                Console.WriteLine("释放。。。完毕");
            }
        }
    }
}
