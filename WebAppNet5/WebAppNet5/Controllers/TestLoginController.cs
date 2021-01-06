using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNet5.Models;

namespace WebAppNet5.Controllers
{
    public class TestLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string password, string verify)
        {
            string verifyCode = HttpContext.Session.GetString("CheckCode");
            if (verifyCode is not null && verifyCode.Equals(verify, StringComparison.OrdinalIgnoreCase))
            {
                //处理验证信息和数据建库中的比对，正确跳转到首页，否则去登陆页
                if ("123".Equals(name) && "123".Equals(password))
                {
                    CurrentUserViewModel currentUser = new CurrentUserViewModel
                    {
                        Id = "123",
                        Name = name,
                        Account = name,
                        Email = "",
                        Password = password,
                        LoginTime = DateTime.Now
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(currentUser);
                    HttpContext.SetCookies("CurrentUser", json);
                    HttpContext.Session.SetString("CurrentUser", json);
                    var user = HttpContext.User;
                    return Redirect("/TestLogin/Index");
                }
            }
            else
            {
                ViewBag.Msg = "密码或者账号错误";
            }
            return View();
        }

        public FileResult VerifyCode()
        {
            string code = "";
            System.Drawing.Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            //HttpContext.Session.SetString("CheckCode", code);
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }
    }
}
