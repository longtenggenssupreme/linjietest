using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 自定义视图组件，可以加特性，以特性为准，否则使用类名去掉ViewComponent，即MyCustom，调用的时候使用的名称
    /// </summary>
    [ViewComponent(Name = "CustomView")]
    public class MyCustomViewComponent : ViewComponent
    {
        /// <summary>
        /// 这个方法时固定的，必须以InvokeAsync名称为方法名，也可以传参数，例如穿个字符串
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(string json)
        {
            ViewBag.Json = json;
            await Task.Delay(100);
            //return View();//调用哪个视图，默认是使用Shared/Components/Mycustom/Default.cshtml视图
            // 使用自定位置下面的视图Views/Haha/Default.cshtml视图
            return View("~/Views/Haha/Default.cshtml");//调用哪个视图，默认是Default视图
        }
    }
}
