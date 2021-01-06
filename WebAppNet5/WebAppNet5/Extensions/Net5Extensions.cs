using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    public static class Net5Extensions
    {
        public static void SetCookies(this HttpContext httpContext, string key, string value)
        {
            httpContext.Response.Cookies.Append(key, value, new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddSeconds(40)) });

        }
        public static void DeleteCookies(this HttpContext httpContext, string key)
        {
            if (httpContext.Response.Cookies.Equals(key))
            {
                httpContext.Response.Cookies.Delete(key);
            }
        }

        public static string GetCookies(this HttpContext httpContext, string key)
        {
            httpContext.Request.Cookies.TryGetValue(key, out string result);

            return result;
        }

        public static void SetSession(this HttpContext httpContext, string key, string value)
        {
            httpContext.Session.SetString(key, value);

        }
        public static void DeleteSession(this HttpContext httpContext, string key)
        {
            if (httpContext.Session.Keys.Equals(key))
            {
                httpContext.Session.Remove(key);
            }
        }

        public static string GetSession(this HttpContext httpContext, string key)
        {
            return httpContext.Session.Keys.Equals(key) ? httpContext.Session.GetString(key) : "";
        }

        public static CurrentUserViewModel GetCurrenUserBySession(this HttpContext httpContext)
        {
            var result = httpContext.Session.GetString("CurreentUser");
            return result==null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentUserViewModel>(result);
        }
    }
}
