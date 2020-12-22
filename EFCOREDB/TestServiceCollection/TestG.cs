using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 接口G实现
    /// </summary>
    public class TestG : ITestG
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

        #region Methods 方法注入
        private ITestA _testAM;
        private ITestB _testBM;
        private ITestC _testCM;
        #endregion


        public TestG(ITestA testA, ITestB testB, ITestC testC)//优先使用多个匹配最多的注入接口参数的构造函数
        {
            _testA = testA;
            _testB = testB;
            _testC = testC;
            Console.WriteLine("这是接口D的实现类 构造函数初始化");
        }

        public TestG()//优先使用多个匹配最多的注入接口参数的构造函数
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
            _testBM.Show();//方法注入
            Console.WriteLine("这是接口D的实现类中的方法");
        }

        /// <summary>
        /// 方法注入
        /// </summary>
        public void MethodInject(ITestB testB)
        {
            _testBM = testB;
            Console.WriteLine("方法注入----这是接口D的实现类中的方法");
        }
    }
}
