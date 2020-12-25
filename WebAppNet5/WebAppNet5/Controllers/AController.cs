using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    /// <summary>
    /// Autofac 一对象多实例问题,例如：一个接口ITestA 2个实现TestA和TestF
    /// </summary>
    public class AController : Controller
    {
        #region Properties 属性注入
        [CustomProp]
        public ITestA TestA { get; set; }
        #endregion

        #region Fields 构造函数注入
        private readonly ITestA _testA;
        private readonly IEnumerable<ITestA> _testAList;
        private readonly ITestC _testC;
        private readonly TestA _testAA;
        private readonly TestF _testFF;
        private readonly Rootobject _rootobject;
        /// <summary>
        /// 组件上下文，用于一接口多实现的使用
        /// </summary>
        private readonly IComponentContext _componentContext;
        #endregion
        ///// <summary>
        ///// 1、一接口多实现的使用，ITestA testA, IEnumerable<ITestA> testAList, TestA testAA, TestF testFF
        ///// </summary>
        ///// <param name="testA"></param>
        ///// <param name="testAList"></param>
        ///// <param name="testAA"></param>
        ///// <param name="testFF"></param>
        ///// <param name="testC"></param>
        ///// <param name="options"></param>
        //public AController(ITestA testA, IEnumerable<ITestA> testAList, TestA testAA, TestF testFF, ITestC testC, IOptions<Rootobject> options/*, IOptionsMonitor<Rootobject> optionsMonitor, IOptionsSnapshot<Rootobject> optionsSnapshot*/)
        //{
        //    _testA = testA;
        //    _testAList = testAList;
        //    _testAA = testAA;
        //    _testFF = testFF;
        //    _testC = testC;
        //    _rootobject = options.Value;
        //    //_rootobject = optionsMonitor.CurrentValue;
        //    //_rootobject = optionsSnapshot.Value;
        //    Console.WriteLine("这是接口D的实现类 构造函数初始化");
        //}

        /// <summary>
        /// 2、一接口多实现的使用，IComponentContext组件上下文，用于一接口多实现的使用
        /// </summary>
        /// <param name="testA"></param>
        /// <param name="testAList"></param>
        /// <param name="testAA"></param>
        /// <param name="testFF"></param>
        /// <param name="testC"></param>
        /// <param name="options"></param>
        public AController(IComponentContext componentContext, IOptions<Rootobject> options/*, IOptionsMonitor<Rootobject> optionsMonitor, IOptionsSnapshot<Rootobject> optionsSnapshot*/)
        {
            _componentContext = componentContext;
            _rootobject = options.Value;
            //_rootobject = optionsMonitor.CurrentValue;
            //_rootobject = optionsSnapshot.Value;
            Console.WriteLine("这是一接口多实现的使用，IComponentContext组件上下文，用于一接口多实现的使用");
        }

        public IActionResult Index()
        {
            _testA.Show();
            TestA.Show();
            return View();
        }

        public IActionResult Index1()
        {
            ITestA testA = _componentContext.ResolveKeyed<ITestA>("TestA");
            ITestA testA1 = _componentContext.ResolveNamed<ITestA>("TestA");
            testA.Show();
            testA1.Show();
            ITestA testF = _componentContext.ResolveKeyed<ITestA>("TestF");
            testF.Show();
            ITestA testF1 = _componentContext.ResolveKeyed<ITestA>("TestF");
            testF1.Show();
            return View();
        }
    }
}
