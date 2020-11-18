
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace EFCOREDB
{
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context) => context is DynamicContext dynamicContext ? (context.GetType(), dynamicContext.CreateDateTime) : (object)context.GetType(); 
    }
}
