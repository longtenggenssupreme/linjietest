using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTest.Services
{
    public class TestB : ITestB
    {
        public void Show()
        {
            Console.WriteLine($"这是接口ITestB的实现。。。");
        }
    }
}
