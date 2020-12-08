using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 接口A实现
    /// </summary>
    public class TestF : ITestA
    {
        public TestF()
        {
            Console.WriteLine("这是接口A的实现类TestF 构造函数初始化");
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void Show()
        {
            Console.WriteLine("这是接口A的实现类TestF中的方法");
        }
    }
}
