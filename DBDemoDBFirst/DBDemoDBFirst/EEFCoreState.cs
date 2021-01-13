using DBDemoDBFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemoDBFirst
{
    public static class EEFCoreState
    {
        public static void Show()
        {
            JdCommodity001 jdCommodity = new JdCommodity001
            {
                //Id = 123,
                ProductId = 456,
                CategoryId = 789,
                ImageUrl = "imageurl",
                Price = 123,
                Title = "11111",
                Url = "url"
            };
            using ZhaoxiDbContext context = new ZhaoxiDbContext();
            Console.WriteLine($"{context.Entry<JdCommodity001>(jdCommodity).State}");

            #region Detached 未跟踪状态===》跟踪状态Unchanged = 1,Deleted = 2,Modified = 3,Added = 4
            ////Detached = 0, Unchanged = 1,Deleted = 2,Modified = 3,Added = 4
            ////Detached 未跟踪状态===》跟踪状态Unchanged = 1,Deleted = 2,Modified = 3,Added = 4
            ////
            //context.Entry(jdCommodity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ////
            //context.JdCommodity001s.Update(jdCommodity);//EntityState.Modified;
            ////
            //context.JdCommodity001s.Attach(jdCommodity);
            //context.Entry(jdCommodity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //context.ChangeTracker.DetectChanges();
            ////
            //context.Attach(jdCommodity);
            //context.Entry(jdCommodity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //context.ChangeTracker.DetectChanges();
            ////
            //context.ChangeTracker.TrackGraph(root, e =>
            //{
            //    if (e.Entry.Entity is JdCommodity001)
            //    {
            //        e.Entry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //    }
            //    else
            //    {
            //        e.Entry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //    }
            //});
            ////
            //context.Entry(jdCommodity).Property(p => p.Title).IsModified = true; 
            #endregion


            //CRUD-C增加
            context.JdCommodity001s.Add(jdCommodity);
            Console.WriteLine($"{context.Entry<JdCommodity001>(jdCommodity).State}");
            context.SaveChanges();

            //CRUD-R查询U修改
            var reslut = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
            Console.WriteLine($"{context.Entry<JdCommodity001>(reslut).State}");
            reslut.Title = "22222";
            Console.WriteLine($"{context.Entry<JdCommodity001>(reslut).State}");
            context.SaveChanges();

            //CRUD-R删除
            var reslut1 = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
            Console.WriteLine($"{context.Entry<JdCommodity001>(reslut1).State}");
            context.JdCommodity001s.Remove(reslut1);
            Console.WriteLine($"{context.Entry<JdCommodity001>(reslut1).State}");
            context.SaveChanges();

            //CRUD-R查询
            var reslut2 = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
            Console.WriteLine($"{context.Entry<JdCommodity001>(reslut2).State}");
        }
    }
}
