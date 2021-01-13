using Linjie.NET5.BLL;
using Linjie.NET5.DAL.Entity;
using Linjie.NET5.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Linjie.NET5.WebUI.Controllers
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
            LinjieNET5BLLServices linjieNET5BLLServices = new LinjieNET5BLLServices();
            JdCommodity001 jdCommodity001 = new JdCommodity001
            {
                //Id = 123,
                ProductId = 1111111,
                CategoryId = 711189,
                ImageUrl = "imageurl",
                Price = 123,
                Title = "11111",
                Url = "url"
            };
            linjieNET5BLLServices.Add<JdCommodity001>(jdCommodity001);
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
