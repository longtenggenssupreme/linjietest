using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 自定义异步拦截器
    /// </summary>
    public class CustomAsyncInterceptor : IAsyncInterceptor
    {
        public void InterceptAsynchronous(IInvocation invocation)
        {
            invocation.Proceed();
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsynchronous<TResult>(invocation);
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            invocation.Proceed();
        }

        public async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            //方法调用之前
            Console.WriteLine($"方法调用之前");
            invocation.Proceed();
            var taskresult = (Task<TResult>)invocation.ReturnValue;
            var result = await taskresult;
            //方法调用之后
            Console.WriteLine("方法调用之后");
            return result;
        }
    }
}
