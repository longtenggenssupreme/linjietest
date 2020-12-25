using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppNet5
{
    /// <summary>
    /// filter 五种过滤器 IAuthorizationFilter,IResourceFilter,IActionFilter,IResultFilter,IExceptionFilter
    /// 第1种自定义过滤器特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class CustomFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("这是过滤器执行前");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("这是过滤器执行后。。。。");
        }
    }

    /// <summary>
    /// 第2种自定义过滤器特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("这是Action过滤器执行前");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("这是Action过滤器执行后。。。。");
        }
    }

    /// <summary>
    /// 第3种自定义过滤器特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class CustomActionFilterChildAttribute : Attribute, IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("这是Action过滤器执行前");
            });
        }
    }
}
