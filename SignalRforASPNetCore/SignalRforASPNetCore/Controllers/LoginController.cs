using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Drawing;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SignalRforASPNetCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[CustomAnonymousFilter]//自定义忽略权限验证的特性标记
        //[AllowAnonymous]//框架Authorization自带的忽略权限验证的特性标记
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[CustomAnonymousFilter]//自定义忽略权限验证的特性标记
        //[AllowAnonymous]//框架Authorization自带的忽略权限验证的特性标记        
        public async Task<IActionResult> Login(string username, string password, string verifycode)
        {
            //验证用户名+密码+验证码
            if ("123".Equals(username) && "123".Equals(password) && verifycode.Equals(HttpContext.Session.GetString("VerifyCode"), StringComparison.OrdinalIgnoreCase))
            {
                //添加用户登录验证以后的信息
                List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim> {
                   new Claim(ClaimTypes.Role,"admin"),
                   new Claim(ClaimTypes.Name,username),
                   new Claim("Password",password)//一般这个是不会写的
                };

                //添加用户角色权限的信息
                List<string> roles = new List<string> { "admin", "teacher", "student" };//admin,teacher,student
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "custom");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30),//设置cookie过期时间
                    AllowRefresh = false,//设置是否刷新
                    IsPersistent = false//设置是否持久化
                });
                //验证用户登录信息成功以后跳转到主页
                return Redirect("/Home/Index");
            }
            else
            {
                //return Json(new { result = "error", msg = "用户名或者密码不正确！" });
                ViewBag.Msg = "密码或者账号错误";
            }
            return View();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //注销登录之后跳转到登陆界面
            return Redirect("/Login");
        }


        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <returns></returns>
        public FileResult VerifyCode()
        {
            Bitmap bitmap = VerifyCodeHelper.GetBitmap(out string code);
            HttpContext.Session.SetString("VerifyCode", code);
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }
    }

    public class VerifyCodeHelper
    {
        public static Bitmap GetBitmap(out string code)
        {
            Bitmap bitmap = new Bitmap(200, 60);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            string randomCode = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            Font font = new Font(FontFamily.GenericSansSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Black);
            //绘制验证码
            for (int i = 0; i < 5; i++)
            {
                var s = randomCode.Substring(random.Next(1, randomCode.Length - 1), 1);
                sb.Append(s);
                graphics.DrawString(s, font, brush, i * 38, random.Next(0, 15));
            }
            //验证码
            code = sb.ToString();
            //混淆背景
            Pen pen = new Pen(new SolidBrush(Color.Black), 2);
            for (int i = 0; i < 6; i++)
            {
                graphics.DrawLine(pen, new Point(random.Next(0, 199), random.Next(0, 59)), new Point(random.Next(0, 199), random.Next(0, 59)));
            }
            return bitmap;
        }

    }
}
