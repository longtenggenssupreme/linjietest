using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    public class AOPController : Controller
    {
        #region Fields 构造函数注入
        private readonly ITestB _testB;
        private readonly ITestC _testC;
        private readonly Rootobject _rootobject;
        #endregion
        public AOPController(ITestB testB, ITestC testC, IOptions<Rootobject> options/*, IOptionsMonitor<Rootobject> optionsMonitor, IOptionsSnapshot<Rootobject> optionsSnapshot*/)
        {
            _testB = testB;
            _rootobject = options.Value;
            _testC = testC;
            //_rootobject = optionsMonitor.CurrentValue;
            //_rootobject = optionsSnapshot.Value;
        }
        public IActionResult Index()
        {
            _testB.Show();
            _testC.Show();
            return View();
        }
    }
}
