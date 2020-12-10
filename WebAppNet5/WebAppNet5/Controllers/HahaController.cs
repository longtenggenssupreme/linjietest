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
    public class HahaController : Controller
    {
        private readonly ILogger<HahaController> _logger;

        public HahaController(ILogger<HahaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HahaViewModel model = new HahaViewModel { Id = 1, Name = "张三", Address = "白下路123号", Age = 24 };
            return View(model);
        }
    }
}
