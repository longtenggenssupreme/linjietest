using Castle.DynamicProxy;
using System;
using System.Reflection;
using WebAppTest.CustomAttrributes;

namespace WebAppTest.Extensions
{
    #region 自定义拦截器-可以拦截所有接口方法，都一样不能更具需要特殊定制，如：方法前拦截，方法后来拦截，方法中拦截，没有办法做到
    ///// <summary>
    ///// 自定义拦截器-可以拦截所有接口方法，都一样不能更具需要特殊定制，如：方法前拦截，方法后来拦截，方法中拦截，没有办法做到
    ///// </summary>
    //public class CustomInterceptor : StandardInterceptor
    //{
    //    protected override void PerformProceed(IInvocation invocation)
    //    {
    //        Console.WriteLine($"方法{invocation.Method.Name}执行前。。。。");
    //        base.PerformProceed(invocation);
    //        Console.WriteLine($"方法{invocation.Method.Name}执行后。。。。");
    //    }

    //    protected override void PreProceed(IInvocation invocation)
    //    {
    //        base.PreProceed(invocation);
    //    }

    //    protected override void PostProceed(IInvocation invocation)
    //    {
    //        base.PostProceed(invocation);
    //    }
    //} 
    #endregion

    #region 方法前拦截，方法后来拦截，方法中拦截
    public class CustomInterceptor : StandardInterceptor
    {
        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine($"方法{invocation.Method.Name}执行前。。。。");
            Action action = () => base.PerformProceed(invocation);
            var customAtts = invocation.Method.GetCustomAttributes<AbstractAttribute>();
            foreach (var customAtt in customAtts)
            {
                action = customAtt.Do(invocation, action);
            }
            action.Invoke();
            Console.WriteLine($"方法{invocation.Method.Name}执行后。。。。");
        }

        //protected override void PreProceed(IInvocation invocation)
        //{
        //    var customAtt = invocation.Method.GetCustomAttribute<LogBeforeAttribute>();
        //    customAtt.Do();
        //    base.PreProceed(invocation);
        //}

        //protected override void PostProceed(IInvocation invocation)
        //{
        //    var customAtt = invocation.Method.GetCustomAttribute<LogBeforeAttribute>();
        //    customAtt.Do();
        //    base.PostProceed(invocation);
        //}
    }
    #endregion

    /// <summary>
    /// aop切面编程的拦截器的扩展放方法
    /// </summary>
    public static class AOPExtension
    {
        public static object AOP(this object obj, Type interfaceType)
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            CustomInterceptor customInterceptor = new CustomInterceptor();
            return proxyGenerator.CreateInterfaceProxyWithTarget(interfaceType, obj, customInterceptor);
        }
    }
}
