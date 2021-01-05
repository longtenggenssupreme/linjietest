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
    /// <summary>
    /// 结果过滤器
    /// </summary>
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {

        private IModelMetadataProvider _modelMetadataProvider;
        public CustomResultFilterAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        /// <summary>
        /// 结果过滤器--过滤前
        /// </summary>
        /// <param name="context"></param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Request.Query["view"]=="1")//中文显示的结果
            {

                var viewResult = new ViewResult() { ViewName = "~/Views/TestFilter/IndexResult1.cshtml" };
                viewResult.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                context.Result = viewResult;
            }
            else//英文文显示的结果
            {
                var viewResult = new ViewResult() { ViewName = "~/Views/TestFilter/IndexResult2.cshtml" };
                viewResult.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                context.Result = viewResult;
            }
            Console.WriteLine("结果过滤器--过滤前");
        }

        /// <summary>
        /// 结果过滤器--过滤后
        /// </summary>
        /// <param name="context"></param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("结果过滤器--过滤后");
        }
    }
}
