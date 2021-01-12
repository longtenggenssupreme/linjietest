using System;

namespace WebAppTest.Services
{
    public class TestA : ITestA
    {
        public void Show()
        {
            Console.WriteLine($"这是接口ITestA的实现。。。");
        }
    }
}
