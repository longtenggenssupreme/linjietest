using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{

    /// <summary>
    /// 标记不同的属性--特性标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomPropAttribute : Attribute
    {
    }
}
