﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOREDB
{
    /// <summary>
    /// 长方形
    /// </summary>
    [CustomType]
    public class RectangleShape : IShape
    {
        [CustomProperty]
        public SquareShape SquareShape { get; set; }

        public void Show()
        {
            Console.WriteLine("RectangleShape");
        }
    }
}
