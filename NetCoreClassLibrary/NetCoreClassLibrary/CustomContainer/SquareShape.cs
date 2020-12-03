using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 正方形
    /// </summary>
    [CustomTypeAttribute]
    public class SquareShape : IShape
    {
        [CustomProperty]
        public RectangleShape RectangleShape { get; set; }
        public void Show()
        {
            Console.WriteLine("SquareShape");
        }
    }
}
