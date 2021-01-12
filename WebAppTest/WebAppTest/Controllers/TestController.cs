using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.CustomAttrributes;
using WebAppTest.Extensions;
using WebAppTest.Services;

namespace WebAppTest.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// 属性注入--Controller控制器属性注入，CustomPropertyAttribute标记需要的属性，不是所有的属性
        /// </summary>
        [CustomPropertyAttribute]
        public ITestA _testA { get; set; }

        /// <summary>
        /// 用于方法注入的字段
        /// </summary>
        private ITestB _testB;
        /// <summary>
        /// 方法注入--Controller控制器方法注入，CustomMethodAttribute标记需要的方法，不是所有的方法
        /// </summary>
        [CustomMethodAttribute]
        public void CreateInstance(ITestB testB)
        {
            _testB = testB;
        }

        public IActionResult Index()
        {
            //_testA.Show();
            _testB.Show();
            ((ITestA)_testA.AOP(typeof(ITestA))).Show();
            return View();
        }
    }
}
