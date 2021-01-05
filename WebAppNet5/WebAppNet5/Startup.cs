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
            #region ��ȡ�����ļ���ʽ
            ////��һ�ֶ�ȡ�����ļ���ʽ---ֱ�Ӷ�ȡ���ã�ͨ��������ȡ
            //var writeConnectString = Configuration["ConnectingStrings:WriteConnecting"];//��ȡ��Ӧ�����ã����¼�֮��ʹ��ð�ŷָ�
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //var testConnectStringServer = Configuration["ConnectingStrings:TestConnecting:Server"];
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectStringServer={testConnectStringServer}");
            //var testConnectString = Configuration["ConnectingStrings:TestConnecting:Microsoft.Hosting.Lifetime"];
            //Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectString={testConnectString}");
            ////var testConnectString22 = Configuration.GetSection("ConnectingStrings");
            ////Console.WriteLine($"��һ�ֶ�ȡ�����ļ���ʽ: testConnectString={testConnectString}");
            //Console.WriteLine($"---------------------");

            ////�ڶ��ֶ�ȡ�����ļ���ʽ---�����ļ���ָ���Ķ���
            ////ȱ��:�����ȴ����ð󶨵Ķ���֮�����ʹ�ã�������
            //Rootobject rootobject = new Rootobject();
            //Configuration.Bind(rootobject);
            //Connectingstrings option = new Connectingstrings();
            //Configuration.GetSection("ConnectingStrings").Bind(option);

            ////�����ȴ����ð󶨵Ķ���������Ҫ�ĵط�ʹ�ù��캯������ע�� IOptions<Connectingstrings> options ��ȡoptions.Value����ʹ��
            ////ʹ��IServiceCollectionע�������ļ�����ָ����ʵ������
            //services.Configure<Rootobject>(Configuration);
            //services.Configure<Connectingstrings>(Configuration.GetSection("ConnectingStrings"));

            //Console.WriteLine($"�ڶ��ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");

            ////�����ֶ�ȡ�����ļ���ʽ
            //var ip = Configuration["ip"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //var port = Configuration["port"];//dotnet WenAppNet5.dll --urls="http://*:8081" --ip="127.0.0.1" --port=8082
            //Console.WriteLine($"�����ֶ�ȡ�����ļ���ʽ: writeConnectString={writeConnectString}");
            //Console.WriteLine($"---------------------");
            #endregion

            services.Configure<Rootobject>(Configuration);
            services.AddControllersWithViews();
            //services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            //NLog.LogManager.GetCurrentClassLogger().Info("����nlog��־����������");
            //NLog.LogManager.Shutdown();
            services.AddRazorPages().AddRazorRuntimeCompilation();//������Ԥ���룬Ĭ��ϵͳ�Ὣ��ͼ�������Ԥ���봦�����ջὫ����õ���ͼ
            //.NETӦ��ʵ�ֶ�ʱ����
            services.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();

            //����������ע�룬Ĭ��ioc����֮�����ӿڷ��񣬿������Ĵ�������IControllerActivator�����ģ�����ʹ��ioc��������ServiceBasedControllerActivator
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            #region ���ʹ����������AspNetCoreRateLimit
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimit"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddHttpContextAccessor();

            //���ȫ�ֹ�����
            services.AddMvc(option => //option.Filters.Add<GlobalFilterExecRangeAndOrderAttribute>()
            option.Filters.Add<CustomExceptionFilterAttribute>());
            #endregion

            //��Ҫʹ�� Encoding.RegisterProvider��������ע��Provider Encoding ֧���磺GB2312����ȡ�
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            #region ��������

            #region ԭ���ķ�������
            //ԭ���ķ������������Զ�ע�ᵽ��ǰAutofac container������ȥ������Ҫʹ��containerBuilder.Populate(services);

            ////containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();
            ////containerBuilder.RegisterType<TestB>().As<ITestB>().InstancePerDependency();
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerDependency();
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerDependency(); 
            #endregion

            #region AutofacĬ�϶��ǹ��캯��ע��
            ////AutofacĬ�϶��ǹ��캯��ע��
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();//˲̬
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();//����
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//������Ӧ����
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////ָ��������ָ��Ӧ���� 
            #endregion

            #region Autofacʹ�÷���ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            ////Autofacʹ�÷���ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            //containerBuilder.RegisterType<TestG>()
            //.OnActivated(t => t.Instance.MethodInject(t.Context.Resolve<ITestB>()))
            //.As<ITestG>().InstancePerMatchingLifetimeScope("TEST456")
            //.PropertiesAutowired();//ָ��������ָ��Ӧ���� 
            #endregion

            #region Autofac�ӿڷ���ʹ������ע��----PropertiesAutowired����ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            ////Autofac�ӿڷ���ʹ������ע��----PropertiesAutowired����ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            //containerBuilder.RegisterType<TestE>().As<ITestE>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//ָ��������ָ��Ӧ���� 
            #endregion

            #region Autofac Controller�������нӿڷ���ʹ������ע��----PropertiesAutowired����ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            //Autofac Controller�������нӿڷ���ʹ������ע��----PropertiesAutowired����ע��----�ӿ��е�ʵ�����е������ӿڷ��������ע��
            //containerBuilder.RegisterType<HHController>().As<ControllerBase>().InstancePerMatchingLifetimeScope("TEST123").PropertiesAutowired();//ָ��������ָ��Ӧ����
            var types = this.GetType().Assembly.ExportedTypes.Where(t => typeof(ControllerBase).IsAssignableFrom(t)).ToArray();
            //ע������controller,PropertiesAutowired ����ע�����еĽӿڷ����Լ��Զ�������CustomPropAttribute���ֱ�Ǻ��Զ�������ѡ����MyPropertySelector
            containerBuilder.RegisterTypes(types).PropertiesAutowired(new MyPropertySelector());
            #endregion

            #region Autofac �����ļ� ����IOC ����ע�� ����ע�� Autofac�� Autofac.Configuration��Autofac.Extensions.DependencyInjection autofacconfig.json����ʼ�ո��ƺ�����
            ////Autofac �����ļ� ����IOC ����ע�� ����ע��
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.Add(new JsonConfigurationSource() { Path = "Config/autofacconfig.json", Optional = false, ReloadOnChange = true });
            //var conmodule = new ConfigurationModule(configurationBuilder.Build());
            //containerBuilder.RegisterModule(conmodule);
            //����
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
            //Console.WriteLine($"˲̬��{object.ReferenceEquals(testA, testA1)}");
            #endregion

            #region autofac ��Ioc ����ע�����������

            #region ������
            #region ����ע��  InstancePerMatchingLifetimeScopeʹ����������������ƥ��������ֻ��һ��ʵ���������Ǹ����������Ǹ�����Ĳ�ͬ�����������ǵ�ʵ��������ͬ��

            //using var scope = contaier.BeginLifetimeScope("TEST456");
            //var testG = scope.Resolve<ITestG>();
            //testG.Show();//���Է���ע��
            #endregion

            #region ����ע��  InstancePerMatchingLifetimeScopeʹ����������������ƥ��������ֻ��һ��ʵ���������Ǹ����������Ǹ�����Ĳ�ͬ�����������ǵ�ʵ��������ͬ��

            //using var scope = contaier.BeginLifetimeScope("TEST123");
            //var testE = scope.Resolve<ITestE>();
            //testE.Show();//��������ע��

            #endregion

            #region ����ע�� InstancePerMatchingLifetimeScopeʹ����������������ƥ��������ֻ��һ��ʵ���������Ǹ����������Ǹ�����Ĳ�ͬ�����������ǵ�ʵ��������ͬ��
            //ITestD testD5;
            //ITestD testD6;
            //ITestD testD7;
            //using var scope = contaier.BeginLifetimeScope("TEST");
            //var testD = scope.Resolve<ITestD>();
            ////var testA = scope.Resolve<ITestA>();//��������ע��
            ////testA.Show();
            //testD.Show();//��������ע��
            //testD5 = testD;

            ////��������
            //using var scope1 = scope.BeginLifetimeScope();
            //var testD1 = scope1.Resolve<ITestD>();
            //var testD11 = scope1.Resolve<ITestD>();
            //testD6 = testD1;
            //Console.WriteLine($"���������ڲ���{object.ReferenceEquals(testD1, testD11)}");

            ////��������
            //using var scope2 = scope.BeginLifetimeScope();
            //var testD2 = scope2.Resolve<ITestD>();
            //testD7 = testD2;
            //var testD21 = scope2.Resolve<ITestD>();
            //Console.WriteLine($"���������ڲ���{object.ReferenceEquals(testD2, testD21)}");

            //Console.WriteLine($"��������������{object.ReferenceEquals(testD5, testD6)}");
            //Console.WriteLine($"��ͬ��������Աȣ�{object.ReferenceEquals(testD6, testD7)}");
            #endregion

            #region InstancePerLifetimeScopeʹ����������������
            //ITestC testC5;
            //ITestC testC6;
            //ITestC testC7;
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC5 = testC;

            ////��������
            //using var scope1 = scope.BeginLifetimeScope();
            //var testC1 = scope1.Resolve<ITestC>();
            //var testC11 = scope1.Resolve<ITestC>();
            //testC6 = testC1;
            //Console.WriteLine($"���������ڲ���{object.ReferenceEquals(testC1, testC11)}");

            ////��������
            //using var scope2 = scope.BeginLifetimeScope();
            //var testC2 = scope2.Resolve<ITestC>();
            //testC7 = testC2;
            //var testC21 = scope2.Resolve<ITestC>();
            //Console.WriteLine($"���������ڲ���{object.ReferenceEquals(testC2, testC21)}");

            //Console.WriteLine($"��������������{object.ReferenceEquals(testC5, testC6)}");
            //Console.WriteLine($"��ͬ��������Աȣ�{object.ReferenceEquals(testC6, testC7)}");
            #endregion

            #region InstancePerLifetimeScopeʹ��ͬһ�����򼰲�ͬ������
            //ITestC testC5;
            //ITestC testC6;
            //using var scope1 = contaier.BeginLifetimeScope();
            //var testC = scope1.Resolve<ITestC>();
            //testC.Show();
            //testC5 = testC;
            //var testC1 = scope1.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"��ͬ������{object.ReferenceEquals(testC, testC1)}");

            //using var scope2 = contaier.BeginLifetimeScope();
            //var testC3 = scope2.Resolve<ITestC>();
            //testC3.Show();
            //testC6 = testC3;
            //var testC4 = scope2.Resolve<ITestC>();
            //testC4.Show();
            //Console.WriteLine($"��ͬ������{object.ReferenceEquals(testC3, testC4)}");

            //Console.WriteLine($"��ͬ������Աȣ�{object.ReferenceEquals(testC5, testC6)}");
            #endregion

            #region InstancePerLifetimeScopeʹ��������
            //using var scope = contaier.BeginLifetimeScope();
            //var testC = scope.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = scope.Resolve<ITestC>();
            //testC1.Show();
            //Console.WriteLine($"������{object.ReferenceEquals(testC, testC1)}");
            #endregion

            #region InstancePerLifetimeScopeĬ����������
            //var testC = contaier.Resolve<ITestC>();
            //testC.Show();
            //var testC1 = contaier.Resolve<ITestC>();
            //testC1.Show(); 
            //Console.WriteLine($"������{object.ReferenceEquals(testC, testC1)}");
            #endregion
            #endregion

            #region ����
            //var testB = contaier.Resolve<ITestB>();
            //testB.Show();
            //var testB1 = contaier.Resolve<ITestB>();
            //testB1.Show();
            //Console.WriteLine($"������{object.ReferenceEquals(testB, testB1)}");
            #endregion

            #region ˲̬
            //var testA = contaier.Resolve<ITestA>();
            ////testA.Show();
            //var testA1 = contaier.Resolve<ITestA>();
            ////testA1.Show();
            //Console.WriteLine($"˲̬��{object.ReferenceEquals(testA,testA1)}"); 
            #endregion

            #endregion

            #region Autofac һ�����ʵ������,���磺һ���ӿ�ITestA 2��ʵ��TestA��TestF
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance();//����
            //containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope();//������Ӧ����
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////ָ��������ָ��Ӧ���� 
            ////1�����磺һ���ӿ�ITestA 2��ʵ��TestA��TestF,AController��ʹ�ò���
            //containerBuilder.RegisterType<TestF>().As<ITestA>().InstancePerDependency();
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();

            ////һ���ӿ�ITestA 2��ʵ��TestA��TestF,
            ////AController��ʹ�ò��ԣ�����ͬʱ��ȡ�ӿ�ITestA��2��ʵ��TestA��TestF��ʵ����
            ////Ȼ�����ʹ��TestA��TestF�����ö�Ӧ�ķ���,
            ////ʹ�� public AController(ITestA testA, IEnumerable<ITestA> testAList, TestA testAA, TestF testFF, ITestC testC)
            ////containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo(typeof(ITestA))));
            ////�����Ƕ��������չ����ʵ������һ����
            //containerBuilder.RegisterModule(new CustomModule());

            ////var contaier = containerBuilder.Build();
            ////var testA = contaier.Resolve<ITestA>();
            ////testA.Show();
            ////var testA1 = contaier.Resolve<ITestA>();
            //testA1.Show();

            ////2�����磺һ���ӿ�ITestA 2��ʵ��TestA��TestF,AController��ʹ�ò���
            //containerBuilder.RegisterType<TestF>().Named<ITestA>("TestF").InstancePerDependency();
            //containerBuilder.RegisterType<TestA>().Named<ITestA>("TestA").InstancePerDependency();
            //var contaier = containerBuilder.Build();
            //var testA = contaier.ResolveKeyed<ITestA>("TestA");
            //testA.Show();
            //var testF = contaier.ResolveKeyed<ITestA>("TestF");
            //testF.Show();

            ////3�����磺һ���ӿ�ITestA 2��ʵ��TestA��TestF,AController��ʹ�ò��� ʹ��Index1����
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

            #region Autofac Interceptor������,���磺һ���ӿ�ITestA ʵ��TestA����
            //containerBuilder.RegisterType<CustomInterceptor>();//Interceptor������
            //containerBuilder.RegisterType<CustomAsyncInterceptor>();//IAsyncInterceptor������

            //EnableInterfaceInterceptors���ýӿ�

            //// [Intercept(typeof(CustomInterceptor))],��ָ���Ľӿ���������ԣ������������
            //containerBuilder.RegisterType<TestB>().As<ITestB>().SingleInstance().EnableInterfaceInterceptors();//����
            ////�Ƽ�ʹ����������������������ԣ��Ƽ�ʹ�ø÷���
            //containerBuilder.RegisterType<TestC>().AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(CustomInterceptor));//������Ӧ����
            ////containerBuilder.RegisterType<TestC>().As<ITestC>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(CustomInterceptor));//������Ӧ����
            //containerBuilder.RegisterType<TestD>().As<ITestD>().InstancePerMatchingLifetimeScope("TEST");////ָ��������ָ��Ӧ���� 
            ////���磺Interceptor������,���磺һ���ӿ�ITestA ʵ��TestA����,����EnableInterfaceInterceptors()
            //containerBuilder.RegisterType<TestA>().As<ITestA>().InstancePerDependency();

            //EnableClassInterceptors��������

            //ʹ��EnableInterfaceInterceptors��ʱ������ʵ������ʹ��[Intercept(typeof(CustomInterceptor))] ���Ա�ǣ�ͬʱ����ķ���������virtual
            //containerBuilder.RegisterType<TestC>().As<ITestC>().SingleInstance().EnableClassInterceptors();//����
            //ʹ��EnableInterfaceInterceptors��ʱ������ʵ����δʹ��[Intercept(typeof(CustomInterceptor))] ���Ա�ǣ�ͬʱ����ķ���������virtual
            //containerBuilder.RegisterType<TestC>().As<ITestC>().SingleInstance().EnableClassInterceptors().InterceptedBy(typeof(CustomInterceptor));//����

            ////����������ľ���д��
            containerBuilder.RegisterType<CustomInterceptor>();//Interceptor������
            containerBuilder.RegisterType<CustomAsyncInterceptor>();//IAsyncInterceptor������
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
            //δʹ�ù��캯������ע��ʱ������ʹ�ø�����[CustomFilter]���,���Զ����filter������CustomFilter��ʱ����Ҫ���޲ι��캯��
            //[TypeFilter(typeof(CustomFilterAttribute))]//����ʹ���޲ι��캯��Ҳ����ʹ���вι��캯������ע��������Ҫ����Ϣ
            //[ServiceFilter(typeof(CustomFilterAttribute))]//����ʹ���޲ι��캯��Ҳ����ʹ���вι��캯������ע��������Ҫ����Ϣ
            //containerBuilder.RegisterType<CustomFilterAttribute>();//ע�ᶨ�����������
            containerBuilder.RegisterType<CustomFilterAttribute>().PropertiesAutowired();//ע�ᶨ�����������,����ע��
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


            #region �������·���쳣
            ////�������·���쳣
            //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");//ֻҪ����200�������Խ���
            //app.UseExceptionHandler(options =>
            //        options.Run(async context =>
            //        {
            //            context.Response.StatusCode = 200;
            //            //context.Response.ContentType = "text/html";
            //            //await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
            //            var ss = Encoding.UTF8.GetBytes("������Ϣ�� δ�ҵ���Ӧ��ҳ�棡����");
            //            var ss1 = Encoding.UTF8.GetString(ss);
            //            await context.Response.WriteAsync(ss1, Encoding.UTF8);
            //            var excep = context.Features.Get<IExceptionHandlerPathFeature>();
            //            Console.WriteLine($"{excep?.Error.Message}");
            //            if (excep?.Error is FileNotFoundException file)
            //            {
            //                await context.Response.WriteAsync("File error thrown </br>");
            //            }
            //            //await context.Response.WriteAsync("<a href=\"/\">���������ҳHome</a></br>");
            //            //await context.Response.WriteAsync("</body></html>");
            //            await context.Response.WriteAsync(new string(' ',512));//IE Padding
            //        }));
            #endregion

            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net�ڶ���ʹ�÷���
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //���� Microsoft.Extensions.FileProviders; PhysicalFileProvider
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot"))
                //FileProvider = new PhysicalFileProvider("wwwroot")//ʹ��ָ���ľ�̬�ļ�wwwroot�µ�js��css�ļ��������汾һ�㲻��Ҫд�����Զ�ʹ��
            });

            app.UseRouting();

            //ʹ�������м��
            app.UseIpRateLimiting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region �໷��--�����໷�� Demo���� 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDemoServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITestA, TestA>();
            services.AddTransient<ITestB, TestB>();
            NLog.LogManager.GetCurrentClassLogger().Info("����nlog��־����������");
            //NLog.LogManager.Shutdown();
        }

        // This method gets called by the runtime. Use this method to add services to the Autofac container.
        public void ConfigureDemoContainer(ContainerBuilder containerBuilder)
        {
            //ԭ���ķ������������Զ�ע�ᵽ��ǰAutofac container������ȥ������Ҫʹ��containerBuilder.Populate(services);

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
            //loggerFactory.AddLog4Net("Config/log4net.config");//log4net�ڶ���ʹ�÷���
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
