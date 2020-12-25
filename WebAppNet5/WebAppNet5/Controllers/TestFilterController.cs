using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    public class TestFilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}
