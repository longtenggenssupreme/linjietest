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
                var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();
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
                Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
                //context.Attach(ss);//告诉EF Core开始跟踪person实体的更改，因为调用DbContext.Attach方法后，EF Core会将person实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改回EntityState.Unchanged，所以这里testDBContext.Attach(ss)一定要放在下面一行testDBContext.Entry(ss).Property(p => p.Content).IsModified = true的前面，否者后面的testDBContext.SaveChanges方法调用后，数据库不会被更新
                //context.Entry(ss).Property(p => p.Content).IsModified = true;//告诉EF Core实体ss的Content属性已经更改。将testDBContext.Entry(person).Property(p => p.Name).IsModified设置为true后，也会将ss实体的State值（可以通过testDBContext.Entry(ss).State查看到）更改为EntityState.Modified，这样就保证了下面SaveChanges的时候会将ss实体的Content属性值Update到数据库中。
                //context.Entry(ss).Property(p => p.Content).IsModified = true;
                //context.Tests.Attach(ss);
                context.Attach(ss);
                Console.WriteLine($"context.Entry(ss).State:{context.Entry(ss).State}");
                //context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }

            //切换表
            DateTime datetime2 = DateTime.Now.AddDays(-1);
            using (var context = new DynamicContext { CreateDateTime = datetime2 })
            {
                var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();
                if (!tablename.Equals("20201118"))
                {
                    var str = GetMySQLSqls(datetime2);
                    //判断是否存在表，不存在则创建
                    using var cmd = context.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = str[1];
                    if (cmd.Connection.State!= System.Data.ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                   var result= cmd.ExecuteScalar();
                    if (result.ToString()=="0")
                    {
                        //创建新表
                        context.Database.ExecuteSqlRaw(str[1]);
                    }                   
                }

                //context.Database.EnsureCreated();
                context.Tests.Add(new Test { Title = "Great News Two", Content = $"Hello World! I am the news of {datetime2}", CreateDateTime = datetime2 });
                context.SaveChanges();
            }

            using (var context = new DynamicContext { CreateDateTime = datetime1 })
            {
                var entity = context.Tests.Single();
                // Writes news of today
                Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            }

            using (var context = new DynamicContext { CreateDateTime = datetime2 })
            {
                var entity = context.Tests.Single();
                // Writes news of yesterday
                Console.WriteLine($"{entity.Title} {entity.Content} {entity.CreateDateTime}");
            }
            Console.Read();
        }
        private static string[] GetMySQLSqls(DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string decide = $"SELECT count(1) FROM information_schema.TABLES WHERE table_name='{tableName}'";
            string sqlRaw = $@"
CREATE TABLE IF NOT EXISTS `{tableName}` (
  `Id` bigint(20) NOT NULL,
  `Title` varchar(max) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Content` varchar(max) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateDateTime` datetime2(7) NOT NULL,
  PRIMARY KEY (`Id`),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
";
            return new string[] { decide, sqlRaw };
        }
    }
}
