using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 自定义资源过滤器，一般用作缓存
    /// </summary>
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        /// <summary>
        /// 缓存字典
        /// </summary>
        public Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();


        /// <summary>
        /// 自定义资源过滤器执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("CustomResourceFilter Filter过滤器执行前");
            var keyavlue = context.HttpContext.Request.Path;
            if (CacheDictionary.ContainsKey(keyavlue))
            {
                context.Result = CacheDictionary[keyavlue] as IActionResult;
            }
        }

        /// <summary>
        /// 自定义资源过滤器执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var keyavlue = context.HttpContext.Request.Path;
            if (!CacheDictionary.ContainsKey(keyavlue))
            {
                CacheDictionary[keyavlue] = context.Result;
            }
            Console.WriteLine("CustomResourceFilter Filter过滤器执行后。。。。");
        }
    }
}
