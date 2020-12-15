using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5.Controllers
{
    /// <summary>
    /// 在 Controller 级别添加功能开关
    /// </summary>
    [FeatureGate(FeatureFlag.EnableWebAPI)]//在 Controller 级别添加功能开关,EnableWebAPI=true,可以响应
    //[FeatureGate(FeatureFlag.EnableAduit)]//在 Controller 级别添加功能开关EnableAduit=false,不响应
    public class TestFeatureManageController : Controller
    {
        private readonly ILogger<TestFeatureManageController> _logger;
        /// <summary>
        /// 测试.NET应用实现定时开关
        /// </summary>
        private readonly IFeatureManager _featureManager;

        public TestFeatureManageController(IFeatureManager featureManager, ILogger<TestFeatureManageController> logger)
        {
            _featureManager = featureManager;
            _logger = logger;
        }

        [FeatureGate(FeatureFlag.EnableWebAPI)]//在 Action 级别添加功能开关,EnableWebAPI=true,可以响应
        //[FeatureGate(FeatureFlag.EnableAduit)]//在 Action 级别添加功能开关EnableAduit=false,不响应
        public async Task<IActionResult> Index()
        {
            ////.NET应用实现定时开关appsettings.json中的配置文件
            //"FeatureManagement": {
            //"EnableWebAPI": "true",
            //"EnableAduit": "true"
            //},
            if (await _featureManager.IsEnabledAsync(nameof(FeatureFlag.EnableWebAPI)))
            {
                ViewBag.item = "NET应用实现定时开关Index1---在 Action 级别添加功能开关,EnableWebAPI=true,可以响应";
            }
            return View();
        }

        /// <summary>
        /// 测试在action 级别添加功能开关,EnableWebAPI=true,可以响应
        /// </summary>
        /// <returns></returns>
        [FeatureGate(FeatureFlag.EnableWebAPI)]//在 Action 级别添加功能开关,EnableWebAPI=true,可以响应
        //[FeatureGate(FeatureFlag.EnableAduit)]//在 Action 级别添加功能开关EnableAduit=false,不响应
        public async Task<IActionResult> Index1()
        {
            ////.NET应用实现定时开关appsettings.json中的配置文件
            //"FeatureManagement": {
            //"EnableWebAPI": "true",
            //"EnableAduit": "true"
            //},
            if (await _featureManager.IsEnabledAsync(nameof(FeatureFlag.EnableWebAPI)))
            {
                ViewBag.item = "NET应用实现定时开关Index1---在 Action 级别添加功能开关EnableAduit=false,不响应";
            }
            return View();
        }

        /// <summary>
        /// 测试在action 级别添加功能开关,EnableWebAPI=true,可以响应
        /// </summary>
        /// <returns></returns>
        [FeatureGate(FeatureFlag.EnableWebAPI)]//在 Action 级别添加功能开关,EnableWebAPI=true,可以响应
        //[FeatureGate(FeatureFlag.EnableAduit)]//在 Action 级别添加功能开关EnableAduit=false,不响应
        public async Task<IActionResult> Index2()
        {
            ////.NET应用实现定时开关appsettings.json中的配置文件
            //"FeatureManagement": {
            //"EnableWebAPI": "true",
            //"EnableAduit": "true"
            //},
            if (await _featureManager.IsEnabledAsync(nameof(FeatureFlag.EnableWebAPI)))
            {
                ViewBag.item = "NET应用实现定时开关Index2---在 View 上添加功能开关";
            }
            return View();
        }
    }

    /// <summary>
    /// 测试开关枚举
    /// </summary>
    public enum FeatureFlag
    {
        /// <summary>
        /// webapi
        /// </summary>
        EnableWebAPI,
        /// <summary>
        /// 审计
        /// </summary>
        EnableAduit
    }
}
