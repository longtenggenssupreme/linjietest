using System;
using DBDemoCodeFirst.Entity;

namespace DBDemoCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                using ZhaoxiDbContext context = new ZhaoxiDbContext();
                #region CodeFirst 创建数据库 
                context.Database.EnsureDeleted();//删除数据库
                context.Database.EnsureCreated();//创建数据库 
                #endregion

                #region CodeFirst 创建数据库
                //add-migration addmigration001
                //update-database
                #endregion
                //CRUD-C增加
                //context.JdCommodity001s.Add(new JdCommodity001
                //{
                //    //Id = 123,
                //    ProductId = 456,
                //    CategoryId = 789,
                //    ImageUrl = "imageurl",
                //    Price = 123,
                //    Title = "11111",
                //    Url = "url"
                //});
                //context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
