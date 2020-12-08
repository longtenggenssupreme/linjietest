using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace EFCOREDB
{
    /// <summary>
    /// 分库分表使用
    /// </summary>
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context) => context is DynamicContext dynamicContext ? (context.GetType(), dynamicContext.CreateDateTime) : (object)context.GetType(); 
    }
}
