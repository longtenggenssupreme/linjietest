using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    public class HHController : Controller
    {
        #region Fields 构造函数依赖注入
        private readonly ILogger<HahaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Rootobject _rootobject;
        #endregion

        #region Properties 属性注入
        [CustomProp]
        public ITestA TestA { get; set; }
        public ITestB TestB { get; set; }
        public ITestC TestC { get; set; }
        #endregion

        #region Fields 构造函数注入
        private readonly ITestA _testA;
        private readonly ITestB _testB;
        private readonly ITestC _testC;
        #endregion

        public HHController(ITestA testA, ITestB testB, ITestC testC)
        {
            _testA = testA;
            _testB = testB;
            _testC = testC;
            Console.WriteLine("这是接口D的实现类 构造函数初始化");
        }


        //public HHController(ILogger<HahaController> logger, IConfiguration configuration, IOptions<Rootobject> options)
        //{
        //    _logger = logger;
        //    _configuration = configuration;
        //    _rootobject = options.Value;
        //}

        public IActionResult Index()
        {
            TestA.Show();
            return View();
        }
    }
}
