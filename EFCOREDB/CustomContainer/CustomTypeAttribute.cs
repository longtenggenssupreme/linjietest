using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 自定义标记需要的类的特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class CustomTypeAttribute : Attribute
    {
        //在需要标记的class类上标记[CustomPropertyAttribute]即可,使用type.GetCustomAttribute(typeof(CustomPropertyAttribute));即可获取带有标记的类了
    }
}
