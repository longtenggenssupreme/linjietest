using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LinjieWebApi
{
    /// <summary>
    /// 拦截器--自定义日志记录拦截器
    /// </summary>
    public class LoggerAsyncInterceptor : IAsyncInterceptor
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private readonly ILogger<LoggerAsyncInterceptor> _logger;

        public LoggerAsyncInterceptor(ILogger<LoggerAsyncInterceptor> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 异步拦截--拦截返回结果为void的方法
        /// </summary>
        /// <param name="invocation"></param>
        public void InterceptAsynchronous(IInvocation invocation)
        {
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之前");
            invocation.Proceed();
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之后");
        }

        /// <summary>
        /// 异步拦截--拦截返回结果为Task的方法
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="invocation"></param>
        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之前");
            invocation.ReturnValue = InternalInterceptAsynchronous<TResult>(invocation);
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之后");            
        }

        /// <summary>
        /// 同步拦截--拦截同步执行的方法
        /// </summary>
        /// <param name="invocation"></param>
        public void InterceptSynchronous(IInvocation invocation)
        {
            _logger.LogInformation($"同步拦截---{invocation.Method.Name}方法调用之前");
            invocation.Proceed();
            _logger.LogInformation($"同步拦截---{invocation.Method.Name}方法调用之后");
            
        }

        /// <summary>
        /// 异步拦截--拦截返回结果为Task<TResult>的方法
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="invocation"></param>
        /// <returns></returns>
        public async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            //方法调用之前
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之前");
            invocation.Proceed();
            var taskresult = (Task<TResult>)invocation.ReturnValue;
            var result = await taskresult;
            //方法调用之后
            _logger.LogInformation($"异步拦截---{invocation.Method.Name}方法调用之后");
            return result;
        }
    }
}
