using Castle.Core;
using System;

namespace WebAppNet5
{
    /// <summary>
    /// 接口A实现
    /// <summary>
    public class TestA : ITestA
    {
        public TestA()
        {
            Console.WriteLine("这是接口A的实现类 构造函数初始化");
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void Show()
        {
            Console.WriteLine("这是接口A的实现类中的方法");
        }
    }
}
