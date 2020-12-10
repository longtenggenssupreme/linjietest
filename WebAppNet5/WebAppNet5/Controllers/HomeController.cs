using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppNet5.Models;

namespace WebAppNet5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("LogTrace---这是log4net的测试");
            _logger.LogDebug("LogDebug---这是log4net的测试");
            _logger.LogInformation("LogInformation----这是log4net的测试LogInformation");
            _logger.LogWarning("LogWarning---这是log4net的测试");
            _logger.LogError("LogError---这是log4net的测试");
            _logger.LogCritical("LogCritical---这是log4net的测试");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
