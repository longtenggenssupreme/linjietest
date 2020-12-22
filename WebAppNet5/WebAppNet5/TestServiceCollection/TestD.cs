using System;

namespace WebAppNet5
{
    /// <summary>
    /// 接口A实现
    /// </summary>
    public class TestD : ITestD
    {
        #region Properties 属性注入
        public ITestA TestA { get; set; }
        public ITestB TestB { get; set; }
        public ITestC TestC { get; set; }
        #endregion

        #region Fields 构造函数注入
        private readonly ITestA _testA;
        private readonly ITestB _testB;
        private readonly ITestC _testC;
        #endregion

        public TestD(ITestA testA, ITestB testB, ITestC testC)
        {
            _testA = testA;
            _testB = testB;
            _testC = testC;
            Console.WriteLine("这是接口D的实现类 构造函数初始化");
        }

        public TestD()
        {            
            Console.WriteLine("这是接口D的实现类 构造函数初始化");
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void Show()
        {
            _testA.Show();//构造函数注入
            TestA.Show();//属性注入
            Console.WriteLine("这是接口D的实现类中的方法");
        }
    }
}
