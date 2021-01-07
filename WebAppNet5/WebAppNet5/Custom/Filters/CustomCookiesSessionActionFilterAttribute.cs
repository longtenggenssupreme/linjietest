using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// cookies和session过滤器
    /// </summary>
    public class CustomCookiesSessionActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //if (context.ActionDescriptor.EndpointMetadata.Any(item => item.GetType() == typeof(CustomAnonymousFilterAttribute)))
            //{
            //    return;
            //}
            Console.WriteLine("cookies和session过滤器===这是过滤器执行前");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(att=>att.GetType()==typeof(CustomAnonymousFilterAttribute)))
            {
                return;
            }

            Console.WriteLine("cookies和session过滤器===这是过滤器执行后。。。。");
            var currentUser = context.HttpContext.GetCurrenUserBySession();
            if (currentUser is  null)
            {
                if (IsAjaxRequest(context.HttpContext))
                {
                    var jsonResult = new JsonResult(new { Msg = "ajax请求信息。", Result = "ajax请求结果" });
                    context.Result = jsonResult;
                }
                context.Result = new RedirectResult("/TestLogin/Login");
            }
        }

        private bool IsAjaxRequest(HttpContext httpContext) => "XMLHttpRequest".Equals(httpContext.Request.Headers["X-Requested-With"]);
    }
}
