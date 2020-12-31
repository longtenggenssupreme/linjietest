using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppNet5
{
    #region .NET5_Filter的生效范围和控制执行顺序==默认
    ///// <summary>
    ///// 全局的Filter过滤器
    ///// </summary>
    //public class GlobalFilterExecRangeAndOrderAttribute : Attribute, IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行前");
    //    }
    //}

    ///// <summary>
    /////Controller Filter过滤器
    ///// </summary>
    //public class ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行前");
    //    }
    //}

    ///// <summary>
    /////Action Filter过滤器
    ///// </summary>
    //public class ActionFilterExecRangeAndOrderAttribute : Attribute, IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行前");
    //    }
    //}
    #endregion

    #region .NET5_Filter的生效范围和控制执行顺序==默认--修改，指定执行顺序 ActionFilterAttribute
    ///// <summary>
    ///// 全局的Filter过滤器
    ///// </summary>
    //public class GlobalFilterExecRangeAndOrderAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行前");
    //    }

    //    public override void OnResultExecuted(ResultExecutedContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行后。。。。");
    //    }
    //    //public void OnActionExecuted(ActionExecutedContext context)
    //    //{
    //    //    Console.WriteLine("Global Filter过滤器执行前");
    //    //}

    //    //public void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    Console.WriteLine("Global Filter过滤器执行后。。。。");
    //    //}
    //}

    ///// <summary>
    /////Controller Filter过滤器
    ///// </summary>
    //public class ControllerFilterExecRangeAndOrderAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行前");
    //    }

    //    public override void OnResultExecuted(ResultExecutedContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行后。。。。");
    //    }
    //    //public void OnActionExecuted(ActionExecutedContext context)
    //    //{
    //    //    Console.WriteLine("Controller Filter过滤器执行后。。。。");
    //    //}

    //    //public void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    Console.WriteLine("Controller Filter过滤器执行前");
    //    //}
    //}

    ///// <summary>
    /////Action Filter过滤器
    ///// </summary>
    //public class ActionFilterExecRangeAndOrderAttribute : ActionFilterAttribute
    //{

    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行前");
    //    }

    //    public override void OnResultExecuted(ResultExecutedContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行后。。。。");
    //    }
    //    //public void OnActionExecuted(ActionExecutedContext context)
    //    //{
    //    //    Console.WriteLine("Action Filter过滤器执行后。。。。");
    //    //}

    //    //public void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    Console.WriteLine("Action Filter过滤器执行前");
    //    //}
    //}
    #endregion

    #region .NET5_Filter的生效范围和控制执行顺序==默认--修改，指定执行顺序 Attribute, IActionFilter, IOrderedFilter
    /// <summary>
    /// 全局的Filter过滤器
    /// </summary>
    public class GlobalFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Global Filter过滤器执行后。。。。");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Global Filter过滤器执行前");
        }
    }

    /// <summary>
    ///Controller Filter过滤器
    /// </summary>
    public class ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Controller Filter过滤器执行后。。。。");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Controller Filter过滤器执行前");
        }
    }

    /// <summary>
    ///Action Filter过滤器
    /// </summary>
    public class ActionFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Filter过滤器执行后。。。。");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Filter过滤器执行前");
        }
    }
    #endregion

    #region .NET5_Filter的生效范围和控制执行顺序==默认--修改，指定执行顺序 Attribute, IActionFilter, IOrderedFilter
    ///// <summary>
    ///// 全局的Filter过滤器
    ///// </summary>
    //public class GlobalFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    //{
    //    public int? _order;

    //    public int Order { get; set; }

    //    public GlobalFilterExecRangeAndOrderAttribute(int? order)
    //    {
    //        _order = order;
    //        Order = _order ?? 0;
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Global Filter过滤器执行前");
    //    }
    //}

    ///// <summary>
    /////Controller Filter过滤器
    ///// </summary>
    //public class ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    //{
    //    public int? _order;

    //    public int Order { get; set; }

    //    public ControllerFilterExecRangeAndOrderAttribute(int? order)
    //    {
    //        _order = order;
    //        Order = _order ?? 0;
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Controller Filter过滤器执行前");
    //    }
    //}

    ///// <summary>
    /////Action Filter过滤器
    ///// </summary>
    //public class ActionFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    //{
    //    public int? _order;

    //    public int Order { get; set; }

    //    public ActionFilterExecRangeAndOrderAttribute(int? order)
    //    {
    //        _order = order;
    //        Order = _order ?? 0;
    //    }

    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行后。。。。");
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        Console.WriteLine("Action Filter过滤器执行前");
    //    }
    //}
    #endregion
}
