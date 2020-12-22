using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAppNet5
{
    /// <summary>
    /// autofac中自定义属性选择器类
    /// </summary>
    public class MyPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.GetCustomAttributes().Any(att => att.GetType() == typeof(CustomPropAttribute));
        }
    }
}
