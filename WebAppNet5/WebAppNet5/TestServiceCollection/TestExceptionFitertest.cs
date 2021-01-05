using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 测试异常过滤器的使用
    /// </summary>
    public class TestExceptionFitertest : ITestExceptionFitertest
    {
        /// <summary>
        /// 测试方法--Services层发生异常 ---- 可以捕获异常
        /// </summary>
        public void Show()//Services层发生异常 ---- 可以捕获异常
        {
            int i = 0;
            int j = 1;
            int k = j / i;
            Console.WriteLine("这是接口ITestExceptionFitertest的实现类中的方法");
        }
    }
}
