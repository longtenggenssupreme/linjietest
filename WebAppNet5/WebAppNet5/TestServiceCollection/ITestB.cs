using Autofac.Extras.DynamicProxy;
using Castle.Core;

namespace WebAppNet5
{
    /// <summary>
    /// 测试接口A
    /// </summary>
    [Intercept(typeof(CustomInterceptor))]
    public interface ITestB
    {
        /// <summary>
        /// 测试方法
        /// </summary>
        void Show();
    }
}
