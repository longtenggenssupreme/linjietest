using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// NET5_ServiceFilter_TypeFilter的原理_扩展定制IFilterFactory
    /// </summary>
    public class CustomFilterFactory : Attribute, IFilterFactory
    {
        public bool IsReusable => true;
        private readonly Type _type;
        public CustomFilterFactory(Type type)
        {
            _type = type;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(_type);
        }
    }
}
