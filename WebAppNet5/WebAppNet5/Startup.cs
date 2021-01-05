using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebAppNet5.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.Json;
using Autofac.Configuration;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Features.ResolveAnything;
using Castle.Core;
using Autofac.Extras.DynamicProxy;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using System.Text;

namespace WebAppNet5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 读取配置文件方式
            ////第一种读取配置文件方式---直接读取配置，通过索引读取
            //var writeConnectString = Configuration["ConnectingStrings:WriteConnecting"];//读取对应的配置，上下级之间使用冒号分割
            //Console.WriteLine($"第一种读取配置文件方式: writeConnectString={writeConnectString}");
            //var testConnectStringServer = Configuration["ConnectingStrings:TestConnecting:Server"];
            //Console.WriteLine($"第一种读取配置文件方式: testConnectStringServer={testConnectStringServer}");
            //var testConnectString = Configuration["ConnectingStrings:TestConnecting:Microsoft.Hosting.Lifetime"];
            //Console.WriteLine($"第一种读取配置文件方式: testConnectString={testConnectString}");
            ////var testConnectString22 = Configuration.GetSection("ConnectingStrings");
            ////Console.WriteLine($"第一种读取配置文件方式: testConnectString={testConnectString}");
            //Console.WriteLine($"---------------------");

            ////第二种读取配置文件方式---配置文件绑定指定的对象
            ////缺点:必须先创建该绑定的对象，之后才能使用，不方便
            //Rootobject rootobject = new Rootobject();
            //Configuration.Bind(rootobject);
            //Connectingstrings option = new Connectingstrings();
            //Configuration.GetSection("ConnectingStrings").Bind(option);

            ////无需先创建该绑定的对象，其他需要的地方使用构造函数依赖注入 IOptions<Connectingstrings> options 获取options.Value即可使用
            ////使用IServiceCollection注册配置文件，绑定指定的实例对象
            //services.Configure<Rootobject>(Configuration);
            //services.Configure<Connectingstrings>(Configuration.GetSection("ConnectingStrings"));

            //Console.WriteLine($"第二种读取配置文件方式: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");

            ////第三种读取配置文件方式
            //var ip = Configuration["ip"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //var port = Configuration["port"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //Console.WriteLine($"第三种读取配置文件方式: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");
            #endregion

            services.Configure<Rootobject>(Configuration);
            services.AddControllersWithViews();
            //services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            //NLog.LogManager.GetCurrentClassLogger().Info("测试nlog日志。。。。。");
            //NLog.LogManager.Shutdown();
            services.AddRazorPages().AddRazorRuntimeCompilation();//启动的预编译，默认系统会将视图编译进行预编译处理，最终会将编译好的视图
            //.NET应用实现定时开关
            services.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();

            //控制器属性注入，默认ioc容器之创建接口服务，控制器的创建是由IControllerActivator创建的，现在使用ioc容器创建ServiceBasedControllerActivator
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            #region 添加使用限流服务AspNetCoreRateLimit
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimit"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddHttpContextAccessor();

            //添加全局过滤器
            services.AddMvc(option => //option.Filters.Add<GlobalFilterExecRangeAndOrderAttribute>()
            option.Filters.Add<CustomExceptionFilterAttribute>());
            #endregion

            //需要使用 Encoding.RegisterProvider方法进行注册Provider Encoding 支持如：GB2312编码等。
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            #region 服务容器

            #region 原生的服务容器
            //原生的服务容器，会自动注册到当前Autofac container容器中去，不需要使用containerBuilder.Populate(services);

            ////containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            ////containerBuilder.RegisterType<TestB>().As<ITestB>().InstancePerDependency();
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerDependency();
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerDependency(); 
            #endregion

            #region Autofac默认都是构造函数注入
            ////Autofac默认都是构造函数注入
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();//瞬态
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();//单例
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//作用域，应用域
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////指定作用域，指定应用域 
            #endregion

            #region Autofac使用方法注入----接口中的实现类中的其他接口服务的属性注入
            ////Autofac使用方法注入----接口中的实现类中的其他接口服务的属性注入
            //containerBuilder.RegisterType<TestG>()
            //.OnActivated(t => t.Instance.MethodInject(t.Context.Resolve<ITestB>()))
            //.As<ITestG>().InstancePerMatchingLifetimeScope("TEST456")
            //.PropertiesAutowired();//指定作用域，指定应用域 
            #endregion

            #region Autofac接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            ////Autofac接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            //containerBuilder.RegisterType<TestE>().As<ITestE>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//指定作用域，指定应用域 
            #endregion

            #region Autofac Controller控制器中接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            //Autofac Controller控制器中接口服务使用属性注入----PropertiesAutowired属性注入----接口中的实现类中的其他接口服务的属性注入
            //containerBuilder.RegisterType<HHController>().As<ControllerBase>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//指定作用域，指定应用域
            var types = this.GetType().Assembly.ExportedTypes.Where(t => typeof(ControllerBase).IsAssignableFrom(t)).ToArray();
            //注册所有controller,PropertiesAutowired 属性注入所有的接口服务以及自定义特性CustomPropAttribute区分标记和自定义属性选择器MyPropertySelector
            containerBuilder.RegisterTypes(types).PropertiesAutowired(new MyPropertySelector());
            #endregion

            #region Autofac 配置文件 配置IOC 依赖注入 属性注入 Autofac， Autofac.Configuration，Autofac.Extensions.DependencyInjection autofacconfig.json设置始终复制和内容
            ////Autofac 配置文件 配置IOC 依赖注入 属性注入
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.Add(new JsonConfigurationSource() { Path = "Config/autofacconfig.json", Optional = false, ReloadOnChange = true });
            //var conmodule = new ConfigurationModule(configurationBuilder.Build());
            //containerBuilder.RegisterModule(conmodule);
            //测试
            ////var contaier = containerBuilder.Build();
            //var contaier = containerBuilder.Build();
            //var testA = contaier.Resolve<ITestA>();
            //testA.Show();
            //var testA1 = contaier.Resolve<ITestA>();
            //testA1.Show();
            //var testB = contaier.Resolve<ITestB>();
            //testB.Show();
            //var testB1 = contaier.Resolve<ITestB>();
            //testB1.Show();
            //Console.WriteLine($"瞬态：{object.ReferenceEquals(testA, testA1)}");
            #endregion

            #region autofac 的Ioc 依赖注入的生命周期

            #region 作用域
            #region 方法注入  InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的

            //using var scope = contaier.BeginLifetimeScope("TEST456");
            //var testG = scope.Resolve<ITestG>();
            //testG.Show();//测试方法注入
            #endregion

            #region 属性注入  InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的

            //using var scope = contaier.BeginLifetimeScope("TEST123");
            //var testE = scope.Resolve<ITestE>();
            //testE.Show();//测试属性注入

            #endregion

            #region 属性注入 InstancePerMatchingLifetimeScope使用作用域及子作用域，匹配作用域，只有一个实例，无论是父子作用域还是父下面的不同子作用域他们的实例都是相同的
            //ITestD testD5;
            //ITestD testD6;
            //ITestD testD7;
            //using var scope = contaier.BeginLifetimeScope("TEST");
            //var testD = scope.Resolve<ITestD>();
            ////var testA = scope.Resolve<ITestA>();//测试属性注入
            ////testA.Show();
            //testD.Show();//测试属性注入
            //testD5 = testD;

            ////子作用域
            //using var scope1 = scope.BeginLifetimeScope();
            //var testD1 = scope1.Resolve<ITestD>();
            //var testD11 = scope1.Resolve<ITestD>();
            //testD6 = testD1;
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testD1, testD11)}");

            ////子作用域
            //using var scope2 = scope.BeginLifetimeScope();
            //var testD2 = scope2.Resolve<ITestD>();
            //testD7 = testD2;
            //var testD21 = scope2.Resolve<ITestD>();
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testD2, testD21)}");

            //Console.WriteLine($"作用域及子作用域：{object.ReferenceEquals(testD5, testD6)}");
            //Console.WriteLine($"不同子作用域对比：{object.ReferenceEquals(testD6, testD7)}");
            #endregion

            #region InstancePerLifetimeScope使用作用域及子作用域
            //ITestC testC5;
            //ITestC testC6;
            //ITestC testC7;
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC5 = testC;

            ////子作用域
            //using var scope1 = scope.BeginLifetimeScope();
            //var testC1 = scope1.Resolve<ITestC>();
            //var testC11 = scope1.Resolve<ITestC>();
            //testC6 = testC1;
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testC1, testC11)}");

            ////子作用域
            //using var scope2 = scope.BeginLifetimeScope();
            //var testC2 = scope2.Resolve<ITestC>();
            //testC7 = testC2;
            //var testC21 = scope2.Resolve<ITestC>();
            //Console.WriteLine($"子作用域内部：{object.ReferenceEquals(testC2, testC21)}");

            //Console.WriteLine($"作用域及子作用域：{object.ReferenceEquals(testC5, testC6)}");
            //Console.WriteLine($"不同子作用域对比：{object.ReferenceEquals(testC6, testC7)}");
            #endregion

            #region InstancePerLifetimeScope使用同一作用域及不同作用域
            //ITestC testC5;
            //ITestC testC6;
            //using var scope1 = contaier.BeginLifetimeScope();
            //var testC = scope1.Resolve<ITestC>();
            //testC.Show();
            //testC5 = testC;
            //var testC1 = scope1.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"相同作用域：{object.ReferenceEquals(testC, testC1)}");

            //using var scope2 = contaier.BeginLifetimeScope();
            //var testC3 = scope2.Resolve<ITestC>();
            //testC3.Show();
            //testC6 = testC3;
            //var testC4 = scope2.Resolve<ITestC>();
            //testC4.Show();
            //Console.WriteLine($"相同作用域：{object.ReferenceEquals(testC3, testC4)}");

            //Console.WriteLine($"不同作用域对比：{object.ReferenceEquals(testC5, testC6)}");
            #endregion

            #region InstancePerLifetimeScope使用作用域
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = scope.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"作用域：{object.ReferenceEquals(testC, testC1)}");
            #endregion

            #region InstancePerLifetimeScope默认作用域单例
            //var testC = contaier.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = contaier.Resolve<ITestC>();
            //testC1.Show(); 
            //Console.WriteLine($"作用域：{object.ReferenceEquals(testC, testC1)}");
            #endregion
            #endregion

            #region 单例
            //var testB = contaier.Resolve<ITestB>();
            //testB.Show();
            //var testB1 = contaier.Resolve<ITestB>();
            //testB1.Show();
            //Console.WriteLine($"单例：{object.ReferenceEquals(testB, testB1)}");
            #endregion

            #region 瞬态
            //var testA = contaier.Resolve<ITestA>();
            ////testA.Show();
            //var testA1 = contaier.Resolve<ITestA>();
            ////testA1.Show();
            //Console.WriteLine($"瞬态：{object.ReferenceEquals(testA,testA1)}"); 
            #endregion

            #endregion

            #region Autofac 一对象多实例问题,例如：一个接口ITestA 2个实现TestA和TestF
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();//单例
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//作用域，应用域
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////指定作用域，指定应用域 
            ////1、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试
            //containerBuilder.RegisterType<TestF>().As<ITestA>().InstancePerDependency();
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();

            ////一个接口ITestA 2个实现TestA和TestF,
            ////AController中使用测试，可以同时获取接口ITestA的2个实现TestA和TestF的实例，
            ////然后可以使用TestA和TestF来调用对应的方法,
            ////使用 public AController(ITestA testA, IEnumerable<ITestA> testAList, TestA testAA, TestF testFF, ITestC testC)
            ////containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo(typeof(ITestA))));
            ////下面是对上面的扩展，其实内容是一样的
            //containerBuilder.RegisterModule(new CustomModule());

            ////var contaier = containerBuilder.Build();
            ////var testA = contaier.Resolve<ITestA>();
            ////testA.Show();
            ////var testA1 = contaier.Resolve<ITestA>();
            //testA1.Show();

            ////2、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试
            //containerBuilder.RegisterType<TestF>().Named<ITestA>("TestF").InstancePerDependency();
            //containerBuilder.RegisterType<TestA>().Named<ITestA>("TestA").InstancePerDependency();
            //var contaier = containerBuilder.Build();
            //var testA = contaier.ResolveKeyed<ITestA>("TestA");
            //testA.Show();
            //var testF = contaier.ResolveKeyed<ITestA>("TestF");
            //testF.Show();

            ////3、例如：一个接口ITestA 2个实现TestA和TestF,AController中使用测试 使用Index1测试
            //containerBuilder.RegisterType<TestF>().Named<ITestA>("TestF").InstancePerDependency();
            //containerBuilder.RegisterType<TestA>().Named<ITestA>("TestA").InstancePerDependency();
            ////var contaier = containerBuilder.Build();
            ////var testA = contaier.ResolveKeyed<ITestA>("TestA");
            ////testA.Show();
            ////var testF = contaier.ResolveKeyed<ITestA>("TestF");
            ////testF.Show();

            ////var componentCintext = contaier.Resolve<IComponentContext>();
            ////var testA1 = componentCintext.ResolveKeyed<ITestA>("TestA");
            ////testA1 = componentCintext.ResolveNamed<ITestA>("TestA");
            ////testA1.Show();
            ////var testF1 = componentCintext.ResolveKeyed<ITestA>("TestF");
            ////testF1 = componentCintext.ResolveKeyed<ITestA>("TestF");
            ////testF1.Show();
            #endregion

            #region Autofac Interceptor拦截器,例如：一个接口ITestA 实现TestA拦截
            //containerBuilder.RegisterType<CustomInterceptor>();//Interceptor拦截器
            //containerBuilder.RegisterType<CustomAsyncInterceptor>();//IAsyncInterceptor拦截器

            //EnableInterfaceInterceptors启用接口

            //// [Intercept(typeof(CustomInterceptor))],在指定的接口上添加特性，这个有侵入性
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance().EnableInterfaceInterceptors();//单例
            ////推荐使用拦截器，这个不具侵入性，推荐使用该方法
            //containerBuilder.RegisterType<TestC>().AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(CustomInterceptor));//作用域，应用域
            ////containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(CustomInterceptor));//作用域，应用域
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////指定作用域，指定应用域 
            ////例如：Interceptor拦截器,例如：一个接口ITestA 实现TestA拦截,启用EnableInterfaceInterceptors()
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();

            //EnableClassInterceptors启用类型

            //使用EnableInterfaceInterceptors的时候，在是实现类上使用[Intercept(typeof(CustomInterceptor))] 特性标记，同时该类的方法必须是virtual
            //containerBuilder.RegisterType<TestC>().As<ITestC>().SingleInstance().EnableClassInterceptors();//单例
            //使用EnableInterfaceInterceptors的时候，在是实现类未使用[Intercept(typeof(CustomInterceptor))] 特性标记，同时该类的方法必须是virtual
            //containerBuilder.RegisterType<TestC>().As<ITestC>().SingleInstance().EnableClassInterceptors().InterceptedBy(typeof(CustomInterceptor));//单例

            ////添加拦截器的精简写法
            containerBuilder.RegisterType<CustomInterceptor>();//Interceptor拦截器
            containerBuilder.RegisterType<CustomAsyncInterceptor>();//IAsyncInterceptor拦截器
            var typeTests = this.GetType().Assembly.ExportedTypes.Where(t => t.Name.Contains("Test")).ToArray();
            containerBuilder.RegisterTypes(typeTests).AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(CustomInterceptor));

            //var contaier = containerBuilder.Build();
            //var testA = contaier.Resolve<ITestA>();
            //testA.Show();
            //var testA1 = contaier.Resolve<ITestA>();
            //testA1.Show();
            #endregion
            #endregion

            #region MyRegion
            //未使用构造函数依赖注入时，可以使用该特性[CustomFilter]标记,即自定义的filter过滤器CustomFilter，时必须要有无参构造函数
            //[TypeFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
            //[ServiceFilter(typeof(CustomFilterAttribute))]//可以使用无参构造函数也可以使用有参构造函数依赖注入其他需要的信息
            //containerBuilder.RegisterType<CustomFilterAttribute>();//注册定义过滤器特性
            containerBuilder.RegisterType<CustomFilterAttribute>().PropertiesAutowired();//注册定义过滤器特性,属性注入
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            #region 请求错误路径异常
            ////请求错误路径异常
            //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");//只要不是200，都可以进来
            //app.UseExceptionHandler(options =>
            //        options.Run(async context =>
            //        {
            //            context.Response.StatusCode = 200;
            //            //context.Response.ContentType = "text/html";
            //            //await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
            //            var ss = Encoding.UTF8.GetBytes("错误信息： 未找到对应的页面！！！");
            //            var ss1 = Encoding.UTF8.GetString(ss);
            //            await context.Response.WriteAsync(ss1, Encoding.UTF8);
            //            var excep = context.Features.Get<IExceptionHandlerPathFeature>();
            //            Console.WriteLine($"{excep?.Error.Message}");
            //            if (excep?.Error is FileNotFoundException file)
            //            {
            //                await context.Response.WriteAsync("File error thrown </br>");
            //            }
            //            //await context.Response.WriteAsync("<a href=\"/\">点击返回主页Home</a></br>");
            //            //await context.Response.WriteAsync("</body></html>");
            //            await context.Response.WriteAsync(new string(' ',512));//IE Padding
            //        }));
            #endregion

            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net第二种使用方法
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //引入 Microsoft.Extensions.FileProviders; PhysicalFileProvider
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"))
                //FileProvider = new PhysicalFileProvider("wwwroot")//使用指定的静态文件wwwroot下的js和css文件，发布版本一般不需要写，会自动使用
            });

            app.UseRouting();

            //使用限流中间件
            app.UseIpRateLimiting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region 多环境--方法多环境 Demo环境 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDemoServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            NLog.LogManager.GetCurrentClassLogger().Info("测试nlog日志。。。。。");
            //NLog.LogManager.Shutdown();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureDemoContainer(ContainerBuilder containerBuilder)
        {
            //原生的服务容器，会自动注册到当前Autofac container容器中去，不需要使用containerBuilder.Populate(services);

            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            //containerBuilder.RegisterType<TestB>().As<ITestB>().InstancePerDependency();
            containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerDependency();
            containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDemo(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net第二种使用方法
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion
    }
}
