using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class CustomInterceptor : IInterceptor
    {
        /// <summary>
        /// 异步拦截器
        /// </summary>
        private readonly CustomAsyncInterceptor _customAsyncInterceptor;

        public CustomInterceptor(CustomAsyncInterceptor customAsyncInterceptor)
        {
            _customAsyncInterceptor = customAsyncInterceptor;
        }

        public void Intercept(IInvocation invocation)
        {
            //方法调用之前
            Console.WriteLine($"方法调用之前");
            _customAsyncInterceptor.ToInterceptor().Intercept(invocation);
            //invocation.Proceed();
            //方法调用之后
            Console.WriteLine("方法调用之后");
        }
    }
}
