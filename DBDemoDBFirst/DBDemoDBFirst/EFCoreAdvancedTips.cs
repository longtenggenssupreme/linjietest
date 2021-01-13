using DBDemoDBFirst.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemoDBFirst
{
    public static class EFCoreAdvancedTips
    {
        public static void Show()
        {
            using ZhaoxiDbContext context = new ZhaoxiDbContext();
            ////延迟执行，使用的时候才执行
            //var commodity001s = context.JdCommodity001s.OrderByDescending(a => a.Id < 30);
            //foreach (var jd in commodity001s)
            //{
            //    Console.WriteLine(jd.Title);
            //}
            ////延迟执行，使用的时候才执行
            //var commodity001s1 = context.JdCommodity001s.OrderByDescending(a => a.Id < 30).ToList();

            //var commodity001 = context.JdCommodity001s.FirstOrDefault(a => a.Id == 3);
            //var commodity001s = context.JdCommodity001s.Find(3);//Find会先去查询内存，如果内存中有的话，就不会去查询数据库了，否则会再去查询数据库数据

            var commodity001s = context.JdCommodity001s.Where(a => a.Id == 3).FirstOrDefault();
            Console.WriteLine($"{context.Entry(commodity001s).State}"); 
            var commodity001 = context.JdCommodity001s.Where(a => a.Id < 10).AsNoTracking().ToList();
            Console.WriteLine($"{context.Entry(commodity001[0]).State}");
        }
    }
}
