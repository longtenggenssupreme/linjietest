﻿using Microsoft.EntityFrameworkCore;
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
                Console.WriteLine("开始删除数据库");
                context.Database.EnsureDeleted();
                Console.WriteLine("删除成功");
                Console.WriteLine("开始创建数据库");
                context.Database.EnsureCreated();
                Console.WriteLine("创建成功");
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
                var tablename = context.Model.FindEntityType(typeof(Test)).GetTableName();//查询实体映射道数据库中对应的表名称
                if (!tablename.Equals("20201118"))
                {
                    //var str = GetMySQLSqls(datetime2);
                    var str = GetSqlServerSqls(datetime2);
                    
                    //判断是否存在表，不存在则创建
                    using var cmd = context.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = str[0];
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
                context.Tests.Add(new Test { Title = "22", Content = $"222 {datetime2}", CreateDateTime = datetime2 });
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
  `Id` int(20) NOT NULL,
  `Title` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Content` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateDateTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetSqlServerSqls(DateTime time)
        {
            //注意：[Id] int NOT NULL IDENTITY(1,1)中的 IDENTITY(1,1) 表示自增
            string tableName = time.ToString("yyyyMMdd");          
            //-- 判断要创建的表名是否存在 select * from dbo.sysobjects where id=object_id(N'[dbo].[{0}]') and xtype='U'
            string decide = $"SELECT COUNT(1) FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[{tableName}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            string sqlRaw = $@"IF NOT EXISTS ( SELECT * FROM dbo.sysobjects WHERE id=object_id(N'[dbo].[{tableName}]') AND xtype='U')
BEGIN
CREATE TABLE [dbo].[{tableName}] (
[Id] int NOT NULL IDENTITY(1,1),
[Title] nvarchar(20) NULL ,
[Content] nvarchar(500) NULL ,
[CreateDateTime] datetime2(7) NOT NULL ,
);
ALTER TABLE [dbo].[{tableName}] ADD PRIMARY KEY ([Id]);
END";
            return new string[] { decide, sqlRaw };
        }

        private static string[] GetOracleSqls(string defaultSchema, DateTime time)
        {
            string tableName = time.ToString("yyyyMMdd");
            string schema = defaultSchema;
            string id_seq = $"{tableName}_id_seq";
            var pk = $"PK_{tableName}";
            string decide = $"SELECT COUNT(1) FROM all_tables WHERE TABLE_NAME='{tableName}' AND OWNER='{schema}'";
            string sqlRaw =
$@"DECLARE num NUMBER;
BEGIN
	SELECT
		COUNT(1) INTO num 
	FROM
		all_tables 
	WHERE
		TABLE_NAME = '{tableName}' 
		AND OWNER = '{schema}';
	IF
		num = 0 THEN
			EXECUTE IMMEDIATE 'CREATE TABLE ""{schema}"".""{tableName}"" (
            ""Id"" NUMBER(10) NOT NULL,
            ""Title"" NVARCHAR2(20),
            ""Content"" NCLOB,
            ""CreateDateTime"" TIMESTAMP(7) NOT NULL,
            CONSTRAINT ""{pk}"" PRIMARY KEY(""Id""),
            )';

            EXECUTE IMMEDIATE 'CREATE SEQUENCE ""{schema}"".""{id_seq}"" START WITH 1 INCREMENT BY 1';
            END IF;
            END; ";
            return new string[] { decide, sqlRaw };
        }
    }
}
