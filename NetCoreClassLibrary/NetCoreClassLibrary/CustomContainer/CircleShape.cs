using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 圆型
    /// </summary>
    [CustomTypeAttribute]
    public class CircleShape : IShape
    {
        public void Show()
        {
            Console.WriteLine("CircleShape");
        }
    }
}
