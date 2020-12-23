using Autofac;
using Autofac.Features.ResolveAnything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// 定义内部类，用于自定义的模块的注册
    /// Autofac 一对象多实例问题,例如：一个接口ITestA 2个实现TestA和TestF 
    //一个接口ITestA 2个实现TestA和TestF,
    //AController中使用测试，可以同时获取接口ITestA的2个实现TestA和TestF的实例，
    //然后可以使用TestA和TestF来调用对应的方法
    /// </summary>
    public class CustomModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo(typeof(ITestA))));
        }
    }
}
