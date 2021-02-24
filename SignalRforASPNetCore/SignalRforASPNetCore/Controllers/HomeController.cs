using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRforASPNetCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRforASPNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Microsoft.AspNetCore.Authorization.Authorize]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin,teacher,student")]//角色，区分不同的用户操作不同的内容信息，使用逗号分割，表示只要满足其中一个即可访问
        public IActionResult Index()
        {
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
