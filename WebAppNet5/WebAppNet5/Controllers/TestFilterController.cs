using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    #region ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter
    //[ControllerFilterExecRangeAndOrder]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
    //public class TestFilterController : Controller
    //{
    //    //未使用构造函数依赖注入时，可以使用该特性[CustomFilter]标记,即自定义的filter过滤器CustomFilter，时必须要有无参构造函数
    //    //[TypeFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    //[ServiceFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    //[CustomFilterFactory(typeof(CustomFilterAttribute))]//自定义过滤器工厂，可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [ActionFilterExecRangeAndOrder]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
    //    public IActionResult IndexTest()
    //    {
    //        return View();
    //    }
    //}
    #endregion

    #region ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    //[ControllerFilterExecRangeAndOrder(Order =-2)]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
    //public class TestFilterController : Controller
    //{
    //    //未使用构造函数依赖注入时，可以使用该特性[CustomFilter]标记,即自定义的filter过滤器CustomFilter，时必须要有无参构造函数
    //    //[TypeFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    //[ServiceFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    //[CustomFilterFactory(typeof(CustomFilterAttribute))]//自定义过滤器工厂，可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [ActionFilterExecRangeAndOrder(Order = -1)]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
    //    public IActionResult IndexTest()
    //    {
    //        return View();
    //    }
    //}
    #endregion

    #region ControllerFilterExecRangeAndOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    //[ControllerFilterExecRangeAndOrder(Order = -2)]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
    [ControllerFilterExecRangeAndOrder]
    public class TestFilterController : Controller
    {
        private ITestExceptionFitertest _testExceptionFitertest = null;
        public TestFilterController(ITestExceptionFitertest testExceptionFitertest)//控制器实例化异常 ---- 可以捕获异常
        {
            //int i = 0;
            //int j = 1;
            //int k = j / i;
            _testExceptionFitertest = testExceptionFitertest;
        }

        //未使用构造函数依赖注入时，可以使用该特性[CustomFilter]标记,即自定义的filter过滤器CustomFilter，时必须要有无参构造函数
        [TypeFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
        //[ServiceFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
        //[CustomFilterFactory(typeof(CustomFilterAttribute))]//自定义过滤器工厂，可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
        [CustomAnonymousFilter]
        public IActionResult Index()
        {
            return View();
        }

        //[ActionFilterExecRangeAndOrder(Order = -1)]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
        [ActionFilterExecRangeAndOrder]
        public IActionResult IndexTest()
        {
            return View();
        }

        //[ActionFilterExecRangeAndOrder(Order = -1)]//自定义过滤器ActionFilterExec ,测试全局过滤器，controller控制器过滤器，action过滤器
        [CustomResourceFilter]//自定义过滤器IResourceFilter
        public IActionResult IndexTestResource()
        {
            ViewBag.date = DateTime.Now;
            return View();
        }

        //[CustomExceptionFilterAttribute]//自定义异常过滤器IExceptionFilter
        //[TypeFilter(typeof(CustomExceptionFilterAttribute))]//自定义异常过滤器IExceptionFilter
        public void IndexTestException()
        {
            int i = 0;
            int j = 1;
            int k = j / i;
            //return View();

            //try//异常发生在try-catch中 ---- 无法捕获异常
            //{
            //    int i = 0;
            //    int j = 1;
            //    int k = j / i;
            //    //return View();
            //}
            //catch (Exception)
            //{

            //    //
            //}
        }

        public IActionResult IndexTestViewException()
        {
            //视图中发生异常 ---- 无法捕获异常
            //int i = 0;
            //int j = 1;
            //int k = j / i;
            return View();
        }

        /// <summary>
        /// 测试异常过滤器的使用
        /// </summary>
        public void TestExceptionFitertest()
        {
            //Services层发生异常---- 可以捕获异常
            _testExceptionFitertest.Show();
        }

        /// <summary>
        // /// 测试----结果过滤器
        // /// </summary>
        //[CustomResultFilter]
        // public IActionResult TestResultFilter()
        // {            
        //     return View();
        // }

        /// <summary>
        /// 测试----结果过滤器
        /// </summary>
        [TypeFilter(typeof(CustomResultFilterAttribute))]
        public IActionResult TestResultFilter()
        {
            return View();
        }
    }
    #endregion
}
