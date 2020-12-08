using System;

namespace WebAppNet5
{
    /// <summary>
    /// 接口A实现
    /// </summary>
    public class TestD : ITestD
    {
        public TestD()
        {
            Console.WriteLine("这是接口D的实现类 构造函数初始化");
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void Show()
        {
            Console.WriteLine("这是接口D的实现类中的方法");
        }
    }
}
