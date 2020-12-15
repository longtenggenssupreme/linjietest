using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppNet5.Models;

namespace WebAppNet5.Controllers
{
    public class HahaController : Controller
    {
        private readonly ILogger<HahaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Rootobject _rootobject;       

        public HahaController(ILogger<HahaController> logger, IConfiguration configuration, IOptions<Rootobject> options)
        {
            _logger = logger;
            _configuration = configuration;
            _rootobject = options.Value;           
        }

        public IActionResult Index()
        {
            ViewBag.CommandParameterPort = _configuration["port"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            ViewBag.CommandParameterIP = _configuration["ip"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            ViewBag.item = "测试ViewBag传值123";
            ViewData["test"] = "测试ViewData传值456";
            TempData["test"] = "测试TempData传值789";
            HahaViewModel model = new HahaViewModel { Id = 1, Name = "张三", Address = "白下路123号", Age = 24 };
            return View(model);
        }

        public IActionResult Index2()
        {
            object root = Newtonsoft.Json.JsonConvert.SerializeObject(_rootobject);
            return View(root);
        }
    }
}
