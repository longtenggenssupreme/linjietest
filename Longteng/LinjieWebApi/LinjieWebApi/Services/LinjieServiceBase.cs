using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinjieWebApi
{
    public class LinjieServiceBase : ILinjieServiceBase
    {
        public LinjieServiceBase()
        {
            Console.WriteLine("这是ILinjieServiceBase接口的实现类 构造函数初始化");
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void Show()
        {
            Console.WriteLine("这是ILinjieServiceBase接口的实现类中实现的Show方法");
        }
    }
}
