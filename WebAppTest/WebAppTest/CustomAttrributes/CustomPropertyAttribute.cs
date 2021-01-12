using Castle.DynamicProxy;
using System;

namespace WebAppTest.CustomAttrributes
{
    #region 自定义的控制器创建对象，以便使用ioc创建控制器，Controller控制器属性注入和Controller控制器方法注入 其实IOC就是一个字典Dictionary
    /// <summary>
    /// 属性的特性标记，主要用于标记属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomPropertyAttribute : Attribute
    {
    }

    /// <summary>
    /// 方法的特性标记，主要用于标记方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : Attribute
    {
    }
    #endregion


    #region 拦截器特性111
    ///// <summary>
    ///// 标记方法拦截前
    ///// </summary>    
    //public class LogBeforeAttribute : Attribute
    //{
    //    public void Do() {
    //        Console.WriteLine("LogBeforeAttribute执行---前");
    //    }
    //}

    ///// <summary>
    ///// 标记方法拦截中
    ///// </summary>
    //public class LogMonitorAttribute : Attribute
    //{
    //}

    ///// <summary>
    ///// 标记方法拦截后
    ///// </summary>
    //public class LogAfterAttribute : Attribute
    //{
    //    public void Do()
    //    {
    //        Console.WriteLine("LogAfterAttribute执行---后");
    //    }
    //}
    #endregion

    #region 拦截器特性抽象
    public abstract class AbstractAttribute : Attribute
    {
        public abstract Action Do(IInvocation invocation, Action action);
    }

    /// <summary>
    /// 标记方法拦截前
    /// </summary>    
    public class LogBeforeAttribute : AbstractAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                action.Invoke();
                //添加需要处理的操作
                Console.WriteLine($"LogBeforeAttribute执行---前,{invocation.Method.Name}");
            };
        }
    }

    /// <summary>
    /// 标记方法拦截中
    /// </summary>
    public class LogMonitorAttribute : AbstractAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                Console.WriteLine($"LogMonitorAttribute执行---中,{invocation.Method.Name}");
                //添加需要处理的操作
                action.Invoke();
                //添加需要处理的操作
                Console.WriteLine($"LogMonitorAttribute执行---中,{invocation.Method.Name}");
            };
        }
    }

    /// <summary>
    /// 标记方法拦截后
    /// </summary>
    public class LogAfterAttribute : AbstractAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                Console.WriteLine($"LogAfterAttribute执行---后,{invocation.Method.Name}");
                //添加需要处理的操作
                action.Invoke();
            };
        }
    }
    #endregion
}
