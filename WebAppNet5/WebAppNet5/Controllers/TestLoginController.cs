using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNet5.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebAppNet5.Controllers
{
    //[Authorize]
    public class TestLoginController : Controller
    {
        //[CustomCookiesSessionActionFilter]//局部注册CookiesSessionActionFilter
        [Authorize(Roles = "Admin,Teacher,Stdent")]//角色，区分不同的用户操作不同的内容信息，使用逗号分割，表示只要满足其中一个即可访问
        //[ValidateAntiForgeryToken]//MVC Html.AntiForgeryToken() 防止CSRF攻击，前端form表单@Html.AntiForgeryToken()和action 方法特性[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            return View();
        }

        //[CustomCookiesSessionActionFilter]//局部注册CookiesSessionActionFilter
        //[Authorize]
        //[ValidateAntiForgeryToken]//MVC Html.AntiForgeryToken() 防止CSRF攻击，前端form表单@Html.AntiForgeryToken()和action 方法特性[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]//角色，区分不同的用户操作不同的内容信息，使用多个特性的话必须都满足才可访问
        [Authorize(Roles = "Teacher")]//同时满足才可访问
        [Authorize(Roles = "Stdent")]//同时满足才可访问
        public IActionResult Index01()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]//角色，区分不同的用户操作不同的内容信息，使用多个特性的话必须都满足才可访问
        [Authorize(Roles = "Teacher")]//同时满足才可访问
        [Authorize(Roles = "Stdent11")]//同时满足才可访问
        public IActionResult Index02()
        {
            return View();
        }
        
        //[Authorize(Roles = "Admin")]//角色，区分不同的用户操作不同的内容信息，使用多个特性的话必须都满足才可访问
        //[Authorize(Roles = "Teacher")]//同时满足才可访问
        [Authorize(policy:  "custompolicy")]//不使用Roles角色，而是使用自定义的策略policy，满足策略的才可以访问，否则不能访问
        public IActionResult Index03()//使用权限验证策略 CustomAuthorizationHandler
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]//角色，区分不同的用户操作不同的内容信息，使用多个特性的话必须都满足才可访问
        //[Authorize(Roles = "Teacher")]//同时满足才可访问
        [Authorize(policy: "custompolicy11")]//不使用Roles角色，而是使用自定义的策略policy，满足策略的才可以访问，否则不能访问
        public IActionResult Index04()//使用权限验证策略 CustomAuthorizationHandler
        {
            return View();
        }

        [HttpGet]
        [CustomAnonymousFilter]//自定义忽略权限验证的特性标记
        [AllowAnonymous]//框架Authorization自带的忽略权限验证的特性标记
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [CustomAnonymousFilter]//自定义忽略权限验证的特性标记
        [AllowAnonymous]//框架Authorization自带的忽略权限验证的特性标记
        public IActionResult Login(string name, string password, string verify) 
        {
            //if (ModelState.IsValid)
            //{

            //}
            string verifyCode = HttpContext.Session.GetString("CheckCode");//获取验证码
            if (verifyCode is not null && verifyCode.Equals(verify, StringComparison.OrdinalIgnoreCase))//检查验证码是否一样
            {
                //处理验证信息和数据建库中的比对，正确跳转到首页，否则去登陆页
                if ("123".Equals(name) && "123".Equals(password))//验证数据库的用户信息是否一致
                {
                    #region Cookies Session 使用actionfilter 验证权限
                    //CurrentUserViewModel currentUser = new CurrentUserViewModel
                    //{
                    //    Id = "123",
                    //    Name = name,
                    //    Account = name,
                    //    Email = "",
                    //    Password = password,
                    //    LoginTime = DateTime.Now
                    //};

                    //string json = Newtonsoft.Json.JsonConvert.SerializeObject(currentUser);
                    //HttpContext.SetCookies("CurrentUser", json);
                    //HttpContext.Session.SetString("CurrentUser", json);
                    #endregion

                    #region Authorization 使用自带的权限验证 验证权限

                    //身份信息
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.Role,"Admin"),
                        new Claim(ClaimTypes.Name,name),
                        new Claim("Password",password),
                        new Claim(ClaimTypes.Email,"Email")
                    };

                    List<string> rolesList = new List<string> { "Admin", "Teacher", "Stdent" };

                    foreach (var item in rolesList)//添加权限
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Customer");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    base.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                        }).Wait();
                    #endregion

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

        [CustomAnonymousFilter]//自定义忽略权限验证的特性标记
        [AllowAnonymous]//框架Authorization自带的忽略权限验证的特性标记
        public FileResult VerifyCode()
        {
            string code = "";
            System.Drawing.Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode", code);
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }
    }
}
