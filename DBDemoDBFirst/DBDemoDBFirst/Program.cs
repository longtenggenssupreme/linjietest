using System;
using System.Linq;
using DBDemoDBFirst.Entity;

namespace DBDemoDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //根据数据库生成代码的脚本Scaffold-DbContext "Data Source=WIN-CSTBNBVVGSQ;Initial Catalog=ZhaoxiEduDataBase;User ID=sa;Password=sa123" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity -Force -Context ZhaoxiDbContext -ContextDir /
            try
            {
                #region CRUD
                //using ZhaoxiDbContext context = new ZhaoxiDbContext();
                ////CRUD-C增加
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

                ////CRUD-R查询U修改
                //var reslut = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
                //reslut.Title = "22222";
                //context.SaveChanges();

                ////CRUD-R删除
                //var reslut1 = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
                //context.JdCommodity001s.Remove(reslut1);
                //context.SaveChanges();

                ////CRUD-R查询
                //var reslut2 = context.JdCommodity001s.OrderByDescending(a => a.Id).FirstOrDefault();
                #endregion

                //EFCoreQuery.Show();
                //EEFCoreState.Show();
                //EFCoreTransaction.Show();
                EFCoreAdvancedTips.Show();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                throw;
            }
        }
    }
}
