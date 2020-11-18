using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCOREDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime datetime1 = DateTime.Now;
            using (var context = new DynamicContext { CreateDateTime = datetime1 })
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                #region MyRegion
                //context.Tests.Add(new Test { Title = "Great News One", Content = $"Hello World! I am the news of {datetime1}", CreateDateTime = datetime1 });
                //更新实体的方式
                //0、查询实体，修改实体字段，context.SaveChanges();
                //1、创建实体，context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
                //2、创建实体，context.Update(创建的实体); context.SaveChanges();
                //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
                //3、创建实体，context.DbSet<Test>.Attach(创建的实体); context.ChangeTracker.DetectChanges(); context.SaveChanges();
                //3、创建实体，context.Attach(创建的实体); context.Entry(创建的实体).State=EntityState.Modified; context.SaveChanges();
                //4、context.ChangeTracker.TrackGraph(ss, e => {
                //    if ((e.Entry.Entity as Test) != null)
                //    {
                //        e.Entry.State = EntityState.Unchanged;
                //    }
                //    else
                //    {
                //        e.Entry.State = EntityState.Modified;
                //    }
                //});
                //context.SaveChanges(); 
                #endregion

                var ss = new Test { Title = "11", Content = $"111 {datetime1}", CreateDateTime = datetime1 };
                //context.Tests.Attach(ss);
                context.Attach(ss);
                Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
                //context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
            DateTime datetime2 = DateTime.Now.AddDays(-1);
            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    //context.Database.EnsureCreated();
            //    context.Tests.Add(new Test { Title = "Great News Two", Content = $"Hello World! I am the news of {datetime2}", CreateDateTime = datetime2 });
            //    context.SaveChanges();
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime1 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of today
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //}

            //using (var context = new DynamicContext { CreateDateTime = datetime2 })
            //{
            //    var entity = context.Tests.Single();
            //    // Writes news of yesterday
            //    Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            //}
            Console.Read();
        }
    }
}
