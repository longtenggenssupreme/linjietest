using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {

        #region MyRegion
        //public void OnException(ExceptionContext context)
        //{
        //    if (context.ExceptionHandled)
        //    {
        //        if (this.IsAjaxRequest(context.HttpContext.Request))
        //        {
        //            context.Result = new JsonResult(new { result = false, msg = context.Exception.Message });
        //        }
        //        else
        //        {
        //            var viewresult = new ViewResult { ViewName = "~/views/shared/error.html" };
        //            viewresult.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(m odelMetadataProvider, context.ModelState);
        //            viewresult.ViewData.Add("Exception", context.Exception);
        //            context.Result = viewresult;
        //        }
        //    }
        //    context.ExceptionHandled = true;
        //}

        //private bool IsAjaxRequest(HttpRequest httpRequest)
        //{
        //    string header = httpRequest.Headers["X-Requested-With"];
        //    return "XMLHttpRequest".Equals(header);
        //} 
        #endregion

        private IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilterAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)//异常未处理
            {
                if (IsAjaxRequest(context.HttpContext.Request))
                {
                    var jsonResult = new JsonResult(new { result = context.HttpContext.Request.Path, Message = context.Exception.Message });
                    context.Result = jsonResult;
                }
                else
                {
                    var viewResult = new ViewResult() { ViewName = "~/Views/Shared/Error.cshtml" };
                    viewResult.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                    viewResult.ViewData.Add("Error", context.Exception);
                    context.Result = viewResult;
                }
            }
            context.ExceptionHandled = true;//设置异常已经处理
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            string result = request.Headers["x-requested-with"];//X-Requested-WITH
            return "XMLHttpRequest".Equals(result);
        }
    }
}
